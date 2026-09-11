using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PostgreEF.Domain.Model
{
    public class Company : IStatus
    {
        

        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public StatusEnum Status { get; set; } = StatusEnum.Normal;
        public DateTimeOffset CreatedAt { get; set; } = DateTimeOffset.Now;
        public DateTimeOffset? UpdatedAt { get; set; } = null;
        public DateTimeOffset? DeletedAt { get; set; } = null;
        
        public ICollection<User> Users { get; set; } = new List<User>();
    }
}
