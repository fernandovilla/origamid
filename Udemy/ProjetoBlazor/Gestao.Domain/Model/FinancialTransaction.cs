using Gestao.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Gestao.Domain.Model
{
    public enum RecurrentEnum
    {
        None,
        Weekly,
        Monthly,
        Yearly
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
        public decimal Amount { get; set; } = 0m;
        public RecurrentEnum Repeat { get; set; } = RecurrentEnum.None;
        public int RepeatTimes { get; set; } = 0;
        public decimal InterestPenalty { get; set; }        //Juros/Multa
        public decimal Discounts { get; set; } = 0;
        public DateTimeOffset PaymentDate { get; set; }
        public decimal AmountPaid { get; set; }        
        public int CompanyId { get; set; }
        public Company Company { get; set; } = null!;
        public int AccountId { get; set; }
        public Account? Account { get; set; } = null!;
        public int? CategoryId { get; set; }        
        public Category? Category { get; set; }
        public ICollection<Document>? Documents { get; set; } = null;

        public StatusEnum Status { get; set; } = StatusEnum.Normal;
        public DateTimeOffset CreatedAt { get; set; }
        public DateTimeOffset? DeletedAt { get; set; }
        public DateTimeOffset? UpdatedAt { get; set; }
    }
}
