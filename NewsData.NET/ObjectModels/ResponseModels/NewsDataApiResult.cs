namespace NewsData.NET.ObjectModels.ResponseModels
{
    public sealed class NewsDataApiResult
    {
        public bool Successful { get; set; }
        public SuccessNewsDataResult SuccessResult { get; set; }
        public ErrorNewsDataResult ErrorResult { get; set; }
    }
}
