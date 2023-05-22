using Gandalf.LogicaNegocio.Modelo;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gandalf.ConsoleApp.Telas
{
    public static class TelaLogin
    {
        public static Utilizador utilizadorLogado { get; set; }

        public static void ExibirTelaInicio()
        {
            Console.Clear();
            Console.WriteLine("Gandalf.Inc");
            Console.WriteLine("-------------");
            Console.WriteLine("Ponto de Venda");
            Console.WriteLine("-------------");
            Console.WriteLine("Pressione:");
            Console.WriteLine("1 - Para login");
            Console.WriteLine("x - Para Sair");
            Console.WriteLine("-------------");

            string comando = Console.ReadLine();

            if (comando == "x")
            {
                return;
            }
            else
            {
                if (comando == "1")
                {
                    ExibirTelaLogin();
                }
            }
        }


        public static void ExibirTelaLogin()
        {
            Console.Clear();
            Dictionary<string, string> Utilizadores = new Dictionary<string, string>();

            string[] utilizadoresDB = File.ReadAllLines("UtilizadoresDB.csv");
            foreach (var credencial in utilizadoresDB)
            {
                string[] usuario = credencial.Split(',');
                string nomeUsuario = usuario[0];
                string senhaUsuario = usuario[1];

                //Dicionário não suporta chaves repetidas
                if (Utilizadores.ContainsKey(nomeUsuario) == false)
                {
                    Utilizadores.Add(nomeUsuario.ToLower().Trim(), senhaUsuario.ToLower().Trim());
                }
            }


            Console.WriteLine("Informar Nome:");
            string nome = Console.ReadLine().ToLower().Trim();

            Console.WriteLine("Informar Senha:");
            string senha = Console.ReadLine().ToLower().Trim();

            if (Utilizadores.ContainsKey(nome) && (Utilizadores[nome].ToLower().Trim() == senha))
            {
                utilizadorLogado = new Utilizador
                {
                    Nome = nome,
                    Id = new Random().Next(),
                    Senha = senha,
                    NumeroMecanografico = Guid.NewGuid().ToString()
                };
                ExibirTelaBenvindo();
            }
            else
            {    
                ExibirTelaInicio();
            }
        }

        public static void ExibirTelaBenvindo()
        {
            Console.Clear();
            Console.WriteLine($"Benvindo");
            Console.WriteLine($"Hoje é {DateTime.Now:dd-MM-yyyy}");
            Console.WriteLine("-------------");
            Console.WriteLine("Pressione:");
            Console.WriteLine("1 - Para Vendas");
            Console.WriteLine("x - Para Sair");
            Console.WriteLine("-------------");
            string comando = Console.ReadLine();

            if (comando == "x")
            {
                return;
            }
            else
            {
                if (comando == "1")
                {
                    //TODO: Remover isso para o fluxo principal do programa
                    TelaVenda.ExibirTelaInicio();
                }
            }
        }
    }
}
