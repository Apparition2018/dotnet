using dotnet.L.Demo;

namespace dotnetTest.API.System.IO;

/// <summary>
/// <a href="https://learn.microsoft.com/zh-cn/dotnet/api/system.io.textreader">TextReader</a>
/// </summary>
public class TextReader : Demo
{
    /// <summary>
    /// <a href="https://learn.microsoft.com/zh-cn/dotnet/api/system.io.streamreader">StreamReader</a>
    /// </summary>
    [Test]
    public void StreamReader()
    {
        // static StreamReader  OpenText(string path)
        // 打开现有的 UTF-8 编码文本文件进行读取
        using StreamReader streamReader = File.OpenText(DemoFilePath);

        // int                  Peek()
        // 返回下一个可用字符，但不使用它
        Assert.That(streamReader.Peek(), Is.EqualTo(38745));
        // unsafe string?       ReadLine()
        // 从当前流中读取一行字符，并以字符串形式返回数据
        Console.WriteLine(streamReader.ReadLine());
        // string               ReadToEnd()
        // 读取从当前位置到流末尾的所有字符
        Console.WriteLine(streamReader.ReadToEnd());
    }
}
