using System.Text;

namespace Gandalf.LogicaNegocio.Modelo
{
    public class Produto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Marca { get; set; }
        public string Categoria { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Id: {Id}");
            sb.AppendLine($"Nome: {Nome}");
            sb.AppendLine($"Marca: {Marca}");
            sb.AppendLine($"Categoria: {Categoria}");

            return sb.ToString();
        }
    }
}