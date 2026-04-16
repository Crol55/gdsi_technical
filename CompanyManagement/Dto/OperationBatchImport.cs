
using System.Text.Json.Serialization;

namespace CompanyManagement.Dto
{
    public class OperationBatchImport
    {
        [JsonPropertyName("operations")]
        public List<CompanyUserOperationDto> Operations { get; set; } = [];
    }
}
