using dotnet.L.Demo;

namespace dotnetTest.Guide.LanguageReference.Statements;

/// <summary>
/// <a href="https://learn.microsoft.com/zh-cn/dotnet/csharp/language-reference/statements/using">using 语句</a>
/// 确保正确使用可释放对象
/// </summary>
public class UsingStatement : Demo
{
    [Test]
    public void Test()
    {
        using StreamReader reader = File.OpenText(DemoFilePath);
        while (reader.ReadLine() is { } line)
        {
            Console.WriteLine(line);
        }
    }
}
