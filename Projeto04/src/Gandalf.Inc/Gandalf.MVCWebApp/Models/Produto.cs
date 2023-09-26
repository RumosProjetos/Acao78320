using System;
using System.Collections.Generic;

namespace Gandalf.MVCWebApp.Models;

public partial class Produto
{
    public int Id { get; set; }

    public string? Nome { get; set; }

    public string? CodigoBarras { get; set; }

    public string? UnidadeMedida { get; set; }

    public int QuantidadePorUnidade { get; set; }

    public decimal PrecoUnitario { get; set; }

    public bool Discontinuado { get; set; }

    public DateTime DataCriacao { get; set; }

    public DateTime DataModificacao { get; set; }

    public int? CategoriaId { get; set; }

    public virtual Categoria? Categoria { get; set; }

    public virtual ICollection<DetalhesVenda> DetalhesVenda { get; set; } = new List<DetalhesVenda>();

    public virtual ICollection<Estoque> Estoques { get; set; } = new List<Estoque>();
}
