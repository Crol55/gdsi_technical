using CompanyManagement.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;

namespace CompanyManagement
{
    public class Program
    {
        static void Main(string[] args)
        {
            var config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();

            
            var services = new ServiceCollection();

            services.AddDbContext<CompanyDbContext>(options => 
                options.UseSqlServer(config.GetConnectionString("sqlServerConnection"))
            );

            var provider = services.BuildServiceProvider();

            CompanyDbContext dbContext = provider.GetRequiredService<CompanyDbContext>();

            // Creating the database during runtime
            dbContext.Database.Migrate();

            Startup();

            bool isValidKeyPressed = true;

            while (isValidKeyPressed)
            {
                Console.WriteLine(UserOptions());

                ConsoleKeyInfo input = Console.ReadKey();

                switch (input.KeyChar)
                {
                    case '1':
                        Console.WriteLine("new Company being inserted");
                        break;

                    case '2':
                        Console.WriteLine("Company being removed");
                        break;

                    case '3':
                        Console.WriteLine("Json was parsed");
                        break;

                    default:
                        isValidKeyPressed = false;
                        break;
                }
            }

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
