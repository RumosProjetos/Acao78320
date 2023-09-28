using System;
using System.Collections.Generic;

namespace Gandalf.MVCWebApp.Models;

public partial class Venda
{
    public int Id { get; set; }

    public string? NumeroFatura { get; set; }

    public DateTime? DataCriacao { get; set; }

    public DateTime? DataModificacao { get; set; }

    public bool Pago { get; set; }

    public int? ClienteId { get; set; }

    public int? LojaId { get; set; }

    public int? PontoDeVendaId { get; set; }

    public int? UsuarioId { get; set; }

    public bool Promocao { get; set; }

    public virtual Customer? Cliente { get; set; }

    public virtual ICollection<DetalhesVenda> DetalhesVenda { get; set; } = new List<DetalhesVenda>();

    public virtual Loja? Loja { get; set; }

    public virtual ICollection<Pagamento> Pagamentos { get; set; } = new List<Pagamento>();

    public virtual PontoDeVenda? PontoDeVenda { get; set; }

    public virtual Usuario? Usuario { get; set; }
}
