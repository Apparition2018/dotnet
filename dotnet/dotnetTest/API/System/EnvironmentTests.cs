namespace dotnetTest.API.System;

/// <summary>
/// <a href="https://learn.microsoft.com/zh-cn/dotnet/api/system.environment">Environment</a>
/// </summary>
public class EnvironmentTests
{
    [Test]
    public void Test()
    {
        // 指定用于检索系统特殊文件夹的目录路径的枚举常量
        Assert.That(Environment.SpecialFolder.Desktop.ToString(), Is.EqualTo("Desktop"));
        // 获取可用于当前进程的处理器数
        Assert.That(Environment.ProcessorCount, Is.EqualTo(12));
        // 获取或设置当前工作目录的完全限定路径
        Assert.That(Environment.CurrentDirectory, Is.EqualTo(@"D:\Liang\git\dotnet\dotnet\dotnetTest\bin\Debug\net8.0"));
        // 获取为此环境定义的换行字符串
        Assert.That(Environment.NewLine, Is.EqualTo("\r\n"));
        // 获取当前托管线程的唯一标识符
        Assert.That(Environment.CurrentManagedThreadId, Is.EqualTo(14));
    }
}
