using System.ComponentModel.DataAnnotations;

namespace Gandalf.RepositorioDados.Modelo
{
    public class Categoria
    {
        [Key]
        public int Id { get; set; }
        public string Nome { get; set; }
    }
}