using NewsData.NET.ObjectModels.RequestModels;
using NewsData.NET.ObjectModels.ResponseModels;
using System.Threading.Tasks;
using System.Threading;
using System;

namespace NewsData.NET
{
    public interface INewsDataClient : IDisposable
    {
        Task<NewsDataApiResult> ExecuteAsync(DefaultRequest apirequest, CancellationToken cancellationToken = default);
    }
}
