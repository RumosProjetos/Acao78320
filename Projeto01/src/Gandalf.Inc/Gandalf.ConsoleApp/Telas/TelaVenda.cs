using Gandalf.ConsoleApp.Regras;
using Gandalf.LogicaNegocio.Modelo;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;

namespace Gandalf.ConsoleApp.Telas
{
    public static class TelaVenda
    {
        private static List<Produto> ProdutosSelecionados;
        private static Estoque listaProdutosEmEstoque;

        public static void ExibirTelaInicio(List<Produto> produtosSelecionados = null)
        {
            Console.Clear();
            Console.WriteLine("Gandalf.Inc");
            Console.WriteLine("-------------");
            Console.WriteLine("Ponto de Venda");
            Console.WriteLine("-------------");
            Console.WriteLine("Pressione:");
            Console.WriteLine("1 - Para Buscar Produto");
            Console.WriteLine("x - Para Sair");
            Console.WriteLine("-------------");

            if (produtosSelecionados != null)
            {
                ProdutosSelecionados = produtosSelecionados;
            }

            string comando = Console.ReadLine();

            if (comando == "x")
            {
                TelaLogin.ExibirTelaBenvindo();
            }
            else
            {
                if (comando == "1")
                {
                    ExibirSelecaoBusca();
                }
            }
        }

        public static void ExibirSelecaoBusca()
        {
            Console.Clear();
            Console.WriteLine("-------------");
            Console.WriteLine("Pressione:");
            Console.WriteLine("1 - Para Buscar Produto por nome");
            Console.WriteLine("2 - Para Buscar Produto por marca");
            Console.WriteLine("3 - Para Buscar Produto por categoria");
            Console.WriteLine("4 - Para Encerrar a compra");
            Console.WriteLine("x - Para voltar");
            Console.WriteLine("-------------");

            string comando = Console.ReadLine();

            if (comando == "x")
            {
                TelaLogin.ExibirTelaInicio();
            }
            else
            {
                if (comando == "1" || comando == "2" || comando == "3")
                {
                    TipoBusca tipoBusca = (TipoBusca)(Convert.ToInt32(comando));
                    ExibirTelaBuscaProdutos(tipoBusca);
                }
                else
                {
                    if (comando == "4")
                    {
                        CarrinhoCompras.ExibirTelaInicio(ProdutosSelecionados, listaProdutosEmEstoque);
                    }
                }
            }
        }

        public static void ExibirTelaBuscaProdutos(TipoBusca tipoBusca)
        {
            Console.Clear();
            string ConteudoDosProdutos = File.ReadAllText("estoque.json");
            listaProdutosEmEstoque = JsonConvert.DeserializeObject<Estoque>(ConteudoDosProdutos);

            Console.WriteLine("-------------");
            string tipoBuscaTexto = "Nome";
            if (tipoBusca == TipoBusca.Marca)
            {
                tipoBuscaTexto = "Marca";
            }
            if (tipoBusca == TipoBusca.Categoria)
            {
                tipoBuscaTexto = "Categoria";
            }

            Console.WriteLine($"Digite o/a {tipoBuscaTexto}:");
            string termoProcurado = Console.ReadLine().ToLower().Trim();

            Produto produtoSelecionado = null;
            //BUG: Está pegando apenas o último produto encontrado
            //Solucao: Pegar por ID ou qualquer coisa que identifique um objeto específico
            //Possivelmente adicionar outra tela intermediária para selecao
            foreach (ProdutoQuantidade produto in listaProdutosEmEstoque.Disponibilidade)
            {
                if (tipoBusca == TipoBusca.Nome && produto.Produto.Nome.ToLower().Trim() == termoProcurado)
                {
                    produtoSelecionado = produto.Produto;
                }
                else
                {
                    if (tipoBusca == TipoBusca.Marca && produto.Produto.Marca.ToLower().Trim() == termoProcurado)
                    {
                        produtoSelecionado = produto.Produto;
                    }
                    else
                    {
                        if (tipoBusca == TipoBusca.Categoria && produto.Produto.Categoria.ToLower().Trim() == termoProcurado)
                        {
                            produtoSelecionado = produto.Produto;
                        }
                    }
                }
            }

            if (produtoSelecionado != null)
            {
                Console.WriteLine("Produto Encontrado");
                Console.WriteLine("-------------");
                Console.WriteLine(produtoSelecionado.ToString());

                if (ProdutosSelecionados == null)
                {
                    ProdutosSelecionados = new List<Produto>();
                }

                ProdutosSelecionados.Add(produtoSelecionado);
            }
            Thread.Sleep(3000);
            ExibirSelecaoBusca();
        }
    }
}
