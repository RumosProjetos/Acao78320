using System.ComponentModel.DataAnnotations;

namespace Gandalf.RepositorioDados.Modelo
{
    public class PontoDeVenda
    {
        [Key]
        public int Id { get; set; }
        public Loja Loja { get; set; }
        public string Localizacao { get; set; }
    }
}