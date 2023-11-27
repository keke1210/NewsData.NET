using System.Text.Json.Serialization;

namespace NewsData.NET.ObjectModels.ResponseModels
{
    public sealed class ErrorNewsDataResult : BaseNewsDataResult
    {
        [JsonPropertyName("results")]
        public ErrorResult Results { get; set; }
    }
}
