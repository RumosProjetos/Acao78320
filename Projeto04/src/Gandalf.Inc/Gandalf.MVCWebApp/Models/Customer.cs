using Gandalf.MVCWebApp.Atributos;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Gandalf.MVCWebApp.Models;

public partial class Customer
{
    public int CustomerId { get; set; }


    [Required]
    [MaxLength(150)]
    public string Nome { get; set; } = null!;

    public string? Endereco { get; set; }

    public string? Cidade { get; set; }


    [MaxLength(255)]
    [EmailAddress]
    public string? Email { get; set; }

    //[Required(ErrorMessage = "Ops, o NIF é obrigatório")]
    //[RegularExpression(@"\d{9}", ErrorMessage = "NIF inválido")]
    [Display(Name = "Número de Identificação Fiscal")]

    [NIFValidator]
    public string NumeroIdentificacaoFiscal { get; set; } = null!;


    [Display(Name = "Data de Nascimento")]
    public DateTime DataNascimento { get; set; }

    public virtual ICollection<Venda> Venda { get; set; } = new List<Venda>();
}
