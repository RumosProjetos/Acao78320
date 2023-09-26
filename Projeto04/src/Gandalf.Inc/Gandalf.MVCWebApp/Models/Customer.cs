using System;
using System.Collections.Generic;

namespace Gandalf.MVCWebApp.Models;

public partial class Customer
{
    public int CustomerId { get; set; }

    public string Nome { get; set; } = null!;

    public string? Endereco { get; set; }

    public string? Cidade { get; set; }

    public string? Email { get; set; }

    public string NumeroIdentificacaoFiscal { get; set; } = null!;

    public DateTime DataNascimento { get; set; }

    public virtual ICollection<Venda> Venda { get; set; } = new List<Venda>();
}
