using System;
using System.Collections.Generic;

namespace Gandalf.MVCWebApp.Models;

public partial class Loja
{
    public int Id { get; set; }

    public string? Nome { get; set; }

    public string? Morada { get; set; }

    public bool Ativo { get; set; }

    public DateTime DataCriacao { get; set; }

    public DateTime DataModificacao { get; set; }

    public virtual ICollection<Estoque> Estoques { get; set; } = new List<Estoque>();

    public virtual ICollection<Pagamento> Pagamentos { get; set; } = new List<Pagamento>();

    public virtual ICollection<PontoDeVenda> PontoDeVenda { get; set; } = new List<PontoDeVenda>();

    public virtual ICollection<Venda> Venda { get; set; } = new List<Venda>();
}
