namespace dotnetTest.API.System;

/// <summary>
/// <a href="https://learn.microsoft.com/zh-cn/dotnet/api/system.datetime">DateTime</a>
/// </summary>
public class DateTimeTests
{
    [Test]
    public void Test()
    {
        // static DateTime      Now                    获取一个当前日期和时间的 DateTime 对象，以本地时间表示
        Console.WriteLine(DateTime.Now);

        // DateTime             AddDays(double value)
        Console.WriteLine(DateTime.Now.AddDays(1));
    }
}
