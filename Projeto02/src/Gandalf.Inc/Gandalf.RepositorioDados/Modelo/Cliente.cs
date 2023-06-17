using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Gandalf.RepositorioDados.Modelo
{
    [Table("Customer")] //Caso precise mapear tabela com nome estranho, posso usar atributos
    public class Cliente : Pessoa
    {
        [Key]
        [DatabaseGenerated(databaseGeneratedOption: DatabaseGeneratedOption.Identity)]
        [DisplayName("CustomerId")]
        [Column("CustomerId")]//Caso precise mapear campo com nome estranho, posso usar atributos
        public override int Id { get; set; }

        [Required]
        [MaxLength(60)]
        [DisplayName("Customer Name")]
        public override string Nome { get; set; }

        [MaxLength(120)]
        public override string Endereco { get; set; }

        [MaxLength(50)]
        public override string Cidade { get; set; }

        [MaxLength(120), EmailAddress] //É possível concatenar attributos
        public override string Email { get; set; }

        [MaxLength(9)] 
        [RegularExpression(@"\d+[9]", ErrorMessage = "NIF inválido")]
        [Required(ErrorMessage = "Ops, o NIF é obrigatório")]
        public string NumeroIdentificacaoFiscal { get; set; }

        public virtual List<Venda> Vendas { get; set; }
    }
}
