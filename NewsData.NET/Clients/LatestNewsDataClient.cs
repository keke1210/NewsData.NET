using NewsData.NET.Clients.Base;
using System.Net.Http;

namespace NewsData.NET.Clients
{
    public sealed class LatestNewsDataClient : BaseNewsDataClient
    {
        public LatestNewsDataClient(string apiKey, bool useClientFactory = false) : base(apiKey, useClientFactory) { }
        public LatestNewsDataClient(string apiKey, HttpClient httpClient) : base(apiKey, httpClient) { }
        protected override string BaseURL { get; } = $"{BaseAPIURL}news";
    }
}
