using Gestao.Domain.Libraries.Validations;
using System.ComponentModel.DataAnnotations;

//Utilizar o fluentvalidation para uma limpeza melhor do código
//https://docs.fluentvalidation.net/en/latest/

namespace Gestao.Domain.Model
{
    public class Company
    {    
        public int Id { get; set; }

        [Required(ErrorMessage = "Razão Social é obrigatório")]
        public string LegalName { get; set; } = string.Empty;
        
        [Required(ErrorMessage = "Nome Fantasia é obrigatório")]
        public string TradeName { get; set; } = string.Empty;

        [Required(ErrorMessage = "CNPJ é obrigatório")]
        [CNPJ(ErrorMessage ="CNPJ é inválido")]
        public string TaxId { get; set; } = string.Empty;

        public string PostalCode { get; set; } = string.Empty;        
        public string State { get; set; } = string.Empty;        
        public string City { get; set; } = string.Empty;        
        public string Neighboarhood { get; set; } = string.Empty;        
        public string Address { get; set; } = string.Empty;
        public string Complement { get; set; } = string.Empty;

        public DateTimeOffset CreatedAt { get; set; } = DateTime.Now; //DataHora Local + Fuso-horário
        public Guid UserId { get; set; }
        public ApplicationUser User { get; set; } = null!;

    }
}
