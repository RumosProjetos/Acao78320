using System;
using System.Collections.Generic;

namespace Gandalf.MVCWebApp.Models;

public partial class Pagamento
{
    public int Id { get; set; }

    public decimal ValorPago { get; set; }

    public DateTime DataCriacao { get; set; }

    public int? LojaId { get; set; }

    public int? TipoPagamentoId { get; set; }

    public int? VendaId { get; set; }

    public virtual Loja? Loja { get; set; }

    public virtual TipoPagamento? TipoPagamento { get; set; }

    public virtual Venda? Venda { get; set; }
}
