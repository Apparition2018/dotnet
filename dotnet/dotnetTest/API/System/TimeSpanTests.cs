namespace dotnetTest.API.System;

/// <summary>
/// <a href="https://learn.microsoft.com/zh-cn/dotnet/api/system.timespan">TimeSpan</a>
/// 时间间隔
/// </summary>
public class TimeSpanTests
{
    [Test]
    public void Test()
    {
        DateTime date1 = new DateTime(2010, 1, 1, 8, 0, 15);
        DateTime date2 = new DateTime(2010, 8, 18, 13, 30, 30);
        TimeSpan interval = date2 - date1;

        Assert.That(interval.Days, Is.EqualTo(229));
        Assert.That(interval.TotalDays, Is.EqualTo(229.22934027777777));
        Assert.That(interval.Hours, Is.EqualTo(5));
        Assert.That(interval.TotalHours, Is.EqualTo(5501.504166666667));
        Assert.That(interval.Minutes, Is.EqualTo(30));
        Assert.That(interval.TotalMinutes, Is.EqualTo(330090.25));
        Assert.That(interval.Seconds, Is.EqualTo(15));
        Assert.That(interval.TotalSeconds, Is.EqualTo(19805415));
        Assert.That(interval.Milliseconds, Is.EqualTo(0));
        Assert.That(interval.TotalMilliseconds, Is.EqualTo(19805415000));
        Assert.That(interval.Ticks, Is.EqualTo(198054150000000));
    }
}
