using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Text;

namespace PostgreEF.Data
{
    public class ApplicationDbContextFactory 
        : IDesignTimeDbContextFactory<ApplicationDbContext>, IDisposable
    {
        public ApplicationDbContext CreateDbContext()
        {
            return this.CreateDbContext(null);
        }

        public ApplicationDbContext CreateDbContext(string[] args)
        {
            IConfigurationRoot config = new ConfigurationBuilder()
               .SetBasePath(Directory.GetCurrentDirectory())
               .AddJsonFile("appsettings.json", false)
               .Build();

            var conn = config.GetSection("ConnectionStrings").GetSection("DefaultConnection").Value;

            var optionBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
            optionBuilder.UseNpgsql(conn);

            return new ApplicationDbContext(optionBuilder.Options);
        }

        public void Dispose()
        {
            
        }
    }
}
