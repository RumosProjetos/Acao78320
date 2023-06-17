using Gandalf.RepositorioDados.Modelo;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gandalf.RepositorioDados.Data
{
    public class PosContext : DbContext
    {
        public PosContext() : base("PosDatabase")
        {
            //PosStore
        }

        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<DetalhesVenda> DetalhesVendas { get; set; }
        public DbSet<Estoque> Estoques { get; set; }
        public DbSet<Loja> Lojas { get; set; }
        public DbSet<Pagamento> Pagamentos { get; set; }
        public DbSet<PontoDeVenda> PontoDeVendas { get; set; }
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<TipoPagamento> TipoPagamentos { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Venda> Vendas { get; set; }
        public DbSet<Encomenda> Encomendas { get; set; }
        public DbSet<EncomendaEspecial> EncomendaEspecials { get; set; }
        public DbSet<TabelaAleatoriaParaExemplosComChavePrimariaComposta> TabelaAleatoriaParaExemplosComChavePrimariaCompostas { get; set; }
        public DbSet<TabelaAleatoriaParaExemplos> TabelaAleatoriaParaExemploss { get; set; }


    }
}
