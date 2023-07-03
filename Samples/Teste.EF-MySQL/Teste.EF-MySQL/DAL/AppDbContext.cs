using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teste.EF_MySQL.DAL.Produtos;
using Teste.EF_MySQL.DAL.Receitas;

namespace Teste.DAL
{
    public class AppDbContext: DbContext
    {
        private readonly string _connectionString;

        public DbSet<ProdutoDTA> Produtos { get; set; }
        public DbSet<ReceitaDTA> Receitas { get; set; }
        public DbSet<ProdutoReceitaDTA> ProdutosReceitas { get; set; }


        public AppDbContext()
        {
            _connectionString = "Server=localhost;Port=3306;Database=test;Uid=root;Pwd=root;";
        }

        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base (options)
        {           
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySql(_connectionString, ServerVersion.AutoDetect(_connectionString));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ProdutoDTA>()
                .HasMany(i => i.Receitas)
                .WithOne(i => i.Produto)
                .HasForeignKey(i => i.IdProduto)
                .IsRequired();


            modelBuilder.Entity<ProdutoReceitaDTA>()
                .HasOne(i => i.Produto)
                .WithMany(i => i.Receitas)
                .HasForeignKey(i => i.IdProduto);


            modelBuilder.Entity<ProdutoReceitaDTA>()
                .HasOne(i => i.Receita)
                .WithMany(i => i.ProdutosReceitas)
                .HasForeignKey(i => i.IdReceita);
        }
    }
}
