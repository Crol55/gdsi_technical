using CompanyManagement.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using CompanyManagement.Services;
using CompanyManagement.Common;
using CompanyManagement.Dto;

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

            services.AddScoped<CompanyService>();
            services.AddScoped<UserService>();
            services.AddScoped<BulkOperationProcessing>();

            var provider = services.BuildServiceProvider();

            using var scope = provider.CreateScope();

            // Creating the database during runtime
            CompanyDbContext dbContext = provider.GetRequiredService<CompanyDbContext>();
            dbContext.Database.Migrate();

            //Startup(); 

            var companyService = scope.ServiceProvider.GetRequiredService<CompanyService>();

            bool isValidKeyPressed = true;

            while (isValidKeyPressed)
            {
                Console.WriteLine(UserOptions());

                ConsoleKeyInfo input = Console.ReadKey();

                switch (input.KeyChar)
                {
                    case '1':

                        Console.WriteLine("\nType your company's name:");

                        string? userInput = Console.ReadLine();
                        if (string.IsNullOrWhiteSpace(userInput))
                        {
                            Console.WriteLine("Invalid company name");
                            continue;
                        }

                        companyService.AddCompany(userInput);

                        break;

                    case '2':
                        Console.WriteLine("\nType company to be removed:");

                        string? userInput2 = Console.ReadLine();
                        if (string.IsNullOrWhiteSpace(userInput2))
                        {
                            Console.WriteLine("Invalid company name");
                            continue;
                        }

                        companyService.DeleteCompany(userInput2);

                        break;

                    case '3':
                        Console.WriteLine("\nEnter the absolute path to a .json file");
                        string? input3 = Console.ReadLine();

                        if (string.IsNullOrWhiteSpace(input3))
                        {
                            Console.WriteLine("Error file path cannot be empty.\n");
                            continue;
                        }

                        var jsonHandler = new JsonHandler();
                        OperationBatchImport? x = jsonHandler.ProcessFile(input3);                        
                        
                        var bulkOpProcessing = scope.ServiceProvider.GetRequiredService<BulkOperationProcessing>();
                        bulkOpProcessing.InitProcessing(x!);

                        break;

                    default:
                        isValidKeyPressed = false;
                        break;
                }
            }

        }

        private static string UserOptions() {
           return 
           """
            1-) Press (1) for adding a Company.
            2-) Press (2) for removing a Company.
            3-) Press (3) for reading JSON.
                Press any key to close this window...
           """;
        }
    }
}
