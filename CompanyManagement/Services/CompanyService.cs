using System.Text.RegularExpressions;
using CompanyManagement.Data;
using CompanyManagement.Models;

namespace CompanyManagement.Services
{
    public class CompanyService
    {
        private readonly CompanyDbContext _dbContext;
        public CompanyService(CompanyDbContext dbContext) {
            _dbContext = dbContext;
        }

        public void AddCompany(string companyName) {

            // Verify if the company already exists

            bool companyAlreadyExists = _dbContext.Companies
                .Where(x => x.Name == ValidateAndNormalize(companyName) && (x.IsDeleted == false))
                .Any( );

            if (!companyAlreadyExists) 
            {
                var newCompany = new Company() { 
                    Name = ValidateAndNormalize(companyName)
                };
                
                _dbContext.Companies.Add(newCompany);
                _dbContext.SaveChanges();
            }
        }

        public void DeleteCompany(string companyName)
        {
            Company? company =  _dbContext.Companies
                .Where(x => x.Name == ValidateAndNormalize(companyName) && (x.IsDeleted == false))
                .SingleOrDefault();

            if (company != null) 
            {
                company.IsDeleted = true;

                _dbContext.SaveChanges();
                return;
            }

            Console.WriteLine("That company doesnt exists!");
        }

        private string ValidateAndNormalize(string input)
        {
            string name = input.Trim();

            // Collapse multiple spaces
            name = Regex.Replace(name, @"\s+", " ");

            return name;
        }

    }
}
