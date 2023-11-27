using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace NewsData.NET.ObjectModels.ResponseModels
{
    public sealed class SuccessNewsDataResult : BaseNewsDataResult
    {
        [JsonPropertyName("totalResults")]
        public int TotalResults { get; set; }

        [JsonPropertyName("results")]
        public IReadOnlyList<SuccessResult> Results { get; set; }

        [JsonPropertyName("nextPage")]
        public string NextPage { get; set; }
    }
}
