using FluentValidation;
using Gestao.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Gestao.Domain.Model
{
    public enum RecurrentEnum
    {
        [Display(Name = "Não")] None,
        [Display(Name = "Semanal")] Weekly,
        [Display(Name = "Mensal")] Monthly,
        [Display(Name = "Anual")] Yearly
    }

    public enum FinancialTransactionTypeEnum
    {
        Pay,
        Receive
    }

    public class FinancialTransaction : IStatusManager
    {
        public int Id { get; set; }
        public FinancialTransactionTypeEnum FinancialTransactionType { get; set; }
        public string Description { get; set; } = string.Empty;
        public string? Observation { get; set; } = null;
        public DateTimeOffset ReferenceDate { get; set; }
        public DateTimeOffset DueDate { get; set; }         //Vencimento
        public decimal? Amount { get; set; }
        public RecurrentEnum Repeat { get; set; } = RecurrentEnum.None;
        public int? RepeatTimes { get; set; }
        public decimal? InterestPenalty { get; set; }        //Juros/Multa
        public decimal? Discounts { get; set; } = 0;
        public DateTimeOffset? PaymentDate { get; set; }
        public decimal? AmountPaid { get; set; }
        public int CompanyId { get; set; }
        public Company Company { get; set; } = null!;
        public int? AccountId { get; set; }
        public Account? Account { get; set; } = null!;
        public int? CategoryId { get; set; }
        public Category? Category { get; set; }
        public ICollection<Document>? Documents { get; set; } = null;

        public StatusEnum Status { get; set; } = StatusEnum.Normal;
        public DateTimeOffset CreatedAt { get; set; }
        public DateTimeOffset? DeletedAt { get; set; }
        public DateTimeOffset? UpdatedAt { get; set; }
    }

    public class FinancialTransactionValidaor : AbstractValidator<FinancialTransaction>
    {
        public FinancialTransactionValidaor()
        {
            RuleFor(i => i.Description)
                .NotEmpty().WithMessage("Dsecrição é obrigatória")
                .Length(3, 200).WithMessage("Descrição deve ter entre {MinLength} e {MaxLength} caracteres");

            RuleFor(i => i.ReferenceDate)
                .NotNull().WithMessage("Data Competência é obrigatória");


                

        }
    }
}
