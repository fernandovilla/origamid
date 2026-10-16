using System;
using System.Collections.Generic;
using System.Security.AccessControl;
using System.Text;

namespace Gestao.Domain.Model.Users
{
    public class UserCredential
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public Guid AccessRuleId { get; set; }
        public virtual string? PasswordHash { get; set; }
        public virtual string? SecurityStamp { get; set; }
        public virtual string? ConcurrencyStamp { get; set; } = Guid.NewGuid().ToString();        
        
        public User User { get; set; }
        public UserAccessRule AccessRule { get; set; }
    }
}
