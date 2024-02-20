namespace dotnetTest.API.System;

/// <summary>
/// <a href="https://learn.microsoft.com/zh-cn/dotnet/api/system.string">String</a>
/// </summary>
public class StringTests
{
    [Test]
    public void Test()
    {
        // unsafe char[]        ToCharArray()
        Array.ForEach("123".ToCharArray(), Console.WriteLine);

        // string[]             Split(string? separator, StringSplitOptions options = StringSplitOptions.None)
        Array.ForEach("1,2,3".Split(","), Console.WriteLine);

        // static string        Format(string format, params object?[] args)
        string a = "a", b = "b", c = "c", d = "d";
        Assert.That(string.Format("{0} {1} {2}", a, b, c, d), Is.EqualTo("a b c"));
        Assert.That(string.Format("{0} {0} {0}", a, a, a), Is.EqualTo("a a a"));

        // string               PadLeft(int totalWidth)
        Assert.That("123".PadLeft(5, '*'), Is.EqualTo("**123"));
        // string               PadRight(int totalWidth)
        Assert.That("123".PadRight(5, '*'), Is.EqualTo("123**"));

        // int                  IndexOfAny(char[] anyOf, int startIndex)
        Assert.That("(1)[2]{3}".IndexOfAny(new[] { '(', '[', '{' }, 0), Is.EqualTo(0));
        // int                  LastIndexOfAny(char[] anyOf, int startIndex)
        Assert.That("(1)[2]{3}".LastIndexOfAny(new[] { ')', ']', '}' }, 0), Is.EqualTo(-1));

        // unsafe string        Remove(int startIndex, int count)
        Assert.That("123".Remove(1, 1), Is.EqualTo("13"));
        // unsafe string        Replace(string oldValue, string? newValue)
        Assert.That("123".Replace("2", string.Empty), Is.EqualTo("13"));
    }

    [Test]
    public void Format()
    {
        /* :C 货币格式 */
        decimal price = 123.45m;
        int discount = 50;
        Assert.That($"Price: {price:C} (Save {discount:C})", Is.EqualTo("Price: ¥123.45 (Save ¥50.00)"));

        /* :N 数值格式 */
        decimal measurement = 123456.78912m;
        Assert.That($"Measurement: {measurement:N} units", Is.EqualTo("Measurement: 123,456.79 units"));
        Assert.That($"Measurement: {measurement:N4} units", Is.EqualTo("Measurement: 123,456.7891 units"));

        /* :P 百分比格式 */
        decimal tax = .36785m;
        Assert.That($"Tax rate: {tax:P}", Is.EqualTo("Tax rate: 36.79%"));
        Assert.That($"Tax rate: {tax:P4}", Is.EqualTo("Tax rate: 36.7850%"));
    }
}
