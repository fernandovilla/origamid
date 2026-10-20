using FluentValidation;
using Gestao.Domain.Interfaces;
using Gestao.Domain.Model.Companies;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Text;

namespace Gestao.Domain.Model.Customers
{
    public class Customer : IStatusManager
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Document { get; set; } = string.Empty;
        public DateTime? BirthDate { get; set; }
        public string ZipCode { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string State { get; set; } = string.Empty;
        public string Country { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public string Whatsapp { get; set; } = string.Empty;
        public string Telegram { get; set; } = string.Empty;
        public string Facebook { get; set; } = string.Empty;
        public string Instagram { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Obs { get; set; } = string.Empty;

        public int? CompanyId { get; set; } = null;
        public Company? Company { get; set; } = null;

        public StatusEnum Status { get; set; } = StatusEnum.Normal;
        public DateTimeOffset CreatedAt { get; set; } = DateTimeOffset.Now;
        public DateTimeOffset? UpdatedAt { get; set; } = null;
        public DateTimeOffset? DeletedAt { get; set; } = null;
    }

    public class ClientValidator : AbstractValidator<Customer>
    {
        public ClientValidator()
        {
            RuleFor(i => i.Name)
                .NotEmpty()
                .Length(3, 100).WithMessage("Nome do cliente deve ter entre 3 e 100 caracteres");
        }
    }
}
