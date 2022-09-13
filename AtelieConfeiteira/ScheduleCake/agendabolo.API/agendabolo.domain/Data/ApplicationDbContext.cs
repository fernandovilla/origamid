using Microsoft.EntityFrameworkCore;



namespace Agendabolo.Data
{
    public class ApplicationDbContext : DbContext
    {
        private readonly string _connectionString;

        //Classe de configuração
        public DbSet<Core.Insumos.Insumo> Insumos { get; set; }
        public DbSet<Core.Fabricantes.Fabricante> Fabricantes { get; set; }

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
    }
}
