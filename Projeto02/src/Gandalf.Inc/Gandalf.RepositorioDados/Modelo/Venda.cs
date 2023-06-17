using System;
using System.ComponentModel.DataAnnotations;

namespace Gandalf.RepositorioDados.Modelo
{
    public class Venda
    {
        [Key]
        public int Id { get; set; }

        public string NumeroFatura { get; set; }
        public Loja Loja { get; set; }
        public PontoDeVenda PontoDeVenda { get; set; }
        public Usuario Usuario { get; set; }
        public DateTime DataCriacao { get; set; }
        public DateTime DataModificacao { get; set; }
        public bool Pago { get; set; }
        public string Cliente { get; set; }
    }
}


