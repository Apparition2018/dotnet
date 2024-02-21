namespace dotnetTest.Guide.LanguageReference.Statements;

/// <summary>
/// <a href="https://learn.microsoft.com/zh-cn/dotnet/csharp/language-reference/statements/checked-and-unchecked">checked 和 unchecked 语句</a>
/// </summary>
public class CheckedAndUncheckedStatements
{
    [Test]
    public void Test()
    {
        uint i = uint.MaxValue;
        double d = double.MaxValue;

        try
        {
            // 执行溢出检查，溢出时抛出 OverflowException
            checked
            {
                Console.WriteLine(i + 3);
            }
            Console.WriteLine(checked((int) d));
        }
        catch (OverflowException e)
        {
            Assert.That(e.Message, Is.EqualTo("Arithmetic operation resulted in an overflow."));
        }

        // 不执行溢出检查
        unchecked
        {
            Assert.That(i + 3, Is.EqualTo(2));
        }
        Assert.That(unchecked((int) d), Is.EqualTo(-2147483648));
    }
}
