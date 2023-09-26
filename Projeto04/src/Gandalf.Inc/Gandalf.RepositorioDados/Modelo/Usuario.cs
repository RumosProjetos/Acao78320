using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Gandalf.RepositorioDados.Modelo
{
    public class Usuario : Pessoa
    {
        [Key]
        [DatabaseGenerated(databaseGeneratedOption: DatabaseGeneratedOption.Identity)]
        [DisplayName("POSUserID")]
        public override int Id { get; set; }

        [Required]
        [MaxLength(60, ErrorMessage = "Nome muito grande")]
        [DisplayName("POS User Name")]
        public override string Nome { get; set; }

        
        [MaxLength(120)]
        public override string Endereco { get; set; }

        [MaxLength(50)]
        public override string Cidade { get; set; }

        [MaxLength(120), EmailAddress] //É possível concatenar attributos
        public override string Email { get; set; }

        [MaxLength(9), RegularExpression(@"\d+[9]")]
        [Required(ErrorMessage = "Campo Obrigatório")]
        public string Telefone { get; set; }

        [Required]
        [MaxLength(15)]
        public string NomeUsuario { get; set; }

        [PasswordPropertyText]
        public string Password { get; set; }
        public int Numero { get; set; }

        public virtual List<Venda> Vendas { get; set; }             
    }
}
