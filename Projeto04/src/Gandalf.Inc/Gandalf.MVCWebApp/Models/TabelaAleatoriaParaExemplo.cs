using System;
using System.Collections.Generic;

namespace Gandalf.MVCWebApp.Models;

public partial class TabelaAleatoriaParaExemplo
{
    public Guid ChavePrimaria { get; set; }

    public string? Dados { get; set; }
}
