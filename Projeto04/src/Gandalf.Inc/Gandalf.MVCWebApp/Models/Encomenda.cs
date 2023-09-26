using System;
using System.Collections.Generic;

namespace Gandalf.MVCWebApp.Models;

public partial class Encomenda
{
    public int Id { get; set; }

    public string? DadosEncomenda { get; set; }

    public bool? EmbalarParaPresente { get; set; }

    public string Discriminator { get; set; } = null!;
}
