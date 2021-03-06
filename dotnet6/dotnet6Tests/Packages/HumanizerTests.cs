using Humanizer;
using NUnit.Framework;

namespace dotnet6Tests.Packages;

/// <summary>Humanizer</summary>
/// <remarks>https://humanizr.net/</remarks>
public class HumanizerTests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void InflectorExtensions()
    {
        Assert.AreEqual("car".Pluralize(), "cars");
        Assert.AreEqual("octopus".Pluralize(), "octopi");
    }

    [Test]
    public void NumberToWordsExtension()
    {
        Assert.AreEqual(12345.ToWords(), "一万二千三百四十五");
    }
}