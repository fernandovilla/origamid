using Gestao.App.Data.Interceptors;
using Gestao.Domain.Model.Users;
using Gestao.Domain.Model.Companies;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Gestao.Domain.Model;
using Gestao.Domain.Model.Customers;
using Gestao.App.Data.Converters;

namespace Gestao.App.Data
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : IdentityDbContext<ApplicationUser>(options)    
    {
        public DbSet<Company> Companies { get; set; }
        public DbSet<Customer> Customers { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // Sempre salva a coluna 'Repeat' com o texto do enum
            //builder.Entity<FinancialTransaction>()
            //     .Property(p => p.Repeat)
            //    .HasConversion<string>();

            //// Sempre salva a coluna 'FinancialTransactionType' com o texto do enum
            //builder.Entity<FinancialTransaction>()
            //     .Property(p => p.FinancialTransactionType)
            //    .HasConversion<string>();


            /* Define o modelo delete cascade */
            //builder.Entity<Company>()
            //    .HasMany(c => c.Accounts)
            //    .WithOne(c => c.Company)
            //    .OnDelete(DeleteBehavior.Cascade);



            /* Define o CNPJ seja único */
            //builder.Entity<Company>()
            //    .HasIndex(i => i.TaxId)
            //    .IsUnique();

            //builder.Entity<User>()
            //    .HasOne(i => i.Credential)
            //    .WithOne(i => i.User)
            //    .HasForeignKey<UserCredential>(i => i.UserId);

            //builder.Entity<UserAccessRule>()
            //    .HasOne(i => i.Credential)
            //    .WithOne(i => i.AccessRule)
            //    .HasForeignKey<UserCredential>(i => i.AccessRuleId);


            builder.Entity<ApplicationUser>()
                .HasOne(i => i.Company)
                .WithMany(i => i.Users);

            builder.Entity<Customer>()
                .HasOne(i => i.Company)
                .WithMany(i => i.Customers);


            //builder.Entity<Account>().HasQueryFilter(a => a.Status != Domain.Interfaces.StatusEnum.Deleted);
            //builder.Entity<Category>().HasQueryFilter(a => a.Status != Domain.Interfaces.StatusEnum.Deleted);
            //builder.Entity<FinancialTransaction>().HasQueryFilter(a => a.Status != Domain.Interfaces.StatusEnum.Deleted);
            //builder.Entity<User>().HasQueryFilter(a => a.Status != Domain.Interfaces.StatusEnum.Deleted);

            builder.Entity<ApplicationUser>().HasQueryFilter(a => a.Status != Domain.Interfaces.StatusEnum.Deleted);
            builder.Entity<Company>().HasQueryFilter(a => a.Status != Domain.Interfaces.StatusEnum.Deleted);
            builder.Entity<Customer>().HasQueryFilter(a => a.Status != Domain.Interfaces.StatusEnum.Deleted);

            
            //builder.Entity<Document>().HasQueryFilter(a => a.Status != Domain.Interfaces.StatusEnum.Deleted);            
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.AddInterceptors(new StatusManagerInterceptor());
        }

        protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
        {
            configurationBuilder.Properties<DateTime>().HaveConversion<UtcDatetimeConverter>();
            configurationBuilder.Properties<DateTime?>().HaveConversion<NullableUtcDateTimeConverter>();
        }
    }
}
