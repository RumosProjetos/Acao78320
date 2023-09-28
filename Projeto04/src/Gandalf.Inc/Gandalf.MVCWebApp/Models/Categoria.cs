using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Gandalf.MVCWebApp.Models;

public partial class Categoria
{
    public int Id { get; set; }

    [Display(Name = "Categoria")]
    public string? Nome { get; set; }


    [Display(Name = "Produtos")]
    public virtual ICollection<Produto> Produtos { get; set; } = new List<Produto>();
}
