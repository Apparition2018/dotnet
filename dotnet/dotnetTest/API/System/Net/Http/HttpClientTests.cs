using System.Net.Http.Headers;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace dotnetTest.API.System.Net.Http;

/// <summary>
/// <a href="https://learn.microsoft.com/zh-cn/dotnet/api/system.net.http.httpclient">HttpClient</a>
/// </summary>
public class HttpClientTests
{
    /// <summary>
    /// <a href="https://learn.microsoft.com/zh-cn/dotnet/csharp/tutorials/console-webapiclient#make-http-requests">发出 HTTP 请求</a>
    /// </summary>
    [Test]
    public async Task RestClient()
    {
        using HttpClient client = new();
        client.DefaultRequestHeaders.Accept.Clear();
        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/vnd.github.v3+json"));
        client.DefaultRequestHeaders.Add("User-Agent", ".NET Foundation Repository Reporter");

        var repositories = await ProcessRepositoriesAsync(client);

        foreach (var repo in repositories)
        {
            Console.WriteLine($"Name: {repo.Name}");
            Console.WriteLine($"Homepage: {repo.Homepage}");
            Console.WriteLine($"GitHub: {repo.GitHubHomeUrl}");
            Console.WriteLine($"Description: {repo.Description}");
            Console.WriteLine($"Watchers: {repo.Watchers:#,0}");
            Console.WriteLine($"Last push: {repo.LastPush}");
            Console.WriteLine();
        }

        static async Task<List<Repository>> ProcessRepositoriesAsync(HttpClient client)
        {
            await using Stream stream = await client.GetStreamAsync("https://api.github.com/orgs/dotnet/repos");
            var repositories = await JsonSerializer.DeserializeAsync<List<Repository>>(stream);
            return repositories ?? new();
        }
    }

    record Repository(
        [property: JsonPropertyName("name")] string Name,
        [property: JsonPropertyName("description")] string Description,
        [property: JsonPropertyName("html_url")] Uri GitHubHomeUrl,
        [property: JsonPropertyName("homepage")] Uri Homepage,
        [property: JsonPropertyName("watchers")] int Watchers,
        [property: JsonPropertyName("pushed_at")] DateTime LastPushUtc)
    {
        public DateTime LastPush => LastPushUtc.ToLocalTime();
    }
}
