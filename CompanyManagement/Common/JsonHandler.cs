
using System.Text.Json;
using CompanyManagement.Dto;

namespace CompanyManagement.Common
{
    public class JsonHandler
    {
        public OperationBatchImport? ProcessFile(string filePath)
        {
            // Normalize path
            filePath = Path.GetFullPath(filePath);

            // Validate file
            if (!File.Exists(filePath))
            {
                Console.WriteLine("File does not exist.");
                return null;
            }

            if (Path.GetExtension(filePath).ToLower() != ".json")
            {
                Console.WriteLine("Only .json files are allowed.");
                return null;
            }

            try
            {
                string jsonContent = File.ReadAllText(filePath);

                return ParseJson(jsonContent);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error reading file: {ex.Message}");
                return null;
            }
        }

        static OperationBatchImport? ParseJson(string json)
        {
            try
            {
                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                };

                OperationBatchImport? request =
                    JsonSerializer.Deserialize<OperationBatchImport>(json, options);

                return request;

                /*foreach (var op in request!.Operations)
                {
                    Console.WriteLine($"{op.Type} users for {op.CompanyName}");

                    foreach (var user in op.Users)
                    {
                        Console.WriteLine($" - {user.Code} {user.FullName}");
                    }
                }
                */
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Invalid JSON format: {ex.Message}");
                return null;
            }
        }
    }
}
