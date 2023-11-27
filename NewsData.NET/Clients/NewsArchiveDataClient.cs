using NewsData.NET.Clients.Base;
using System.Net.Http;

namespace NewsData.NET.Clients
{
    public sealed class NewsArchiveDataClient : BaseNewsDataClient
    {
        public NewsArchiveDataClient(string apiKey, bool useClientFactory = false) : base(apiKey, useClientFactory) { }
        public NewsArchiveDataClient(string apiKey, HttpClient httpClient) : base(apiKey, httpClient) { }
        protected override string BaseURL { get; } = $"{BaseAPIURL}archive";
    }
}
