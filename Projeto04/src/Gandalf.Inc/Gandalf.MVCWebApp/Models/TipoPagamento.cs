using System;
using System.Collections.Generic;

namespace Gandalf.MVCWebApp.Models;

public partial class TipoPagamento
{
    public int Id { get; set; }

    public string? Nome { get; set; }

    public virtual ICollection<Pagamento> Pagamentos { get; set; } = new List<Pagamento>();
}
