using Gestao.App.Data.Interceptors;
using Gestao.Domain.Model;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Gestao.App.Data
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) 
        : IdentityDbContext<ApplicationUser>(options)
    {
        public DbSet<Company> Companies { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<FinancialTransaction> FinancialTransactions { get; set; }
        public DbSet<Document> Documents { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // Sempre salva a coluna 'Repeat' com o texto do enum
            builder.Entity<FinancialTransaction>()
                 .Property(p => p.Repeat)
                .HasConversion<string>();
            
            // Sempre salva a coluna 'FinancialTransactionType' com o texto do enum
            builder.Entity<FinancialTransaction>()
                 .Property(p => p.FinancialTransactionType)
                .HasConversion<string>();


            /* Define o modelo delete cascade */
            //builder.Entity<Company>()
            //    .HasMany(c => c.Accounts)
            //    .WithOne(c => c.Company)
            //    .OnDelete(DeleteBehavior.Cascade);


            /* Define o CNPJ seja único */
            builder.Entity<Company>()
                .HasIndex(i => i.TaxId)
                .IsUnique();

            builder.Entity<Account>().HasQueryFilter(a => a.Status != Domain.Interfaces.StatusEnum.Deleted);
            builder.Entity<ApplicationUser>().HasQueryFilter(a => a.Status != Domain.Interfaces.StatusEnum.Deleted);            
            builder.Entity<Category>().HasQueryFilter(a => a.Status != Domain.Interfaces.StatusEnum.Deleted);
            builder.Entity<Company>().HasQueryFilter(a => a.Status != Domain.Interfaces.StatusEnum.Deleted);
            builder.Entity<Document>().HasQueryFilter(a => a.Status != Domain.Interfaces.StatusEnum.Deleted);
            builder.Entity<FinancialTransaction>().HasQueryFilter(a => a.Status != Domain.Interfaces.StatusEnum.Deleted);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //base.OnConfiguring(optionsBuilder);
            optionsBuilder.AddInterceptors(new StatusManagerInterceptor());
        }
    }
}
