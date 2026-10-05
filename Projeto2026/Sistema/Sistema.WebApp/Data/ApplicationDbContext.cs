using Microsoft.EntityFrameworkCore;
using Ninegoldy.Models.Companies;
using Ninegoldy.Models.Users;

namespace Ninegoldy.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) 
            : base(options)
        { }

        public DbSet<UserDTO> Users { get; set; }
        public DbSet<CompanyDTO> Companies { get; set; }
    }
}
