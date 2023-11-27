using System.Text.Json.Serialization;

namespace NewsData.NET.ObjectModels.ResponseModels
{
    public abstract class BaseNewsDataResult
    {
        [JsonPropertyName("status")]
        public string Status { get; set; }
    }
}
