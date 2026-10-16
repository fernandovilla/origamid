using FluentValidation;
using Gestao.Domain.Interfaces;
using Gestao.Domain.Libraries.Validations;
using Gestao.Domain.Model.Clients;
using Gestao.Domain.Model.Users;
using System.ComponentModel.DataAnnotations;
using System.Numerics;

//Utilizar o fluentvalidation para uma limpeza melhor do código
//https://docs.fluentvalidation.net/en/latest/

namespace Gestao.Domain.Model.Companies
{
    public class Company : IStatusManager
    {    
        public Guid Id { get; set; }        
        public string? LegalName { get; set; } 
        public string? TradeName { get; set; } 
        public string? TaxId { get; set; } 
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; } 
        public string? CellPhoneNumber { get; set; }
        public string? PostalCode { get; set; } 
        public string? State { get; set; } 
        public string? City { get; set; } 
        public string? Neighboarhood { get; set; } 
        public string? Address { get; set; } 
        public string? Complement { get; set; } 
        public StatusEnum Status { get; set; } = StatusEnum.Normal;
        public DateTimeOffset CreatedAt { get; set; } = DateTimeOffset.Now; 
        public DateTimeOffset? UpdatedAt { get; set; } = null;
        public DateTimeOffset? DeletedAt { get; set; } = null;


        public ICollection<ApplicationUser>? Users { get; set; }
        public ICollection<Cliente>? Clients { get; set; }
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
