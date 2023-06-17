using System;
using System.ComponentModel.DataAnnotations;

namespace Gandalf.RepositorioDados.Modelo
{
    public class DetalhesVenda
    {
        [Key]
        public int Id { get; set; }
        public virtual Venda Venda { get; set; }
        public int Sequencial { get; set; }
        public virtual Produto Produto { get; set; }
        public int Quantidade { get; set; }
        public decimal PrecoUnitario { get; set; }
        public decimal TotalLinha { get; set; }
        public DateTime DataCriacao { get; set; }
    }
}
