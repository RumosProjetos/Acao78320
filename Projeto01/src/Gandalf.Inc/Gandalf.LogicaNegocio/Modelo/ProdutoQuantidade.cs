namespace Gandalf.LogicaNegocio.Modelo
{
    public class ProdutoQuantidade {
        public ProdutoQuantidade(Produto produto, int quantidade = 0)
        {
            Produto = produto;
            Quantidade = quantidade;
        }
        public Produto Produto { get; set; }
        public int Quantidade { get; set;}
    }
}