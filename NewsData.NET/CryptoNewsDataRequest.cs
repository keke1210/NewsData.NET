namespace NewsData.NET
{
    public sealed class CryptoNewsDataRequest : BaseNewsDataRequest
    {
        public CryptoNewsDataRequest(string apiKey) : base(apiKey) { }
        protected override string BaseURL { get; } = $"{BaseAPIURL}crypto";
    }
}
