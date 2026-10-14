using Gestao.Domain.Interfaces;
using Gestao.Domain.Model.Companies;
using Microsoft.AspNetCore.Identity;

namespace Gestao.Domain.Model.Users
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationUser : IdentityUser, IStatusManager
    {
        public Guid CompanyId { get; set; }
        public Company Company { get; set; }

        public StatusEnum Status { get; set; } = StatusEnum.Normal;
        public DateTimeOffset CreatedAt { get; set; }
        public DateTimeOffset? DeletedAt { get; set; }
        public DateTimeOffset? UpdatedAt { get; set; }
    }

}
