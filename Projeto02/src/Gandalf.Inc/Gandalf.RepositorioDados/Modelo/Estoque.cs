using System;
using System.ComponentModel.DataAnnotations;

namespace Gandalf.RepositorioDados.Modelo
{
    public class Estoque
    {
        [Key]
        public int Id { get; set; }
        public virtual Produto Produto { get; set; }
        public virtual Loja Loja { get; set; }
        public int Quantidade { get; set; }
        public int QuantidadeBase { get; set; }
        public string UnidadeVenda { get; set; }
        public int QuantidadeUnidadeVenda { get; set; }
        public DateTime DataCriacao { get; set; }
        public DateTime DataModificacao { get; set; }
    }
}
