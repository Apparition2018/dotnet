namespace dotnetTest.API.System;

/// <summary>
/// <a href="https://learn.microsoft.com/zh-cn/dotnet/api/system.math">Math</a>
/// </summary>
public class MathTests
{
    [Test]
    public void Test()
    {
        // 生成两个有符号 32 位数字的商和余数
        var (quotient, remainder) = Math.DivRem(10, 3);
        Assert.That(quotient, Is.EqualTo(3));
        Assert.That(remainder, Is.EqualTo(1));
    }
}
