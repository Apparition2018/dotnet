using System.Globalization;
using dotnet.L.Demo;

namespace dotnetTest.API.System.IO;

/// <summary>
/// <a href="https://learn.microsoft.com/zh-cn/dotnet/api/system.io">IO</a>
/// </summary>
public class IoTests : Demo
{
    /// <summary>
    /// <a href="https://learn.microsoft.com/zh-cn/dotnet/api/system.io.directoryinfo">DirectoryInfo</a>
    /// </summary>
    [Test]
    public void DirectoryInfo()
    {
        DirectoryInfo info = new DirectoryInfo(DemoDirPath);
        Assert.That(info.Name, Is.EqualTo(DemoDirName));
        Assert.That(info.FullName, Is.EqualTo(DemoDirPath));
        Assert.That(info.CreationTime.ToString(CultureInfo.CurrentCulture), Is.EqualTo("2024/2/21 8:13:51"));
    }

    /// <summary>
    /// <a href="https://learn.microsoft.com/zh-cn/dotnet/api/system.io.fileinfo">FileInfo</a>
    /// </summary>
    [Test]
    public void FileInfo()
    {
        FileInfo info = new FileInfo(DemoFilePath);
        Assert.That(info.Name, Is.EqualTo(DemoFileName));
        Assert.That(info.FullName, Is.EqualTo(DemoFilePath));
        Assert.That(info.DirectoryName, Is.EqualTo(DemoDirPath));
        Assert.That(info.Extension, Is.EqualTo(string.Empty));
        Assert.That(info.CreationTime.ToString(CultureInfo.CurrentCulture), Is.EqualTo("2024/2/21 8:13:51"));
    }
}
