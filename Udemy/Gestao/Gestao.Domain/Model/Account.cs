using FluentValidation;
using Gestao.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Gestao.Domain.Model
{
    public class Account : IStatusManager
    {
        public int Id { get; set; }
        public string Description { get; set; } = string.Empty;
        public decimal Balance { get; set; }           //saldo
        public DateTimeOffset BalanceDate { get; set; } = DateTimeOffset.Now;
        public int? CompanyId { get; set; }
        public Company? Company { get; set; }

        public StatusEnum Status { get; set; } = StatusEnum.Normal;
        public DateTimeOffset CreatedAt { get; set; }
        public DateTimeOffset? DeletedAt { get; set; }
        public DateTimeOffset? UpdatedAt { get; set; }

        public ICollection<FinancialTransaction>? FinancialTransactions { get; set; }
    }

    public class AccountValidador : AbstractValidator<Account>
    {
        public AccountValidador()
        {
            RuleFor(i => i.Description)
                .NotEmpty().WithMessage("Descrição é obrigatória")
                .Length(3, 100).WithMessage("Descrição deve ter entre {MinLength} e {MaxLength} caracteres");

            RuleFor(i => i.Balance)
                .NotEmpty().WithMessage("Saldo inicial é obrigatório")
                .NotNull().WithMessage("Saldo inicial é obrigatório");

            RuleFor(i => i.BalanceDate)
                .NotEqual(DateTimeOffset.MinValue).WithMessage("Data inicial do saldo é obrigatória")
                .NotEmpty().WithMessage("Data inicial do saldo é obrigatória");
        }
    }
}
