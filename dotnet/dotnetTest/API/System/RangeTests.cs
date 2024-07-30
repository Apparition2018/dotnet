namespace dotnetTest.API.System;

/// <summary>
/// <a href="https://learn.microsoft.com/zh-cn/dotnet/api/system.range">Range</a>
/// </summary>
public class RangeTests
{
    /// <summary>
    /// <a href="https://learn.microsoft.com/zh-cn/dotnet/csharp/tutorials/ranges-indexes">隐式范围运算符表达式转换</a>
    /// </summary>
    [Test]
    public void ImplicitRangeOperatorExpressionConversions()
    {
        Range implicitRange = 3..^5;

        Range explicitRange = new(
            start: new Index(value: 3, fromEnd: false),
            end: new Index(value: 5, fromEnd: true));

        if (implicitRange.Equals(explicitRange))
        {
            Console.WriteLine(
                $"The implicit range '{implicitRange}' equals the explicit range '{explicitRange}'");
        }
    }
}
