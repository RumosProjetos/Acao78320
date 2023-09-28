using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Gandalf.MVCWebApp.Models;

public partial class Produto
{
    public int Id { get; set; }

    public string? Nome { get; set; }

    [Display(Name = "Código de Barras")]
    public string? CodigoBarras { get; set; }

    [Display(Name = "Unidade de Medida (kg, lt, un, ...)")]
    public string? UnidadeMedida { get; set; }

    [Display(Name = "Valor por Unidade")]
    public int QuantidadePorUnidade { get; set; }

    [Display(Name = "Preço")]
    public decimal PrecoUnitario { get; set; }

    public bool Discontinuado { get; set; }

    [Display(Name = "Criado em")]
    public DateTime? DataCriacao { get; set; }

    [Display(Name = "Modificado em")]
    public DateTime? DataModificacao { get; set; }

    [Display(Name = "Categoria")]
    public int? CategoriaId { get; set; }

    [Display(Name = "Categoria")]
    public virtual Categoria? Categoria { get; set; }

    [Display(Name = "Venda")]
    public virtual ICollection<DetalhesVenda> DetalhesVenda { get; set; } = new List<DetalhesVenda>();

    [Display(Name = "Estoque")]
    public virtual ICollection<Estoque> Estoques { get; set; } = new List<Estoque>();
}
