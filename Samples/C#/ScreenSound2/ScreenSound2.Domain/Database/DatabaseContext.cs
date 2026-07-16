using Microsoft.EntityFrameworkCore;
using ScreenSound.Domain.Models;


namespace ScreenSound.Domain.Database
{
    public class DatabaseContext: DbContext
    {
        //Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=ScreenSound;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent = ReadWrite; Multi Subnet Failover=False
        private const string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;" +
            "Initial Catalog = ScreenSound;" +
            "Integrated Security = True;" +
            "Encrypt = False;" +
            "Trust Server Certificate = False;" +
            "Application Intent = ReadWrite;" +
            "Multi Subnet Failover = False";

        public DbSet<Artista> Artistas { get; set; }
        public DbSet<Musica> Musicas { get; set; }
        public DbSet<Genero> Generos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //base.OnConfiguring(optionsBuilder);

            optionsBuilder
                .UseSqlServer(connectionString)
                .UseLazyLoadingProxies();

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Musica>()
                .HasMany(g => g.Generos)
                .WithMany(m => m.Musicas);
        }
    }
}
