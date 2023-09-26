using System;
using System.Collections.Generic;

namespace Gandalf.MVCWebApp.Models;

public partial class Estoque
{
    public int Id { get; set; }

    public int Quantidade { get; set; }

    public int QuantidadeBase { get; set; }

    public string? UnidadeVenda { get; set; }

    public int QuantidadeUnidadeVenda { get; set; }

    public DateTime DataCriacao { get; set; }

    public DateTime DataModificacao { get; set; }

    public int? LojaId { get; set; }

    public int? ProdutoId { get; set; }

    public virtual Loja? Loja { get; set; }

    public virtual Produto? Produto { get; set; }
}
