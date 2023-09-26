using System.ComponentModel.DataAnnotations;
using System.Data.Entity.Migrations.Model;

namespace Gandalf.RepositorioDados.Modelo
{
    public class Categoria
    {
        [Key]
        public int Id { get; set; }
        public string Nome { get; set; }
    }
}
