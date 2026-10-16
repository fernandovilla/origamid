using System;
using System.Collections.Generic;
using System.Text;

namespace Gestao.Domain.Model.Users
{
    public enum UserAccessRuleEnum
    {
        Limited = 0,
        Collaborator = 1,
        Admin = 999
    }
    public class UserAccessRule
    {
        public Guid Id { get; set; }
        public UserAccessRuleEnum Rule { get; set; } = UserAccessRuleEnum.Limited;
        public bool Active { get; set; } = true;
        public UserCredential Credential { get; set; }
    }
}
