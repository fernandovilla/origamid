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
        public decimal Balance { get; set; } = 0m;          //saldo
        public DateTimeOffset BalanceDate { get; set; }
        public int? CompanyId { get; set; }
        public Company? Company { get; set; }

        public StatusEnum Status { get; set; } = StatusEnum.Normal;
        public DateTimeOffset CreatedAt { get; set; }
        public DateTimeOffset? DeletedAt { get; set; }
        public DateTimeOffset? UpdatedAt { get; set; }
    }
}
