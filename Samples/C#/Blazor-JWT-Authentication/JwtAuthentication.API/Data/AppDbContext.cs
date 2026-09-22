using JwtAuthentication.Lib.Entities;
using Microsoft.EntityFrameworkCore;

namespace JwtAuthentication.API.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) 
            : base(options)
        { }

        public DbSet<User> Users { get; set; }
    }
}
