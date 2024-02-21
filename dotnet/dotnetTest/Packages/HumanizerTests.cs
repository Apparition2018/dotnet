using System.Globalization;
using Humanizer;

namespace dotnetTest.Packages;

/// <summary>
/// <a href="https://github.com/Humanizr/Humanizer">Humanizer</a>
/// </summary>
/// <remarks>
/// <a href="https://www.nuget.org/packages/Humanizer">NuGet Gallery</a>
/// </remarks>
public class HumanizerTests
{
    /// <summary>Inflector</summary>
    [Test]
    public void InflectorExtensions()
    {
        Assert.That("car".Pluralize(), Is.EqualTo("cars"));
        Assert.That("octopus".Pluralize(), Is.EqualTo("octopi"));
    }

    /// <summary>将数字转换为单词</summary>
    [Test]
    public void NumberToWordsExtension()
    {
        Assert.That(12345.ToWords(), Is.EqualTo("一万二千三百四十五"));
        Assert.That(12345.ToWords(CultureInfo.CurrentCulture), Is.EqualTo("一万二千三百四十五"));
        Assert.That(12345.ToWords(CultureInfo.InvariantCulture), Is.EqualTo("twelve thousand three hundred and forty-five"));
    }
}
