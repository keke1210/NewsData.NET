﻿using NewsData.NET;
using System.Configuration;
using System.Text.Json;

var apiKey = ConfigurationManager.AppSettings["NEWS_DATA_API_KEY"];
using INewsDataClient client = new NewsDataClient(ClientType.LatestNews, apiKey);

var queryString = new Dictionary<string, string>
{
    { "country", "al" },
    { "language", "sq" },
    { "timezone", "Europe/Berlin" },
    { "full_content", "1" },
    { "size", "10" }, // free tier
    //{ "category", "sports,top" },
    { "timeframe", "24" },
    //{ "image", "1" },
    //{ "video", "1" }
};

var results = await client.AggregatePagedNewsAsync(queryString, articlesToBeFetched: 25);

var newsJson = JsonSerializer.Serialize(results);

Console.WriteLine(newsJson);

Console.ReadLine();