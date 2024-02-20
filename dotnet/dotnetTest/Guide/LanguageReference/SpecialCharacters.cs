namespace dotnetTest.Guide.LanguageReference;

/// <summary>
/// <a href="https://learn.microsoft.com/zh-cn/dotnet/csharp/language-reference/tokens/">特殊字符</a>
/// </summary>
public class SpecialCharacters
{
    /// <summary>
    /// <a href="https://learn.microsoft.com/zh-cn/dotnet/csharp/language-reference/tokens/interpolated">字符串内插</a>
    /// </summary>
    [Test]
    public void StringInterpolation()
    {
        string firstName = "Bob";
        string greeting = "Hello";
        Assert.That($"{greeting} {firstName}!", Is.EqualTo("Hello Bob!"));
    }

    /// <summary>
    /// <a href="https://learn.microsoft.com/zh-cn/dotnet/csharp/language-reference/tokens/verbatim">逐字文本</a>
    /// </summary>
    [Test]
    public void VerbatimStringLiteral()
    {
        Console.WriteLine(@"    C:\source\repos
                    (this is where your code goes)");
    }
}
