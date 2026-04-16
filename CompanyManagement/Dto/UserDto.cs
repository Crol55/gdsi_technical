

using System.Text.Json.Serialization;

namespace CompanyManagement.Dto
{
    public class UserDto
    {
        [JsonPropertyName("code")]
        public string Code { get; set; }

        [JsonPropertyName("fullname")]
        public string FullName { get; set; }

    }
}
