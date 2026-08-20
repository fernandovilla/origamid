using Gestao.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Gestao.Domain.Model
{
    public class Document : IStatusManager
    {
        public int ID { get; set; }
        public string Path { get; set; } = null!;        //wwwroot/files/financialtransactions/{id}/{filename}
                                                         //
        public int? FinancialTransactionId { get; set; }
        public FinancialTransaction? FinancialTransaction { get; set; }

        public StatusEnum Status { get; set; } = StatusEnum.Normal;
        public DateTimeOffset CreatedAt { get; set; }
        public DateTimeOffset? DeletedAt { get; set; }
        public DateTimeOffset? UpdatedAt { get; set; }
    }
}
