using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using PostgreEF.Domain.Model;

namespace PostgreEF.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Company>()
                .HasMany(i => i.Users)
                .WithOne(i => i.Company)
                .HasForeignKey(i => i.CompanyId)
                .HasPrincipalKey(i => i.Id);    
        }

        protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
        {
            configurationBuilder
                .Properties<DateTimeOffset>()
                .HaveConversion<DateTimeOffsetConverter>();
        }

        public DbSet<Company> Companies { get; set; }
        public DbSet<User> Users { get; set; }

    }
}
