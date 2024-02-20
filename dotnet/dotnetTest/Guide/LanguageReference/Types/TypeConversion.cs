namespace dotnetTest.Guide.LanguageReference.Types;

/// <summary>
/// <a href="https://learn.microsoft.com/zh-cn/dotnet/standard/base-types/type-conversion">类型转换</a>
/// </summary>
public class TypeConversion
{
    [Test]
    public void Test()
    {
        /* Int32 */
        // string → int
        // int      Parse(string s)
        Assert.That(int.Parse("5") + int.Parse("7"), Is.EqualTo(12));
        // bool     TryParse(string? s, out int result)
        if (int.TryParse("123", out int result))
        {
            Assert.That(result, Is.EqualTo(123));
        }

        /* Convert */
        // int      ToInt32(Decimal value)
        Assert.That((int)1.5m, Is.EqualTo(1));
        Assert.That(Convert.ToInt32(1.5m), Is.EqualTo(2));
    }
}
