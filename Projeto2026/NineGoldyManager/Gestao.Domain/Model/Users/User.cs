using Gestao.Domain.Interfaces;
using Gestao.Domain.Model.Companies;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Gestao.Domain.Model.Users
{
    public class User : IStatusManager
    {
        public Guid Id { get; set; }

        [ProtectedPersonalData]
        public string? UserName { get; set; }
        public string? NormalizedUserName => UserName.Trim().ToUpper();
        [ProtectedPersonalData]
        public string? Email { get; set; }
        public string? NormalizedEmail => Email.Trim().ToUpper();
        [PersonalData]
        public bool EmailConfirmed { get; set; }        
        [ProtectedPersonalData]
        public string? PhoneNumber { get; set; }
        [PersonalData]
        public bool PhoneNumberConfirmed { get; set; }
        [PersonalData]
        public bool TwoFactorEnabled { get; set; }
        public DateTimeOffset? LockoutEnd { get; set; }
        public bool LockoutEnabled { get; set; }
        public int AccessFailedCount { get; set; }

        public Company Company { get; set; }
        public Guid CompanyId { get; set; }

        public UserCredential Credential { get; set; }

        public StatusEnum Status { get; set; } = StatusEnum.Normal;
        public DateTimeOffset CreatedAt { get; set; } = DateTimeOffset.Now;
        public DateTimeOffset? UpdatedAt { get; set; } = null;
        public DateTimeOffset? DeletedAt { get; set; } = null;
    }
}
