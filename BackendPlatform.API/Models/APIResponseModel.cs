using System.Text.Json.Serialization;

namespace BackendPlatform.API.Models
{
    public class APIResponseModel
    {
        public int ErrorCode { get; set; }
        public string ErrorMes { get; set; } = string.Empty;
    }

    public class APIResponseModel<T> : APIResponseModel where T : class
    {
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public T Data { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public int? RowsCount { get; set; }
    }
}
