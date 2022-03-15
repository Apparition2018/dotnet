using System.Globalization;
using System.IO;
using dotnet6.L;
using NUnit.Framework;

namespace dotnet6Tests.API.System.IO;

public class IoTests : Demo
{
    [Test]
    public void DirectoryInfo()
    {
        DirectoryInfo info = new DirectoryInfo(DotNet6Path);
        Assert.AreEqual(info.Name, "dotnet6");
        Assert.AreEqual(info.FullName, @"D:\Liang\git\dotnet\dotnet6\dotnet6");
        Assert.AreEqual(info.CreationTime.ToString(CultureInfo.CurrentCulture), "2022/3/13 19:38:43");
    }

    [Test]
    public void FileInfo()
    {
        FileInfo info = new FileInfo(StartUpPath);
        Assert.AreEqual(info.Name, "Startup.cs");
        Assert.AreEqual(info.FullName, @"D:\Liang\git\dotnet\dotnet6\dotnet6\Startup.cs");
        Assert.AreEqual(info.DirectoryName, @"D:\Liang\git\dotnet\dotnet6\dotnet6");
        Assert.AreEqual(info.Extension, ".cs");
        Assert.AreEqual(info.CreationTime.ToString(CultureInfo.CurrentCulture), "1601/1/1 8:00:00");
    }
}