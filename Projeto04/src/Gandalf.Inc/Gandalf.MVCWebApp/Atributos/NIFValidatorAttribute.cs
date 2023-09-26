using Gandalf.MVCWebApp.Models;
using Humanizer.Localisation;
using System.ComponentModel.DataAnnotations;

namespace Gandalf.MVCWebApp.Atributos
{
    public class NIFValidatorAttribute : ValidationAttribute
    {
        public NIFValidatorAttribute()
        {
                
        }
        public NIFValidatorAttribute(string nif) => NIF = nif;

        public string NIF { get; }

        public string GetErrorMessage() => $"Nif Inválido.";

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var cliente = (Customer)validationContext.ObjectInstance;
            
            if (cliente.NumeroIdentificacaoFiscal.Length != 9) //Aqui entra a matemática...
            {
                return new ValidationResult(GetErrorMessage());
            }

            return ValidationResult.Success;
        }
    }
}
