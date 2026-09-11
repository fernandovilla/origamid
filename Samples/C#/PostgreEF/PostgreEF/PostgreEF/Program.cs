/*
* https://dev.to/hbolajraf/c-using-entity-framework-with-postgresql-database-41dg
* postgres/postgres         
* 5432
*/

using Microsoft.Extensions.Configuration;
using PostgreEF.Data;
using PostgreEF.Domain.Model;

namespace PostgreEF
{

    public class Program
    {
        public static async Task Main()
        {
            using var context = (new ApplicationDbContextFactory()).CreateDbContext();

            var company = new Company();
            company.Name = "Empresa Teste";
            company.Status = StatusEnum.Normal;

            company.Users.Add(new User()
            {
                Name = "Fernando",
                Status = StatusEnum.Normal,
            });

            await context.Companies.AddAsync(company);

            await context.SaveChangesAsync();
        }
    }
}