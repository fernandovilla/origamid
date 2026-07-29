using System;
using System.Collections.Generic;
using System.Text;

namespace Gestao.Domain.Model
{
    public class Account
    {
        public int Id { get; set; }
        public string Description { get; set; } = string.Empty;
        public decimal Balance { get; set; } = 0m;          //saldo
        public DateTimeOffset BalanceDate { get; set; }
        public int? CompanyId { get; set; }
        public Company? Company { get; set; }
        public DateTimeOffset CreateAt { get; set; }
    }
}
