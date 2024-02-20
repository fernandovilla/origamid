using Microsoft.EntityFrameworkCore;



namespace Agendabolo.Data
{
    public class ApplicationDbContext : DbContext
    {
        private readonly string _connectionString;

        //Classe de configuração
        public DbSet<Core.Fabricantes.FabricanteDTA> Fabricantes { get; set; }
        public DbSet<Core.Ingredientes.UnidadeMedidaDTA> UnidadesMedidas { get; set; }
        public DbSet<Core.Ingredientes.IngredienteDTA> Ingredientes { get; set; }
        public DbSet<Core.Ingredientes.IngredienteEmbalagemDTA> IngredientesEmbalagens { get; set; }
        public DbSet<Core.Ingredientes.EstoqueDTA> Estoque { get; set; }
        public DbSet<Core.Receitas.ReceitaDTA> Receitas { get; set; }
        public DbSet<Core.Receitas.ReceitaIngredienteDTA> IngredientesReceitas { get; set; }
        public DbSet<Core.Produtos.ProdutoDTA> Produtos { get; set; }
        public DbSet<Core.Produtos.ProdutoReceitaDTA> ProdutosReceitas { get; set; }
        public DbSet<Core.Clientes.ClienteDTA> Clientes { get; set; }
        public DbSet<Core.Formas.FormaDTA> Formas { get; set; }
        


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
                optionsBuilder.UseMySql(_connectionString, ServerVersion.AutoDetect(_connectionString));

            optionsBuilder.EnableSensitiveDataLogging();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //https://www.entityframeworktutorial.net/efcore/configure-many-to-many-relationship-in-ef-core.aspx

            #region Ingredientes 
            modelBuilder.Entity<Core.Ingredientes.IngredienteDTA>()
                .HasKey(i => new { i.Id });

            //modelBuilder.Entity<Core.Ingredientes.UnidadeMedidaDTA>()
            //    .HasMany(i => i.Ingredientes)
            //    .WithOne(i => i.UnidadeMedida)
            //    .HasForeignKey(i => i.IdUnidadeMedida);

            modelBuilder.Entity<Core.Ingredientes.IngredienteDTA>()
                .HasMany(i => i.Estoque)
                .WithOne(i => i.Ingrediente)
                .HasForeignKey(i => i.IdIngrediente);

            modelBuilder.Entity<Core.Ingredientes.IngredienteDTA>()
                .HasMany(i => i.Embalagens)
                .WithOne(i => i.Ingredente)
                .HasForeignKey(i => i.IdIngrediente);

                                
            #endregion

            #region [Receitas]
            modelBuilder.Entity<Core.Receitas.ReceitaIngredienteDTA>()
                .HasKey(i => new { i.IdReceita, i.IdIngrediente });

            
            modelBuilder.Entity<Core.Receitas.ReceitaIngredienteDTA>()
                .HasOne<Core.Receitas.ReceitaDTA>(r => r.Receita)
                .WithMany(i => i.Ingredientes)
                .HasForeignKey(i => i.IdReceita);

            modelBuilder.Entity<Core.Receitas.ReceitaIngredienteDTA>()
                .HasOne<Core.Ingredientes.IngredienteDTA>(i => i.Ingrediente)
                .WithMany(i => i.Receitas)
                .HasForeignKey(i => i.IdIngrediente);
            #endregion

            #region [Produtos]
            modelBuilder.Entity<Core.Produtos.ProdutoReceitaDTA>()
                .HasKey(i => new { i.IdProduto, i.IdReceita });

            modelBuilder.Entity<Core.Produtos.ProdutoReceitaDTA>()
                .HasOne(i => i.Produto)
                .WithMany(i => i.Receitas)
                .HasForeignKey(i => i.IdProduto);

            modelBuilder.Entity<Core.Produtos.ProdutoReceitaDTA>()
                .HasOne(i => i.Receita)
                .WithMany(i => i.ProdutosReceita)
                .HasForeignKey(i => i.IdReceita);

            modelBuilder.Entity<Core.Produtos.ProdutoDTA>()
                .HasMany(i => i.Receitas)
                .WithOne(i => i.Produto)
                .HasForeignKey(i => i.IdProduto)
                .IsRequired();
            #endregion

            #region [Clientes]

            #endregion

            #region [Formas]
            #endregion
        }
    }
}
