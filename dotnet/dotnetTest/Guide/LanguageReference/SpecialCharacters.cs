namespace dotnetTest.Guide.LanguageReference;

/// <summary>
/// <a href="https://learn.microsoft.com/zh-cn/dotnet/csharp/language-reference/tokens/">特殊字符</a>
/// </summary>
public class SpecialCharacters
{
    /// <summary>
    /// <a href="https://learn.microsoft.com/zh-cn/dotnet/csharp/language-reference/tokens/interpolated">字符串内插</a>
    /// </summary>
    class StringInterpolation
    {
        [Test]
        public void Test()
        {
            string firstName = "Bob";
            string greeting = "Hello";
            Assert.That($"{greeting} {firstName}!", Is.EqualTo("Hello Bob!"));
        }

        /// <summary>
        /// <a href="https://learn.microsoft.com/zh-cn/dotnet/csharp/tutorials/string-interpolation#how-to-use-escape-sequences-in-an-interpolated-string">在内插字符串中使用转义序列</a>
        /// </summary>
        [Test]
        public void EscapeSequences()
        {
            var xs = new[] { 1, 2, 7, 9 };
            var ys = new[] { 7, 9, 12 };
            // 转义大括号：https://learn.microsoft.com/zh-cn/dotnet/standard/base-types/composite-formatting#escaping-braces
            Console.WriteLine($"Find the intersection of the {{{string.Join(", ",xs)}}} and {{{string.Join(", ",ys)}}} sets.");

            var userName = "Jane";
            var stringWithEscapes = $"C:\\Users\\{userName}\\Documents";
            var verbatimInterpolated = $@"C:\Users\{userName}\Documents";
            Console.WriteLine(stringWithEscapes);
            Console.WriteLine(verbatimInterpolated);
        }

        /// <summary>
        /// <a href="https://learn.microsoft.com/zh-cn/dotnet/csharp/tutorials/string-interpolation#how-to-use-a-ternary-conditional-operator--in-an-interpolation-expression">在内插表达式中使用三元条件运算符</a>
        /// </summary>
        [Test]
        public void TernaryConditionalOperator()
        {
            var rand = new Random();
            for (int i = 0; i < 7; i++)
            {
                // 将表达式放在括号内
                Console.WriteLine($"Coin flip: {(rand.NextDouble() < 0.5 ? "heads" : "tails")}");
            }
        }
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
