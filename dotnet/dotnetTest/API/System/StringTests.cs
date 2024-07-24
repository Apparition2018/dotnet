namespace dotnetTest.API.System;

/// <summary>
/// <a href="https://learn.microsoft.com/zh-cn/dotnet/api/system.string">String</a>
/// </summary>
public class StringTests
{
    [Test]
    public void Test()
    {
        Assert.That(string.Empty, Is.EqualTo(""));

        // unsafe char[]        ToCharArray()
        Assert.That("123".ToCharArray().Length, Is.EqualTo(3));

        // string[]             Split(string? separator, StringSplitOptions options = StringSplitOptions.None)
        Assert.That("1,2,3".Split(",").Length, Is.EqualTo(3));

        // static string        Format(string format, params object?[] args)
        Assert.That(string.Format("{0} {1} {2}", "a", "b", "c", "d"), Is.EqualTo("a b c"));
        Assert.That(string.Format("{0} {0} {0}", "a", "b", "c"), Is.EqualTo("a a a"));

        // string               PadLeft(int totalWidth)
        Assert.That("123".PadLeft(5, '*'), Is.EqualTo("**123"));
        // string               PadRight(int totalWidth)
        Assert.That("123".PadRight(5, '*'), Is.EqualTo("123**"));

        // string               Trim()
        Assert.That(" 123 ".Trim(), Is.EqualTo("123"));
        Assert.That(" 123 ".TrimStart(), Is.EqualTo("123 "));
        Assert.That(" 123 ".TrimEnd(), Is.EqualTo(" 123"));

        // string               Substring(int startIndex, int length)
        Assert.That("123".Substring(1, 1), Is.EqualTo("2"));

        // string               Remove(int startIndex, int count)
        Assert.That("123".Remove(1, 1), Is.EqualTo("13"));
        //  string              Insert(int startIndex, [NotNull] string value)
        Assert.That("123".Insert(0, "0"), Is.EqualTo("0123"));
        // unsafe string        Replace(string oldValue, string? newValue)
        Assert.That("123".Replace("2", string.Empty), Is.EqualTo("13"));

        // int                  IndexOfAny(char[] anyOf, int startIndex)
        Assert.That("(1)[2]{3}".IndexOfAny(['(', '[', '{'], 0), Is.EqualTo(0));
        // int                  LastIndexOfAny(char[] anyOf, int startIndex)
        Assert.That("(1)[2]{3}".LastIndexOfAny([')', ']', '}'], 0), Is.EqualTo(-1));

        // static bool          IsNullOrEmpty([NotNullWhen(false)] string? value)
        Assert.That(string.IsNullOrEmpty(" "), Is.EqualTo(false));
        // static bool          IsNullOrWhiteSpace([NotNullWhen(false)] string? value)
        Assert.That(string.IsNullOrWhiteSpace(" "), Is.EqualTo(true));
    }
}
