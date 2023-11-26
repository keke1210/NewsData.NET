namespace NewsData.NET
{
    public sealed class LatestNewsDataRequest : BaseNewsDataRequest
    {
        public LatestNewsDataRequest(string apiKey) : base(apiKey) { }
        protected override string BaseURL { get; } = $"{BaseAPIURL}news";
    }
}
