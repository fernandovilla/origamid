using Microsoft.EntityFrameworkCore;
using AgendaBolo.Domain.Model.UnidadesMedida;
using AgendaBolo.Domain.Model.Ingredientes;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace AgendaBolo.Domain.Database
{
    public partial class ApplicationDbContext : DbContext
    {
        public DbSet<UnidadeMedidaDTA> UnidadeMedidas { get; set; }
        public DbSet<IngredienteDTA> Ingredientes { get; set; }
        public DbSet<EmbalagemDTA> EmbalagensIngredientes { get; set; }
        public DbSet<EstoqueDTA> EstoqueIngredientes { get; set; }


        

    }

    partial class ApplicationDbContext
    {
        private readonly string _connectionString;

        public ApplicationDbContext(string connectionString)
        {
            _connectionString = connectionString;
        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            if (!optionsBuilder.IsConfigured)
                optionsBuilder.UseNpgsql(_connectionString, null);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //modelBuilder.Entity<IngredienteDTA>()
            //    .HasKey(i => i.Id);

            //modelBuilder.Entity<IngredienteDTA>()
            //    .HasMany(i => i.Embalagens)
            //    .WithOne(i => i.Ingrediente)
            //    .HasForeignKey(i => i.IdIngrediente);
        }

    }
}
