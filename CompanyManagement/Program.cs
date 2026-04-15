using CompanyManagement.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace CompanyManagement
{
    public class Program
    {
        static void Main(string[] args)
        {
            var services = new ServiceCollection();

            services.AddDbContext<CompanyDbContext>(options => 
                options.UseSqlServer(
                    "server=localhost;Database=gdsi;User Id=default;Password=default;MultipleActiveResultSets=true;Encrypt=false"
                    )
            );

            var provider = services.BuildServiceProvider();

            CompanyDbContext dbContext = provider.GetRequiredService<CompanyDbContext>();

            // Creating the database during runtime
            dbContext.Database.Migrate();

            Startup();

        }

        private static void Startup()
        {
            Console.WriteLine("The database is starting....");

            // command line options
            /*
             1) Add a company by name
             2) Remove a company by name
             3) JSON import (to add and remove users from a given company)
             */
        }

        private static string UserOptions() {
           return 
           """
            a-) Press (1) for adding a Company.
            b-) Press (2) for removing a Company.
            c-) Press (3) for reading JSON.
            Press any key to close this window...
           """;
        }
    }
}
