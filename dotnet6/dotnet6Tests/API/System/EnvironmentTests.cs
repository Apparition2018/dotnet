using System;
using NUnit.Framework;

namespace dotnet6Tests.API.System;

public class EnvironmentTests
{
    [Test]
    public void Test()
    {
        Assert.AreEqual(Environment.SpecialFolder.Desktop.ToString(), "Desktop");
        Assert.AreEqual(Environment.SpecialFolder.MyDocuments.ToString(), "MyDocuments");

        Assert.AreEqual(Environment.NewLine, "\r\n");
    }
}