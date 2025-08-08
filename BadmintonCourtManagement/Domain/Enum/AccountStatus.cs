using System.Text.Json.Serialization;

namespace BadmintonCourtManagement.Domain.Enum
{

    [JsonConverter(typeof(JsonStringEnumConverter))] // phép chuyển đổi enum sang chuỗi JSON
    public enum AccountStatus
    {
        Active,
        Inactive
    }
}
