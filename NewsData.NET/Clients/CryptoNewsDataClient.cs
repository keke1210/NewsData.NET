using NewsData.NET.Clients.Base;
using System.Net.Http;

namespace NewsData.NET.Clients
{
    public sealed class CryptoNewsDataClient : BaseNewsDataClient
    {
        public CryptoNewsDataClient(string apiKey, bool useClientFactory = false) : base(apiKey, useClientFactory) { }
        public CryptoNewsDataClient(string apiKey, HttpClient httpClient) : base(apiKey, httpClient) { }
        protected override string BaseURL { get; } = $"{BaseAPIURL}crypto";
    }
}
