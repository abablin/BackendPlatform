using System.Text.Json.Serialization;

namespace BackendPlatform.Service.Models
{
    public class ServiceResponseModel
    {
        public bool Succeed { get => Code == 0; }
        public int Code { get; set; }
        public string Message { get; set; } = string.Empty;
    }

    public sealed class ServiceResponseModel<DataType> : ServiceResponseModel
    {
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public DataType? Data { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public Dictionary<string, object>? Metadata { get; set; }
    }

    public class Emp
    {
        public int Id { get; set; }
        public string Dept { get; set; }
    }
}
