using FluentValidation;
using Gestao.Domain.Interfaces;
using Gestao.Domain.Model.Companies;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Globalization;
using System.Text;

namespace Gestao.Domain.Model.Customers
{
    public enum TipoPessoaEnum
    {
        [Display(Name="Pessoa Física")] PessoaFisica = 1,
        [Display(Name = "Pessoa Jurídica")] PessoaJuridica = 2
    }

    public class Customer : IStatusManager
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public TipoPessoaEnum TipoPessoa { get; set; } = TipoPessoaEnum.PessoaFisica;
        public string Document { get; set; } = string.Empty;
        public DateTime? BirthDate { get; set; }
        public string ZipCode { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string NumberAddress { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string Neighboarhood { get; set; } = string.Empty;
        public string State { get; set; } = string.Empty;
        public string Country { get; set; } = string.Empty;
        public string Complement { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public string CellPhoneNumber { get; set; } = string.Empty;
        public string Whatsapp { get; set; } = string.Empty;
        public string Telegram { get; set; } = string.Empty;
        public string Facebook { get; set; } = string.Empty;
        public string Instagram { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Obs { get; set; } = string.Empty;

        public Guid? CompanyId { get; set; } = null;
        public Company? Company { get; set; } = null;

        public StatusEnum Status { get; set; } = StatusEnum.Normal;
        public DateTimeOffset CreatedAt { get; set; } = DateTimeOffset.Now;
        public DateTimeOffset? UpdatedAt { get; set; } = null;
        public DateTimeOffset? DeletedAt { get; set; } = null;
    }

    public class CustomerValidator : AbstractValidator<Customer>
    {
        public CustomerValidator()
        {
            RuleFor(i => i.Name)
                .NotEmpty().WithMessage("Nome é obrigatório")
                .Length(3, 100).WithMessage("Nome do cliente deve ter entre 3 e 100 caracteres");
        }
    }
}
