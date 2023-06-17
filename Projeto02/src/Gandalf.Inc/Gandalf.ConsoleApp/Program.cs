using Gandalf.RepositorioDados.Data;
using Gandalf.RepositorioDados.Modelo;
using System;
using System.Linq;

namespace Gandalf.Inc
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Loja lj = new Loja
            //{
            //    Nome = "Barreiro Filial",
            //    Ativo = true,
            //    DataCriacao = DateTime.UtcNow,
            //    DataModificacao = DateTime.UtcNow,
            //    Morada = "Rua do Barreiro...",
            //};

            //PontoDeVenda pdv = new PontoDeVenda
            //{
            //    Loja = lj,
            //    Localizacao = "Andar 002"
            //};

            PosContext context = new PosContext();
            //var pdvs = context.PontoDeVendas.Where(x => x.Loja.Id == 2);
            //var lj = context.Lojas.FirstOrDefault(x => x.Id == 2);

            //context.PontoDeVendas.RemoveRange(pdvs);
            //context.Lojas.Remove(lj);

            //context.Lojas.Add(lj);
            //context.PontoDeVendas.Add(pdv);

            var encomendaNormal = new Encomenda
            {
                DadosEncomenda = "Dados Quaisquer"
            };

            var encomendaEspecial = new EncomendaEspecial
            {
                EmbalarParaPresente = true,
                DadosEncomenda = "Dados quaisquer especiais"
                
            };

            context.EncomendaEspecials.Add(encomendaEspecial);
            context.Encomendas.Add(encomendaNormal);

            context.SaveChanges();
        }
    }
}
