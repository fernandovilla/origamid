using Microsoft.EntityFrameworkCore;
using Ninegoldy.Models.Companies;
using Ninegoldy.Models.Users;
using System.Data;

namespace Ninegoldy.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) 
            : base(options)
        { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.AddInterceptors(new Interceptors.StatusManagerInterceptor());
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<UserDTO>()
                .HasMany(u => u.Empresas)
                .WithMany(c => c.Usuarios)
                .UsingEntity<Dictionary<string, object>>(
                    "UserCompany",
                    j => j.HasOne<CompanyDTO>().WithMany().HasForeignKey("CompanyId"),
                    j => j.HasOne<UserDTO>().WithMany().HasForeignKey("UserId")
                );

            modelBuilder.Entity<CompanyDTO>()
                .HasMany(c => c.Usuarios)
                .WithMany(u => u.Empresas)
                .UsingEntity<Dictionary<string, object>>(
                    "UserCompany",
                    j => j.HasOne<UserDTO>().WithMany().HasForeignKey("UserId"),
                    j => j.HasOne<CompanyDTO>().WithMany().HasForeignKey("CompanyId")
                );
        }

        public DbSet<UserDTO> Users { get; set; }
        public DbSet<CompanyDTO> Companies { get; set; }
    }
}
