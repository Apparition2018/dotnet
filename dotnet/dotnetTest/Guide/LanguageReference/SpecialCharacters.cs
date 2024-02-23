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
    /// 用作原义标识符
    /// <list type="bullet">
    /// <item>指示将原义解释字符串</item>
    /// <item>使用 C# 关键字作为标识符</item>
    /// <item>使编译器在命名冲突的情况下区分两种属性</item>
    /// </list>
    /// </summary>
    [Test]
    public void VerbatimStringLiteral()
    {
        Console.WriteLine(@"    C:\source\repos
                    (this is where your code goes)");

        int? @null = null;
        Assert.That(@null, Is.EqualTo(null));
    }
}
