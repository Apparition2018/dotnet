using System.Globalization;

namespace dotnetTest.API.System;

/// <summary>
/// <a href="https://learn.microsoft.com/zh-cn/dotnet/api/system.iformatprovider">IFormatProvider</a>
/// 支持区域性专用格式设置
/// </summary>
/// <remarks>
/// <a href="https://learn.microsoft.com/zh-cn/dotnet/standard/base-types/formatting-types#culture-sensitive-formatting-with-format-providers">使用格式提供程序进行区分区域性的格式设置</a>
/// </remarks>
public class IFormatProviderTests
{
    [Test]
    public void Test()
    {
        decimal value = 603.42m;
        Assert.That(value.ToString("C3", new CultureInfo("en-US")), Is.EqualTo("$603.420"));
        Assert.That(value.ToString("C3", new CultureInfo("fr-FR")), Is.EqualTo("603,420 €"));
        Assert.That(value.ToString("C3", new CultureInfo("zh-cn")), Is.EqualTo("¥603.420"));
    }
}
