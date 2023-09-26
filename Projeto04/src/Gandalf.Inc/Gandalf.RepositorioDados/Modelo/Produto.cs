using System;
using System.ComponentModel.DataAnnotations;

namespace Gandalf.RepositorioDados.Modelo
{
    public class Produto
    {
        [Key]
        public int Id { get; set; }
        public string Nome { get; set; }
        public string CodigoBarras { get; set; }
        public virtual Categoria Categoria { get; set; }
        public string UnidadeMedida { get; set; }
        public int QuantidadePorUnidade { get; set; }
        public decimal PrecoUnitario { get; set; }
        public bool Discontinuado { get; set; }
        public DateTime DataCriacao { get; set; }
        public DateTime DataModificacao { get; set; }
    }
}