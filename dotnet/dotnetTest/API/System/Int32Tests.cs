namespace dotnetTest.API.System;

/// <summary>
/// <a href="https://learn.microsoft.com/zh-cn/dotnet/api/system.int32">Int32</a>
/// </summary>
public class Int32Tests
{
    [Test]
    public void Test()
    {
        Assert.That(int.Parse("5") + int.Parse("7"), Is.EqualTo(12));
        if (int.TryParse("123", out int result))
        {
            Assert.That(result, Is.EqualTo(123));
        }
    }
}
