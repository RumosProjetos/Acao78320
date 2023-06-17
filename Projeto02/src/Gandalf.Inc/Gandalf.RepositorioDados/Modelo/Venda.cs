using System;
using System.ComponentModel.DataAnnotations;

namespace Gandalf.RepositorioDados.Modelo
{
    public class Venda
    {
        [Key]
        public int Id { get; set; }

        public string NumeroFatura { get; set; }
        public virtual Loja Loja { get; set; }
        public virtual PontoDeVenda PontoDeVenda { get; set; }
        public virtual Usuario Usuario { get; set; }
        public DateTime DataCriacao { get; set; }
        public DateTime DataModificacao { get; set; }
        public bool Pago { get; set; }
        public virtual Cliente Cliente { get; set; }
        public bool Promocao { get; set; }
    }
}


