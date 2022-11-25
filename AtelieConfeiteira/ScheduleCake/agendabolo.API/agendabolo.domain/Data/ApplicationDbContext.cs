using Microsoft.EntityFrameworkCore;



namespace Agendabolo.Data
{
    public class ApplicationDbContext : DbContext
    {
        private readonly string _connectionString;

        //Classe de configuração
        public DbSet<Core.Fabricantes.Fabricante> Fabricantes { get; set; }
        public DbSet<Core.Ingredientes.Ingrediente> Ingredientes { get; set; }        
        public DbSet<Core.Receitas.Receita> Receitas { get; set; }
        public DbSet<Core.Receitas.IngredienteReceita> IngredientesReceitas { get; set; }

        public ApplicationDbContext(string connectionString)
        {
            _connectionString = connectionString;
        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            if (!optionsBuilder.IsConfigured)
                optionsBuilder.UseMySql(_connectionString);            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            modelBuilder.Entity<Core.Receitas.IngredienteReceita>()
                .HasKey(i => new { i.IdReceita, i.IdIngrediente });

            //https://www.entityframeworktutorial.net/efcore/configure-many-to-many-relationship-in-ef-core.aspx
            modelBuilder.Entity<Core.Receitas.IngredienteReceita>()
                .HasOne<Core.Receitas.Receita>(r => r.Receita)
                .WithMany(i => i.Ingredientes)
                .HasForeignKey(i => i.IdReceita);

            modelBuilder.Entity<Core.Receitas.IngredienteReceita>()
                .HasOne<Core.Ingredientes.Ingrediente>(i => i.Ingrediente)
                .WithMany(i => i.Receitas)
                .HasForeignKey(i => i.IdIngrediente);


            //modelBuilder.Entity<Core.Receitas.IngredienteReceita>()
            //    .HasOne(i => i.Receita)
            //    .WithMany(i => i.Ingredientes)
            //    .HasForeignKey(f => f.IdReceita);

            //modelBuilder.Entity<Core.Receitas.IngredienteReceita>()
            //    .HasOne(i => i.Ingrediente)
            //    .WithMany(i => i.Receitas)
            //    .HasForeignKey(f => f.IdIngrediente);    
        }
    }
}
