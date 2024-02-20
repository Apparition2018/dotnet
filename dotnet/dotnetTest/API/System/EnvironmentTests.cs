namespace dotnetTest.API.System;

/// <summary>
/// <a href="https://learn.microsoft.com/zh-cn/dotnet/api/system.environment">Environment</a>
/// </summary>
public class EnvironmentTests
{
    [Test]
    public void Test()
    {
        Assert.That(Environment.SpecialFolder.Desktop.ToString(), Is.EqualTo("Desktop"));
        Assert.That(Environment.SpecialFolder.MyDocuments.ToString(), Is.EqualTo("MyDocuments"));

        // static string    CurrentDirectory        获取或设置当前工作目录的完全限定路径
        Assert.That(Environment.CurrentDirectory,
            Is.EqualTo(@"D:\Liang\git\dotnet\dotnet\dotnetTest\bin\Debug\net8.0"));
        // static string    NewLin                  获取为此环境定义的换行字符串
        Assert.That(Environment.NewLine, Is.EqualTo("\r\n"));
    }
}
