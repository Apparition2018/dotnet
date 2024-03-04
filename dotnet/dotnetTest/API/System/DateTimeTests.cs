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
        Assert.That(new DateTime(now.Ticks), Is.EqualTo(now));

        Assert.That(DateTime.MinValue.ToString(CurrentCulture), Is.EqualTo("0001/1/1 0:00:00"));
        Assert.That(DateTime.MinValue.Ticks, Is.EqualTo(0));
        Assert.That(DateTime.MaxValue.ToString(CurrentCulture), Is.EqualTo("9999/12/31 23:59:59"));
        Assert.That(DateTime.MaxValue.Ticks, Is.EqualTo(3155378975999999999));

        DateTime date = new DateTime(1979, 07, 28, 22, 35, 5, new CultureInfo("en-US", false).Calendar);
        DateTime date2 = DateTime.Parse("1979-07-28 22:35:5");
        Assert.That(date == date2, Is.EqualTo(true));
        Assert.That(date.AddDays(1).Day, Is.EqualTo(29));

        // 返回指定年的指定月份的天数
        Assert.That(DateTime.DaysInMonth(date.Year, date.Month), Is.EqualTo(31));
    }
}
