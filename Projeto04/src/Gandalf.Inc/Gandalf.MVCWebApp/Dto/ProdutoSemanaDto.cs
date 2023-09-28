namespace Gandalf.MVCWebApp.Dto
{
    public class ProdutoSemanaDto
    {
        public string? Nome { get; set; }
        public int QuantidadeVendida { get; set; }
        public decimal PrecoUnitario { get; set; }
        public decimal ValorTotalVendido => PrecoUnitario * QuantidadeVendida;
    }
}