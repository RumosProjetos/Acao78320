using System;
using System.Collections.Generic;

namespace Gandalf.MVCWebApp.Models;

public partial class DetalhesVenda
{
    public int Id { get; set; }

    public int Sequencial { get; set; }

    public int Quantidade { get; set; }

    public decimal PrecoUnitario { get; set; }

    public decimal TotalLinha { get; set; }

    public DateTime DataCriacao { get; set; }

    public int? ProdutoId { get; set; }

    public int? VendaId { get; set; }

    public virtual Produto? Produto { get; set; }

    public virtual Venda? Venda { get; set; }
}
