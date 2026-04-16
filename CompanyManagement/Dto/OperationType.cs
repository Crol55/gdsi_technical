
using System.Text.Json.Serialization;

namespace CompanyManagement.Dto
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum OperationType
    {
        Add,
        Remove
    }
}
