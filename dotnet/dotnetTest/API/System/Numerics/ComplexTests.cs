using System.Numerics;

namespace dotnetTest.API.System.Numerics;

/// <summary>
/// <a href="https://learn.microsoft.com/zh-cn/dotnet/api/system.reflection.assembly">Complex Struct</a>
/// 表示复数
/// </summary>
public class ComplexTests
{
    /// <summary>字段</summary>
    [Test]
    public void Fields()
    {
        Assert.That(Complex.Infinity, Is.EqualTo(new Complex(Double.PositiveInfinity, Double.PositiveInfinity)));
        Assert.That(Complex.NaN, Is.EqualTo(new Complex(Double.NaN, Double.NaN)));
        Assert.That(Complex.Zero, Is.EqualTo(new Complex(0, 0)));
        Assert.That(Complex.One, Is.EqualTo(new Complex(1, 0)));
        Assert.That(Complex.ImaginaryOne, Is.EqualTo(new Complex(0, 1)));
    }
}
