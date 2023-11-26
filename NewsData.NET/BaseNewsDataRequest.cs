using RestSharp;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace NewsData.NET
{
    public abstract class BaseNewsDataRequest : IDisposable
    {
        protected const string BaseAPIURL = "https://newsdata.io/api/1/";
        protected abstract string BaseURL { get; }

        private readonly string _apiKey;
        private readonly RestClient _client;
        protected BaseNewsDataRequest(string apiKey)
        {
            _apiKey = apiKey;
            _client = new RestClient(BaseURL);
        }

        public async Task<RestResponse<NewsDataResult>> ExecuteAsync(
            IEnumerable<KeyValuePair<string, string>> queryStringCollection,
            string pageIndex = null,
            CancellationToken cancellationToken = default)
        {
            var request = new RestRequest();
            request.AddQueryParameter("apikey", _apiKey);

            if (!string.IsNullOrWhiteSpace(pageIndex))
            {
                request.AddQueryParameter("page", pageIndex);
            }

            foreach (var queryStringParam in queryStringCollection)
            {
                request.AddQueryParameter(queryStringParam.Key, queryStringParam.Value);
            }

            return await _client.ExecuteAsync<NewsDataResult>(request, cancellationToken).ConfigureAwait(false);
        }

        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    _client.Dispose();
                }

                disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        ~BaseNewsDataRequest()
        {
            Dispose(false);
        }
    }
}
