using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Gandalf.RepositorioDados.Modelo
{
    public abstract class Pessoa
    {
        [Key]
        [DatabaseGenerated(databaseGeneratedOption: DatabaseGeneratedOption.Identity)]
        public virtual int Id { get; set; } //Pode ser susbtituído na classe derivada
        public abstract string Nome { get; set; } //Vai ter que ser substituído na classe derivada
        public virtual string Endereco { get; set; }
        public virtual string Cidade { get; set; }
        public virtual string Email { get; set; }

        public DateTime DataNascimento { get; set; }
    }
}
