using Microsoft.EntityFrameworkCore;
using Sistema.Domain.Models.Usuarios;

namespace Sistema.WebAPI.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        { }

        public DbSet<UsuarioDTO> Users { get; set; }
    }
}
