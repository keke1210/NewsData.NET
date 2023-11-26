namespace NewsData.NET
{
    public sealed class NewsArchiveDataRequest : BaseNewsDataRequest
    {
        public NewsArchiveDataRequest(string apiKey) : base(apiKey) { }
        protected override string BaseURL { get; } = $"{BaseAPIURL}archive";
    }
}
