

using CompanyManagement.Data;
using CompanyManagement.Dto;
using CompanyManagement.Models;

namespace CompanyManagement.Services
{
    public class UserService
    {
        private readonly CompanyDbContext _dbContext;
        public UserService(CompanyDbContext dbContext) { 
            _dbContext = dbContext;
        }

        public void BulkAddUser(UserDto dto, string employerName) 
        {
            // seek for the user
            // create it if it doesnt exists
            // update it if it does exists
            Company? company = GetCompany(employerName);
            
            if (company == null) {
                Console.WriteLine("Error, cannot add a User into a company that doesn't exists");
                return; 
            }

            User? user = _dbContext.Users
                .SingleOrDefault(x => x.CompanyId == company.Id && x.FullName == dto.FullName);

            if (user == null)
            {
                user = new User();
                _dbContext.Users.Add(user); 
            }

            user.FullName = dto.FullName;
            user.UserCode = dto.Code;
            user.CompanyId = company.Id;

            //will not call savechanges() to improve performance; use the Save() method
        }

        public void BulkRemoveUser(UserDto dto, string employerName)
        {
            Company? company = GetCompany(employerName);

            if (company == null)
            {
                Console.WriteLine("Error, cannot remove a User from a company that doesn't exists");
                return;
            }

            User? user = _dbContext.Users
                .SingleOrDefault(x => x.CompanyId == company.Id && x.FullName == dto.FullName);

            if (user != null)
            {
                _dbContext.Remove(user);
            }
            else 
            {
                Console.WriteLine($"The user ->{dto.FullName} doesnt exists in the Company");
            }
        }

        private Company? GetCompany(string companyName) =>  // move this into companyService
            _dbContext.Companies
            .SingleOrDefault(x => x.Name == companyName && x.IsDeleted == false);

        public void Save()
        {
            _dbContext.SaveChanges();
        }
    }
}
