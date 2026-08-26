using FluentValidation;
using Gestao.Domain.Interfaces;
using System.ComponentModel.DataAnnotations;
using System.Security.AccessControl;

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
        public ICollection<Document>? Documents { get; set; } = new List<Document>();

        public StatusEnum Status { get; set; } = StatusEnum.Normal;
        public DateTimeOffset CreatedAt { get; set; }
        public DateTimeOffset? DeletedAt { get; set; }
        public DateTimeOffset? UpdatedAt { get; set; }
    }

    public class FinancialTransactionValidator : AbstractValidator<FinancialTransaction>
    {
        public FinancialTransactionValidator()
        {
            RuleFor(i => i.Description)
                .NotEmpty().WithMessage("Dsecrição é obrigatória")
                .Length(3, 200).WithMessage("Descrição deve ter entre {MinLength} e {MaxLength} caracteres");

            RuleFor(i => i.CategoryId)
                .Custom((category, context) =>
                {
                    if (!context.InstanceToValidate.AmountPaid.HasValue)
                        return;

                    if ((!category.HasValue || category.Value == 0) && context.InstanceToValidate.AmountPaid.Value > 0)
                        context.AddFailure(new FluentValidation.Results.ValidationFailure(nameof(FinancialTransaction.CategoryId), "Categoria é obrigadória quando Valor Pago informado"));
                });

            RuleFor(i => i.AccountId)
                .Custom((account, context) =>
                {
                    if (!context.InstanceToValidate.AmountPaid.HasValue)
                        return;

                    if (!account.HasValue && context.InstanceToValidate.AmountPaid.Value > 0)
                        context.AddFailure(new FluentValidation.Results.ValidationFailure(nameof(FinancialTransaction.AccountId), "Conta é obrigadória quando Valor Pago informado"));
                });


            RuleFor(i => i.ReferenceDate)
                .NotNull().WithMessage("Data Competência é obrigatória")
                .InclusiveBetween(DateTime.Now.AddYears(-1), DateTime.Now.AddYears(10))
                .WithMessage("A data deve estar entre '01/01/2025' e '01/01/2036'");


            RuleFor(i => i.RepeatTimes)
                .Custom((repeatTimes, context) =>
                {
                    if (context.InstanceToValidate.Repeat != RecurrentEnum.None && (repeatTimes == null || (repeatTimes != null && repeatTimes == 0)))
                        context.AddFailure(new FluentValidation.Results.ValidationFailure(nameof(FinancialTransaction.RepeatTimes), "'Vezes' é obrigadório"));
                });


            RuleFor(i => i.Amount)
                .LessThan(999999999999.99m).WithMessage("Valor deve ser menor que '999.999.999.999,99'")
                .GreaterThan(-1).WithMessage("Valor não deve ser negativo")
                .Custom((amound, context) =>
                {
                    if (!amound.HasValue || !context.InstanceToValidate.AmountPaid.HasValue)
                        return;

                    if (amound.Value == 0 && context.InstanceToValidate.AmountPaid.Value > 0)
                        context.AddFailure(new FluentValidation.Results.ValidationFailure(nameof(FinancialTransaction.Amount), "Valor da conta é obrigadório quando Valor Pago informado"));
                });


            RuleFor(i => i.AmountPaid)
                .LessThan(999999999999.99m).WithMessage("Valor deve ser menor que '999.999.999.999,99'")
                .GreaterThan(-1).WithMessage("Valor não deve ser negativo")
                .Custom((amountPaid, context) =>
                {
                    if (!amountPaid.HasValue)
                        return;

                    var total = 0m;

                    if (context.InstanceToValidate.Amount.HasValue)
                        total += context.InstanceToValidate.Amount.Value;

                    if (context.InstanceToValidate.Discounts.HasValue)
                        total -= context.InstanceToValidate.Discounts.Value;

                    if (context.InstanceToValidate.InterestPenalty.HasValue)
                        total += context.InstanceToValidate.InterestPenalty.Value;

                    if (total != amountPaid.Value)
                        context.AddFailure(new FluentValidation.Results.ValidationFailure(nameof(FinancialTransaction.AmountPaid), "Valor Pago é inválido. Valor Pago = Valor - Descontos + Juros/Multa"));
                });


            RuleFor(i => i.Discounts)
                .GreaterThan(-1).WithMessage("Valor não deve ser negativo")
                .Custom((discount, context) =>
                {
                    if (!discount.HasValue)
                        return;

                    if (context.InstanceToValidate.Amount.HasValue)
                    {
                        if (discount >= context.InstanceToValidate.Amount.Value)
                            context.AddFailure(new FluentValidation.Results.ValidationFailure(nameof(FinancialTransaction.Discounts), "Desconto deve ser menor que o Valor da conta"));
                    }
                });


            RuleFor(i => i.InterestPenalty)
                .LessThan(999999999999.99m).WithMessage("Valor deve ser menor que '999.999.999.999,99'")
                .GreaterThan(-1).WithMessage("Valor não deve ser negativo");


            RuleFor(i => i.PaymentDate)
                .InclusiveBetween(DateTime.Now.AddYears(-1), DateTime.Now.AddYears(10))
                .WithMessage("A data deve estar entre '01/01/2025' e '01/01/2036'")
                .Custom((paymentDate, context) =>
                {
                    if (!context.InstanceToValidate.AmountPaid.HasValue)
                        return;

                    if (context.InstanceToValidate.AmountPaid.Value == 0)
                        return;

                    if (!paymentDate.HasValue)
                        context.AddFailure(new FluentValidation.Results.ValidationFailure(nameof(FinancialTransaction.PaymentDate), "Data de Pagamento é obrigadória quando Valor Pago informado"));
                });

            RuleFor(i => i.DueDate)
                .InclusiveBetween(DateTime.Now.AddYears(-1), DateTime.Now.AddYears(10))
                .WithMessage("A data deve estar entre '01/01/2025' e '01/01/2036'");
        }
    }
}
