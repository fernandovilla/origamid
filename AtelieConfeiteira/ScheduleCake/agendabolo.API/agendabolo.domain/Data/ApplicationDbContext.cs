using Microsoft.EntityFrameworkCore;



namespace Agendabolo.Data
{
    public class ApplicationDbContext : DbContext
    {
        //Classe de configuração
        public DbSet<Core.Insumos.Insumo> Insumos { get; set; }


        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            //if (!optionsBuilder.IsConfigured)
            //    optionsBuilder.UseMySql("Server=localhost;Port=3306;Database=agendabolo;Uid=root;Pwd=;");            
        }
    }
}
