using System.Text.Json.Serialization;

namespace NewsData.NET.ObjectModels.ResponseModels
{
    public sealed class ErrorResult
    {
        [JsonPropertyName("code")]
        public string Code { get; set; }

        [JsonPropertyName("message")]
        public string Message { get; set; }
    }
}
