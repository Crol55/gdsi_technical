using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace CompanyManagement.Data
{
    public class CompanyDbContextFactory : IDesignTimeDbContextFactory<CompanyDbContext>
    {
        public CompanyDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<CompanyDbContext>();

            optionsBuilder.UseSqlServer(
                "server=localhost;Database=gdsi;User Id=default;Password=default;MultipleActiveResultSets=true;Encrypt=false");

            return new CompanyDbContext(optionsBuilder.Options);
        }
    }

    

}
