using NewsData.NET;
using System.Configuration;
using System.Text.Json;

var apiKey = ConfigurationManager.AppSettings["NEWS_DATA_API_KEY"];

var request = new NewsDataRequest(apiKey);

var qs = new Dictionary<string, string>();
qs.Add("country", "al");
qs.Add("language", "sq");
qs.Add("timezone", "Europe/Berlin");
qs.Add("full_content", "1");
//qs.Add("image", "1");
//qs.Add("video", "1");
qs.Add("size", "10");
qs.Add("category", "sports,top");
qs.Add("timeframe", "6");

var newsResult = await request.ExecuteAsync(qs);

if (!newsResult.IsSuccessStatusCode)
{
    throw new HttpRequestException(newsResult.ErrorMessage, newsResult.ErrorException);
}

var newsJson = JsonSerializer.Serialize(newsResult.Data);

Console.WriteLine(newsJson);

Console.ReadLine();