using FluentValidation;
using Gestao.Domain.Interfaces;
using Gestao.Domain.Libraries.Validations;
using System.ComponentModel.DataAnnotations;
using System.Numerics;

//Utilizar o fluentvalidation para uma limpeza melhor do código
//https://docs.fluentvalidation.net/en/latest/

namespace Gestao.Domain.Model
{
    public class Company : IStatusManager
    {    
        public int Id { get; set; }
        public string LegalName { get; set; } = string.Empty;        
        public string TradeName { get; set; } = string.Empty;
        public string TaxId { get; set; } = string.Empty;
        public string PostalCode { get; set; } = string.Empty;        
        public string State { get; set; } = string.Empty;        
        public string City { get; set; } = string.Empty;        
        public string Neighboarhood { get; set; } = string.Empty;        
        public string Address { get; set; } = string.Empty;
        public string Complement { get; set; } = string.Empty;
        
        
        public Guid UserId { get; set; }
        public ApplicationUser User { get; set; } = null!;
        public ICollection<Account>? Accounts { get; set; }
        public ICollection<Category>? Categories { get; set; }
        public ICollection<FinancialTransaction>? FinancialTransactions { get; set; }

        public StatusEnum Status { get; set; } = StatusEnum.Normal;
        public DateTimeOffset CreatedAt { get; set; } = DateTime.Now; //DataHora Local + Fuso-horário
        public DateTimeOffset? UpdatedAt { get; set; } = null;
        public DateTimeOffset? DeletedAt { get; set; } = null;
    }

    public class CompanyValidator : AbstractValidator<Company>
    {
        public CompanyValidator()
        {
            RuleFor(i => i.LegalName)
                .NotEmpty().WithMessage("Razão Social é obrigatório")
                .Length(3, 100).WithMessage("Razão Social deve ter entre {MinLength} e {MaxLength} caracteres");

            RuleFor(i => i.TradeName)
                .NotEmpty().WithMessage("Nome Fantasia é obrigatório")
                .Length(3, 100).WithMessage("Nome Fantasia deve ter entre {MinLength} e {MaxLength} caracteres");

            RuleFor(i => i.TaxId)
                .NotEmpty().WithMessage("CNPJ é obrigatório")
                .Must(x => CNPJValido(x)).WithMessage("CNPJ é inválido");                
        }

        private bool CNPJValido(string cnpj)
        {
            var cnpjAttrib = new CNPJAttribute();
            return cnpjAttrib.IsValid(cnpj);
        }
    }
}
