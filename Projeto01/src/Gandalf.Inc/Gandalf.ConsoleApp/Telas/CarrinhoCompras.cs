using Gandalf.LogicaNegocio.Modelo;
using Gandalf.LogicaNegocio.Regras;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gandalf.ConsoleApp.Telas
{
    public static class CarrinhoCompras
    {
        private static List<Produto> ProdutosSelecionados;

        public static void ExibirTelaInicio(List<Produto> produtosSelecionados)
        {
            Console.Clear();
            Console.WriteLine("Gandalf.Inc");
            Console.WriteLine("-------------");
            Console.WriteLine("Ponto de Venda");
            Console.WriteLine("-------------");
            Console.WriteLine("Pressione:");
            Console.WriteLine("1 - Para Efetivar Compra");
            Console.WriteLine("x - Para Voltar");
            Console.WriteLine("-------------");
            Console.WriteLine("Carrinho de Compras");
            foreach (var item in produtosSelecionados)
            {
                Console.WriteLine(item.ToString());
            }

            ProdutosSelecionados = produtosSelecionados;
            string comando = Console.ReadLine();

            if (comando == "x")
            {
                TelaVenda.ExibirTelaInicio(produtosSelecionados);
            }
            else
            {
                if (comando == "1")
                {
                    EfetivarCompra();
                }
            }
        }

        public static void EfetivarCompra()
        {
            Console.Clear();
            Console.WriteLine("Informe o nome do Cliente");
            string nomeCliente = Console.ReadLine();

            var venda = new Venda
            {
                Utilizador = TelaLogin.utilizadorLogado,
                Cliente = new Cliente { 
                    Id = new Random().Next(), 
                    Nome = nomeCliente,
                    Nacionalidade = "Portuguesa",
                    NumeroIdentificacaoFiscal = "123456789",
                    Telefone = "123456789"
                },
                DataHora = new DateTime()                
            };

            venda.Itens = new List<Item>();
            var estoque = new Estoque();

            foreach (var item in ProdutosSelecionados)
            {
                var quantidade = new Random().Next();

                venda.Itens.Add(new Item { 
                    Produto = item, 
                    Quantidade = quantidade, 
                    ValorUnitario = (decimal)new Random().NextDouble() 
                });

                estoque.Disponibilidade.Add(item, quantidade * 10);
            }


            var regraVendas = new VendasRegras(venda, estoque);
            regraVendas.SalvarVenda();
        }
    }
}
