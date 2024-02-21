using System.Diagnostics;
using dotnet.L.Demo;

namespace dotnetTest.API.System.Diagnostics;

/// <summary>
/// <a href="https://learn.microsoft.com/zh-cn/dotnet/api/system.diagnostics">System.Diagnostics</a>
/// 提供允许你与系统进程、事件日志和性能计数器进行交互的类
/// </summary>
public class DiagnosticsTests : Demo
{
    /// <summary>
    /// <a href="https://learn.microsoft.com/zh-cn/dotnet/api/system.diagnostics.debug">Debug</a>
    /// </summary>
    [Test]
    public void Debug_()
    {
        // static void          WriteLineIf(bool condition, string? message)
        Debug.WriteLineIf(true, bool.TrueString);

        // static void          Assert([DoesNotReturnIf(false)] bool condition, string? message)
        Debug.Assert(true, bool.TrueString);
    }

    /// <summary>
    /// <a href="https://learn.microsoft.com/zh-cn/dotnet/api/system.diagnostics.process">Process</a>
    /// 提供对本地和远程进程的访问权限并使你能够启动和停止本地系统进程
    /// </summary>
    [Test]
    public void Process_()
    {
        Assert.That(Process.GetCurrentProcess().ProcessName, Is.EqualTo(Dotnet));
    }
}
