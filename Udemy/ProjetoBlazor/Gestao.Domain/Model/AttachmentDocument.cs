using System;
using System.Collections.Generic;
using System.Text;

namespace Gestao.Domain.Model
{
    public class AttachmentDocument
    {
        public int ID { get; set; }
        public string Path { get; set; } = null!;        //wwwroot/files/financialtransactions/{id}/{filename}
        public DateTimeOffset CreatedAt { get; set; }

        public int? FinancialTrsnsactionId { get; set; }
        public FinancialTransaction? FinancialTransaction { get; set; }
    }
}
