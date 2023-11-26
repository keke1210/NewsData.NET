namespace NewsData.NET
{
    public sealed class NewsSourcesDataRequest : BaseNewsDataRequest
    {
        public NewsSourcesDataRequest(string apiKey) : base(apiKey) { }
        protected override string BaseURL { get; } = $"{BaseAPIURL}sources";
    }
}
