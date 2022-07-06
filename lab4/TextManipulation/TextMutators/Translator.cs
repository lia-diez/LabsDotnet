using System.Text.Json.Nodes;
using System.Web;

namespace lab4.TextManipulation.TextMutators;

public static class Translator
{
    private static readonly HttpClient Client = new();
    public static string Translate(string text, string language)
    {
        var query = HttpUtility.ParseQueryString(string.Empty);
        query["text"] = text;
        query["to"] = language;
        string queryString = query.ToString();
        
        var request = new HttpRequestMessage
        {
            Method = HttpMethod.Get,
            RequestUri = new Uri("https://nlp-translation.p.rapidapi.com/v1/translate?"+queryString),
            Headers =
            {
                { "X-RapidAPI-Key", "287c012206mshfe7bed4f88d906bp1f171cjsnbf5ef1fe29fb" },
                { "X-RapidAPI-Host", "nlp-translation.p.rapidapi.com" },
            },
        };
        using (var response = Client.Send(request))
        {
            response.EnsureSuccessStatusCode();
            var body = response.Content.ReadAsStream();
            var result = JsonNode.Parse(body)["translated_text"][language].ToString();
            return result;
        }
    }
}