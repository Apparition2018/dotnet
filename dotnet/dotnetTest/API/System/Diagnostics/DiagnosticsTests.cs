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
        // 获取所有进程
        Process[] processes = Process.GetProcesses();
        Process process = processes[^1];
        Console.WriteLine($"进程ID：{process.Id}");
        Console.WriteLine($"进程名称：{process.ProcessName}");
        Console.WriteLine($"进程本机句柄：{process.Handle}");
        Console.WriteLine($"进程打开的句柄数：{process.HandleCount}");
        Console.WriteLine($"进程基本优先级：{process.BasePriority}");
        Console.WriteLine($"进程启动时间：{process.StartTime}");

        // 获取进程加载的模块
        ProcessModuleCollection processModuleCollection = process.Modules;
        ProcessModule processModule = processModuleCollection[0];
        Console.WriteLine($"模块完整路径：{processModule.FileName}");

        // 启动进程
        Process baidu = Process.Start(@"C:\Program Files (x86)\Microsoft\Edge\Application\msedge.exe", BaiDuHost);
        // 停止进程
        baidu.Kill();
        // 释放资源
        baidu.Close();
    }
}
