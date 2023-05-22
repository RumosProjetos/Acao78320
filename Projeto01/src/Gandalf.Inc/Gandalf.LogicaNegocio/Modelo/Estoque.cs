using System.Collections.Generic;

namespace Gandalf.LogicaNegocio.Modelo
{
    public class Estoque
    {
        public Estoque()
        {
            Disponibilidade = new List<ProdutoQuantidade>();
        }
        public List<ProdutoQuantidade> Disponibilidade { get; set; }
    }
}