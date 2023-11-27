# NewsData.NET

NewsData.NET is an unofficial .NET client package for the News Data API, designed to facilitate easy access to various news-related data. This package is compatible with [.NET Standard 2.1](https://github.com/dotnet/docs/blob/main/includes/net-standard-2.1.md).

## Documentation

News Data API docs can be seen [here](https://newsdata.io/documentation).

## Usage

To start using the NewsData.NET package, first initialize the NewsDataClient. This requires specifying a ClientType from the NewsData.NET.ClientType enumeration and an API key.

NewsData.NET.ClientType:
```csharp
public enum ClientType
{
    None = 0,
    LatestNews,
    CryptoNews,
    NewsArchive,
    NewsSources
}
```
```csharp
string apiKey = "your_api_key_here";
// The NewsDataClient also supports passing an HttpClient as an optional parameter
using INewsDataClient client = new NewsDataClient(ClientType.LatestNews, apiKey/*, httpClient*/);
```
Then we call the GetAsync method and pass an ```DefaultRequest(IDictionary<string, string> queryStringCollection, string pageIndex = null)``` including all the query string parameters.
```csharp
var queryString = new Dictionary<string, string>
{
    // ...
    { "country", "al" },
    { "language", "sq" },
    { "timezone", "Europe/Berlin" },
    { "size", "10" }, // free tier
    // ...
};

var result = await client.GetAsync(new DefaultRequest(queryString));
// Result will be of type NewsData.NET.ObjectModels.ResponseModels.NewsDataApiResult
```

### Aggregating Paged News
For fetching a fixed amount of data across pages, use the AggregatePagedNewsAsync method.

```csharp
// pass querystring as IDictionary<string, string> and articlesToBeFetched
var results = await client.AggregatePagedNewsAsync(queryString, articlesToBeFetched: 25);
// The result will be a list of NewsData.NET.ObjectModels.ResponseModels.SuccessResult
```

## Contributing
Pull requests are welcome. For major changes, please open an issue first to discuss what you would like to change.

## License

Licensed under the [MIT](LICENSE) License.
