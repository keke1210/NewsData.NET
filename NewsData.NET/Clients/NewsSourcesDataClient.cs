using NewsData.NET.Clients.Base;
using System.Net.Http;

namespace NewsData.NET.Clients
{
    public sealed class NewsSourcesDataClient : BaseNewsDataClient
    {
        public NewsSourcesDataClient(string apiKey, bool useClientFactory = false) : base(apiKey, useClientFactory) { }
        public NewsSourcesDataClient(string apiKey, HttpClient httpClient) : base(apiKey, httpClient) { }
        protected override string BaseURL { get; } = $"{BaseAPIURL}sources";
    }
}
