using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace NewsData.NET
{
    public class Result
    {
        [JsonPropertyName("article_id")]
        public string ArticleId { get; set; }

        [JsonPropertyName("title")]
        public string Title { get; set; }

        [JsonPropertyName("link")]
        public string Link { get; set; }

        [JsonPropertyName("keywords")]
        public object Keywords { get; set; }

        [JsonPropertyName("creator")]
        public List<string> Creator { get; set; }

        [JsonPropertyName("video_url")]
        public object VideoUrl { get; set; }

        [JsonPropertyName("description")]
        public string Description { get; set; }

        [JsonPropertyName("content")]
        public string Content { get; set; }

        [JsonPropertyName("pubDate")]
        public string PubDate { get; set; }

        [JsonPropertyName("image_url")]
        public string ImageUrl { get; set; }

        [JsonPropertyName("source_id")]
        public string SourceId { get; set; }

        [JsonPropertyName("source_priority")]
        public int SourcePriority { get; set; }

        [JsonPropertyName("country")]
        public List<string> Country { get; set; }

        [JsonPropertyName("category")]
        public List<string> Category { get; set; }

        [JsonPropertyName("language")]
        public string Language { get; set; }
    }

    public class NewsDataResult
    {
        [JsonPropertyName("status")]
        public string Status { get; set; }

        [JsonPropertyName("totalResults")]
        public int TotalResults { get; set; }

        [JsonPropertyName("results")]
        public List<Result> Results { get; set; }

        [JsonPropertyName("nextPage")]
        public string NextPage { get; set; }
    }
}
