using System.Net;

namespace dotnetTest.API.System.Net;

/// <summary>
/// <a href="https://learn.microsoft.com/zh-cn/dotnet/api/system.net.webclient">WebClient</a>
/// 提供用于将数据发送到由 URI 标识的资源及从这样的资源接收数据的常用方法
/// </summary>
public class WebClientTests
{
    /// <summary>
    /// <a href="https://learn.microsoft.com/zh-cn/dotnet/standard/parallel-programming/how-to-use-parallel-invoke-to-execute-parallel-operations#example">创建单词数组</a>
    /// </summary>
    [Test]
    public void CreateWordArray()
    {
        string uri = "http://www.gutenberg.org/files/54700/54700-0.txt";
        string s = new WebClient().DownloadString(uri);
        string[] splits = s.Split(
            new[] { ' ', '\u000A', ',', '.', ';', ':', '-', '_', '/' },
            StringSplitOptions.RemoveEmptyEntries);
        foreach (var split in splits)
        {
            Console.WriteLine(split);
        }
    }
}
