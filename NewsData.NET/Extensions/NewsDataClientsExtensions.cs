using NewsData.NET.Clients;
using NewsData.NET.ObjectModels.RequestModels;
using NewsData.NET.ObjectModels.ResponseModels;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace NewsData.NET
{
    public static class NewsDataClientsExtensions
    {
        public static async Task<List<SuccessResult>> AggregatePagedNewsAsync(
            this INewsDataClient client,
            IDictionary<string, string> queryStringCollection,
            int articlesToBeFetched,
            CancellationToken cancellationToken = default)
        {
            var apiRequest = new DefaultRequest(queryStringCollection);

            int pageSize = int.Parse(apiRequest.QueryStringCollection["size"]);

            SuccessNewsDataResult newsResult = null;
            var results = new List<SuccessResult>();

            while (results.Count < articlesToBeFetched)
            {
                pageSize = Math.Min(pageSize, articlesToBeFetched - results.Count);
                apiRequest.QueryStringCollection["size"] = pageSize.ToString();
                apiRequest.PageIndex = newsResult?.NextPage;

                var apiResponse = await client.ExecuteAsync(apiRequest, cancellationToken);
                if (!apiResponse.Successful || apiResponse.SuccessResult.Results.Count == 0)
                {
                    break;
                }

                newsResult = apiResponse.SuccessResult;
                results.AddRange(newsResult.Results);

                if (newsResult.NextPage == null)
                {
                    break;
                }
            }

            return results;
        }
    }
}
