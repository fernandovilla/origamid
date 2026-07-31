using System;
using System.Collections.Generic;
using System.Text;

namespace Gestao.Domain.Model
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public int? CompanyId { get; set; }
        public Company? Company { get; set; }
        public Guid UserId { get; set; }
    }
}
