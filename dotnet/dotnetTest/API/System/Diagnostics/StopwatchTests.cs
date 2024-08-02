using System.Diagnostics;

namespace dotnetTest.API.System.Diagnostics;

/// <summary>
/// <a href="https://learn.microsoft.com/zh-cn/dotnet/api/system.diagnostics.stopwatch">StopWatch</a>
/// 提供一组方法和属性，可用于准确地测量运行时间
/// </summary>
public class StopwatchTests
{
    [Test]
    public void Test()
    {
        Stopwatch stopWatch = new Stopwatch();
        stopWatch.Start();
        Thread.Sleep(10000);
        stopWatch.Stop();
        // Get the elapsed time as a TimeSpan value.
        TimeSpan ts = stopWatch.Elapsed;

        // Format and display the TimeSpan value.
        string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
            ts.Hours, ts.Minutes, ts.Seconds, ts.Milliseconds / 10);
        Console.WriteLine("RunTime " + elapsedTime);
    }
}
