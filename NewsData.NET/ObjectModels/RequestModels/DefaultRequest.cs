using System.Collections.Generic;

namespace NewsData.NET.ObjectModels.RequestModels
{
    public sealed class DefaultRequest
    {
        public DefaultRequest() { }
        public DefaultRequest(IDictionary<string, string> queryStringCollection, string pageIndex = null)
        {
            QueryStringCollection = queryStringCollection;
            PageIndex = pageIndex;
        }

        public IDictionary<string, string> QueryStringCollection { get; set; }
        public string PageIndex { get; set; }
    }
}
