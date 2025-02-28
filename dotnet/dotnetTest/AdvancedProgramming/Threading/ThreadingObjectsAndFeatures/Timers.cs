using System.Timers;
using Timer = System.Threading.Timer;

namespace dotnetTest.AdvancedProgramming.Threading.ThreadingObjectsAndFeatures;

/// <summary>
/// <a href="https://learn.microsoft.com/zh-cn/dotnet/standard/threading/timers">Timers 计时器</a>
/// <list type="number">
/// <item><see cref="ThreadingTimer">System.Threading.Timer</see></item>
/// <item><see cref="TimersTimer">System.Timers.Timer</see></item>
/// <item><see cref="PeriodicTimer">System.Threading.PeriodicTimer</see></item>
/// </list>
/// </summary>
public abstract class Timers
{
    private const int InitialIntervalMs = 250;
    private const int UpdatedIntervalMs = 100;
    private const int MaxTriggerCount = 4;

    /// <summary>
    /// <a href="https://learn.microsoft.com/zh-cn/dotnet/api/system.threading.timer">System.Threading.Timer</a>
    /// </summary>
    private class ThreadingTimer
    {
        [Test]
        public void Test()
        {
            using AutoResetEvent autoResetEvent = new AutoResetEvent(false);
            StatusChecker statusChecker = new StatusChecker(MaxTriggerCount);

            // 0 秒后执行，每 1/4 秒执行一次
            Console.WriteLine($"{DateTime.Now:h:mm:ss.fff} Creating timer (Initial interval: {InitialIntervalMs}ms)");
            using Timer timer = new Timer(statusChecker.CheckStatus, autoResetEvent, 0, InitialIntervalMs);
            autoResetEvent.WaitOne();

            // 更改周期，每 0.1 秒一次
            Console.WriteLine($"\n{DateTime.Now:h:mm:ss.fff} Changing period to {UpdatedIntervalMs}ms");
            timer.Change(0, UpdatedIntervalMs);
            autoResetEvent.WaitOne();
        }

        private class StatusChecker(int maxCount)
        {
            private int _invokeCount;

            // 此方法由 timer 委托调用
            public void CheckStatus(object? stateInfo)
            {
                AutoResetEvent autoEvent = (AutoResetEvent)stateInfo!;
                Interlocked.Increment(ref _invokeCount);
                Console.WriteLine($"{DateTime.Now:hh:mm:ss.fff} Checking status #{_invokeCount}");
                if (_invokeCount < maxCount) return;
                Interlocked.Exchange(ref _invokeCount, 0);
                autoEvent.Set();
            }
        }
    }

    /// <summary>
    /// <a href="https://learn.microsoft.com/zh-cn/dotnet/api/system.timers.timer">System.Timers.Timer</a>
    /// </summary>
    private class TimersTimer
    {
        [Test]
        public void Test()
        {
            using AutoResetEvent autoEvent = new AutoResetEvent(false);
            StatusChecker statusChecker = new StatusChecker(MaxTriggerCount, autoEvent);

            Console.WriteLine($"{DateTime.Now:h:mm:ss.fff} Creating timer (Initial interval: {InitialIntervalMs}ms)");
            using System.Timers.Timer timer = new System.Timers.Timer(InitialIntervalMs);
            timer.Elapsed += statusChecker.CheckStatus;
            timer.AutoReset = true;
            timer.Start();
            autoEvent.WaitOne();
            timer.Stop();

            Console.WriteLine($"\n{DateTime.Now:h:mm:ss.fff} Changing period to {UpdatedIntervalMs}ms");
            timer.Interval = UpdatedIntervalMs;
            timer.Start();
            autoEvent.WaitOne();
            timer.Stop();
        }

        private class StatusChecker(int maxCount, AutoResetEvent autoEvent)
        {
            private int _invokeCount;

            public void CheckStatus(object? sender, ElapsedEventArgs e)
            {
                Interlocked.Increment(ref _invokeCount);
                Console.WriteLine($"{DateTime.Now:hh:mm:ss.fff} Checking status #{_invokeCount}");
                if (_invokeCount < maxCount) return;
                Interlocked.Exchange(ref _invokeCount, 0);
                autoEvent.Set();
            }
        }
    }

    /// <summary>
    /// <a href="https://learn.microsoft.com/zh-cn/dotnet/api/system.threading.periodictimer">PeriodicTimer</a>
    /// </summary>
    public class PeriodicTimerImplementation
    {
        [Test]
        public async Task Test()
        {
            Console.WriteLine($"{DateTime.Now:h:mm:ss.fff} Creating timer (Initial interval: {InitialIntervalMs}ms)");
            await RunTimerPhase(TimeSpan.FromMilliseconds(InitialIntervalMs), MaxTriggerCount);

            Console.WriteLine($"\n{DateTime.Now:h:mm:ss.fff} Changing period to {UpdatedIntervalMs}ms");
            await RunTimerPhase(TimeSpan.FromMilliseconds(UpdatedIntervalMs), MaxTriggerCount);
        }

        private static async Task RunTimerPhase(TimeSpan interval, int maxCount)
        {
            using var timer = new PeriodicTimer(interval);
            using var cts = new CancellationTokenSource();
            var invokeCount = 0;
            try
            {
                while (await timer.WaitForNextTickAsync(cts.Token))
                {
                    invokeCount++;
                    Console.WriteLine($"{DateTime.Now:hh:mm:ss.fff} Checking status #{invokeCount}");
                    if (invokeCount < maxCount) continue;
                    cts.Cancel();
                    break;
                }
            }
            catch (OperationCanceledException)
            {
                // 当通过 CancellationTokenSource.Cancel() 主动取消异步操作时，框架会抛出 OperationCanceledException，无需处理
            }
        }
    }
}
