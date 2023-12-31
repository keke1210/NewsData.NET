﻿using NewsData.NET.ObjectModels.RequestModels;
using NewsData.NET.ObjectModels.ResponseModels;
using RestSharp;
using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace NewsData.NET
{
    public sealed class NewsDataClient : INewsDataClient
    {
        private const string BaseUrl = "https://newsdata.io/api/1/";
        private readonly string _apiKey;
        private readonly IRestClient _client;
        public string ApiUrl { get; }

        private NewsDataClient(ClientType clientType, string apiKey)
        {
            if (string.IsNullOrWhiteSpace(apiKey))
            {
                throw new ArgumentException(nameof(apiKey));
            }

            string route = clientType switch
            {
                ClientType.LatestNews => "news",
                ClientType.CryptoNews => "crypto",
                ClientType.NewsArchive => "archive",
                ClientType.NewsSources => "sources",
                _ => throw new ArgumentException(nameof(clientType)),
            };

            _apiKey = apiKey;
            ApiUrl = $"{BaseUrl}{route}";
        }

        public NewsDataClient(ClientType clientType, string apiKey, bool useClientFactory = false) : this(clientType, apiKey)
        {
            _client = new RestClient(baseUrl: new Uri(ApiUrl), useClientFactory: useClientFactory);
        }

        public NewsDataClient(ClientType clientType, string apiKey, HttpClient client) : this(clientType, apiKey)
        {
            _client = new RestClient(client, configureRestClient: (options) =>
            {
                options.BaseUrl = new Uri(ApiUrl);
            });
        }

        public async Task<NewsDataApiResult> GetAsync(DefaultRequest apirequest, CancellationToken cancellationToken = default)
        {
            RestRequest request = CreateRequest(apirequest);

            RestResponse restResult = await _client.ExecuteAsync(request, cancellationToken).ConfigureAwait(false);

            return CreateResponse(restResult);
        }

        private RestRequest CreateRequest(DefaultRequest apirequest)
        {
            var request = new RestRequest();
            request.AddQueryParameter("apikey", _apiKey);

            foreach (var queryStringParam in apirequest.QueryStringCollection)
            {
                request.AddQueryParameter(queryStringParam.Key, queryStringParam.Value);
            }

            if (!string.IsNullOrWhiteSpace(apirequest.PageIndex))
            {
                request.AddOrUpdateParameter("page", apirequest.PageIndex);
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

        public void Dispose()
        {
            _client.Dispose();
        }
    }
}
