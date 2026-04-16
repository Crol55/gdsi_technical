
using System.Text.Json.Serialization;

namespace CompanyManagement.Dto
{
    public class CompanyUserOperationDto
    {
        [JsonPropertyName("type")]
        public OperationType Type { get; set; }

        [JsonPropertyName("companyName")]
        public string CompanyName { get; set; }

        [JsonPropertyName("users")]
        public List<UserDto> Users { get; set; } = [];
    }

}
