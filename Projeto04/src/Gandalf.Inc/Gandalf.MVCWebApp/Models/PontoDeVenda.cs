using System;
using System.Collections.Generic;

namespace Gandalf.MVCWebApp.Models;

public partial class PontoDeVenda
{
    public int Id { get; set; }

    public string? Localizacao { get; set; }

    public int? LojaId { get; set; }

    public virtual Loja? Loja { get; set; }

    public virtual ICollection<Venda> Venda { get; set; } = new List<Venda>();
}
