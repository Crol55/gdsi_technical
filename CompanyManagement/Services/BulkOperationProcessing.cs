
using CompanyManagement.Dto;

namespace CompanyManagement.Services
{
    public class BulkOperationProcessing
    {
        private readonly UserService _userService;

        public BulkOperationProcessing(UserService userService) 
        {
            _userService = userService;
        }

        public void InitProcessing(OperationBatchImport _operationsDescription) {
            
            foreach (var op in _operationsDescription.Operations)
            {
                Console.WriteLine($"{op.Type} users for {op.CompanyName}");

                foreach (var user in op.Users)
                {
                    Console.WriteLine($" - {user.Code} {user.FullName}");
                    if (op.Type == OperationType.Add)
                        _userService.BulkAddUser(user.FullName, op.CompanyName);
                    else 

                        
                }
                // Calling save here to improve performance on bulk inserts
                _userService.Save();
            }
        }
    }
}
