using NewsData.NET.ObjectModels.RequestModels;
using NewsData.NET.ObjectModels.ResponseModels;
using RestSharp;
using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace NewsData.NET.Clients
{
    public sealed class NewsDataClient : INewsDataClient
    {
        public const string BaseAPIURL = "https://newsdata.io/api/1/";
        public string BaseURL { get; }

        private readonly string _apiKey;
        private readonly IRestClient _client;
        public NewsDataClient(ClientType clientType, string apiKey, bool useClientFactory = false)
        {
            BaseURL = $"{BaseAPIURL}{GetUrlRoute(clientType)}";
            _apiKey = apiKey;
            _client = new RestClient(baseUrl: new Uri(BaseURL), useClientFactory: useClientFactory);
        }

        public NewsDataClient(ClientType clientType, string apiKey, HttpClient client)
        {
            BaseURL = $"{BaseAPIURL}{GetUrlRoute(clientType)}";
            _apiKey = apiKey;
            _client = new RestClient(client, configureRestClient: (options) =>
            {
                options.BaseUrl = new Uri(BaseURL);
            });
        }

        public async Task<NewsDataApiResult> ExecuteAsync(DefaultRequest apirequest, CancellationToken cancellationToken = default)
        {
            RestRequest request = CreateRequest(apirequest);

            RestResponse restResult = await _client.ExecuteAsync(request, cancellationToken).ConfigureAwait(false);

            return CreateResponse(restResult);
        }

        private RestRequest CreateRequest(DefaultRequest apirequest)
        {
            var request = new RestRequest();
            request.AddQueryParameter("apikey", _apiKey);

            if (!string.IsNullOrWhiteSpace(apirequest.PageIndex))
            {
                request.AddQueryParameter("page", apirequest.PageIndex);
            }

            foreach (var queryStringParam in apirequest.QueryStringCollection)
            {
                request.AddQueryParameter(queryStringParam.Key, queryStringParam.Value);
            }

            return request;
        }

        private static NewsDataApiResult CreateResponse(RestResponse restResult)
        {
            var result = new NewsDataApiResult();

            result.Successful = restResult.IsSuccessful;
            if (!result.Successful)
            {
                result.ErrorResult = JsonSerializer.Deserialize<ErrorNewsDataResult>(restResult.Content);
                return result;
            }

            result.SuccessResult = JsonSerializer.Deserialize<SuccessNewsDataResult>(restResult.Content);
            return result;
        }

        private static string GetUrlRoute(ClientType clientType)
        {
            switch (clientType)
            {
                case ClientType.News:
                    return "news";
                case ClientType.Crypto:
                    return "crypto";
                case ClientType.Archive:
                    return "archive";
                case ClientType.Sources:
                    return "sources";
                default:
                    throw new ArgumentNullException(nameof(clientType));
            }
        }

        public void Dispose()
        {
            _client?.Dispose();
        }
    }
}
