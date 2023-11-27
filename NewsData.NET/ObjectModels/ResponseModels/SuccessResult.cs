using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace NewsData.NET.ObjectModels.ResponseModels
{
    public sealed class SuccessResult
    {
        [JsonPropertyName("article_id")]
        public string ArticleId { get; set; }

        [JsonPropertyName("title")]
        public string Title { get; set; }

        [JsonPropertyName("link")]
        public string Link { get; set; }

        [JsonPropertyName("keywords")]
        public List<string> Keywords { get; set; }

        [JsonPropertyName("creator")]
        public List<string> Creator { get; set; }

        [JsonPropertyName("video_url")]
        public string VideoUrl { get; set; }

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
}
