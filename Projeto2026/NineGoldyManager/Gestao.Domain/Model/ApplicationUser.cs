using Gestao.Domain.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace Gestao.Domain.Model
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationUser : IdentityUser, IStatusManager
    {
        public StatusEnum Status { get; set; } = StatusEnum.Normal;
        public DateTimeOffset CreatedAt { get; set; }
        public DateTimeOffset? DeletedAt { get; set; }
        public DateTimeOffset? UpdatedAt { get; set; }
    }

}
