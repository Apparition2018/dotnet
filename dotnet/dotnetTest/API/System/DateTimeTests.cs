using System.Globalization;
using static System.Globalization.CultureInfo;

namespace dotnetTest.API.System;

/// <summary>
/// <a href="https://learn.microsoft.com/zh-cn/dotnet/api/system.datetime">DateTime</a>
/// </summary>
public class DateTimeTests
{
    [Test]
    public void Test()
    {
        DateTime now = DateTime.Now;
        Assert.That(now.Kind, Is.EqualTo(DateTimeKind.Local));

        DateTime dateTime = new DateTime(1979, 07, 28, 22, 35, 5, new CultureInfo("en-US", false).Calendar);
        DateOnly dateOnly = new DateOnly(1979, 07, 28);
        TimeOnly timeOnly = new TimeOnly(22, 35, 5);
        DateTime dateTime2 = new DateTime(dateOnly, timeOnly);
        Assert.That(dateTime == dateTime2, Is.EqualTo(true));
        DateTime dateTime3 = DateTime.Parse("1979-07-28 22:35:5");
        Assert.That(dateTime == dateTime3, Is.EqualTo(true));

        Assert.That(dateTime.AddDays(1).Day, Is.EqualTo(29));
        // 返回指定年的指定月份的天数
        Assert.That(DateTime.DaysInMonth(dateTime.Year, dateTime.Month), Is.EqualTo(31));
    }

    /// <summary>最小值和最大值</summary>
    [Test]
    public void MinValueAndMaxValue()
    {
        Assert.That(DateTime.MinValue.ToString(CurrentCulture), Is.EqualTo("0001/1/1 0:00:00"));
        Assert.That(DateTime.MinValue.Ticks, Is.EqualTo(0));
        Assert.That(DateTime.MaxValue.ToString(CurrentCulture), Is.EqualTo("9999/12/31 23:59:59"));
        Assert.That(DateTime.MaxValue.Ticks, Is.EqualTo(3155378975999999999));
    }
}
