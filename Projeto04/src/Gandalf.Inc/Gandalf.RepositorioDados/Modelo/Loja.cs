using System;
using System.ComponentModel.DataAnnotations;

namespace Gandalf.RepositorioDados.Modelo
{
    public class Loja
    {
        [Key]
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Morada { get; set; }
        public bool Ativo { get; set; }
        public DateTime DataCriacao { get; set; }
        public DateTime DataModificacao { get; set; }
    }
}