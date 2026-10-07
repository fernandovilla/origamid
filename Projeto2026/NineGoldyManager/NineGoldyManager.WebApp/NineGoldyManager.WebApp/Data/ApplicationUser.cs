using Microsoft.AspNetCore.Identity;
using NGManager.WebApp.Model;

namespace NGManager.WebApp.Data
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationUser : IdentityUser, IStatusManager
    {
        public StatusCadastro Status { get; set; } = StatusCadastro.Normal;
        public DateTimeOffset CreatedAt { get; set; } = DateTimeOffset.Now;
        public DateTimeOffset? UpdatedAt { get; set; } = null;
        public DateTimeOffset? DeletedAt { get; set; } = null;
    }

}
