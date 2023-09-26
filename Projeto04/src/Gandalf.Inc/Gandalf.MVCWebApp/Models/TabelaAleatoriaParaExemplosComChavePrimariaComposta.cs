using System;
using System.Collections.Generic;

namespace Gandalf.MVCWebApp.Models;

public partial class TabelaAleatoriaParaExemplosComChavePrimariaComposta
{
    public int ChavePrimariaPart01 { get; set; }

    public DateTime ChavePrimariaPart02 { get; set; }

    public string? Dados { get; set; }
}
