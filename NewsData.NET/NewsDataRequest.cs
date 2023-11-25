using RestSharp;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NewsData.NET
{
    public sealed class NewsDataRequest
    {
        private const string BaseURL = "https://newsdata.io/api/1/news";
        private readonly string _apiKey;
        public NewsDataRequest(string apiKey) => _apiKey = apiKey;

        public async Task<RestResponse<NewsDataResult>> ExecuteAsync(IEnumerable<KeyValuePair<string, string>> queryStringCollection)
        {
            var request = new RestRequest();
            request.AddQueryParameter("apikey", _apiKey);

            foreach (var qsParam in queryStringCollection)
            {
                request.AddQueryParameter(qsParam.Key, qsParam.Value);
            }

            using (var client = new RestClient(BaseURL))
            {
                return await client.ExecuteAsync<NewsDataResult>(request).ConfigureAwait(false);
            }
        }
    }
}
