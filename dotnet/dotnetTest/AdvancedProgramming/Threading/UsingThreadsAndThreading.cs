namespace dotnetTest.AdvancedProgramming.Threading;

/// <summary>
/// <a href="https://learn.microsoft.com/zh-cn/dotnet/standard/threading/using-threads-and-threading">使用线程和线程处理</a>
/// Thread.Priority 有5个优先级：Highest, AboveNormal, Normal, BelowNormal, Lowest
/// <list type="bullet">
/// <item><see cref="CreateThreadsAndPassData">Thread.Start</see>：启动</item>
/// <item><see cref="PauseAndInterruptThreads">Thread.Sleep, Thread.Interrupt</see>：暂停、中断</item>
/// <item>Thread.Priority：优先级；Highest, AboveNormal, Normal, BelowNormal, Lowest</item>
/// <item><see cref="CancelThreads">CancellationTokenSource</see>：取消</item>
/// </list>
/// </summary>
public class UsingThreadsAndThreading
{
    /// <summary>
    /// <a href="https://learn.microsoft.com/zh-cn/dotnet/standard/threading/creating-threads-and-passing-data-at-start-time">创建线程并传递数据</a>
    /// </summary>
    private class CreateThreadsAndPassData
    {
        private class ThreadWithState(string text, int number, ExampleCallback? callbackDelegate)
        {
            public void ThreadProc()
            {
                Console.WriteLine(text, number);
                callbackDelegate?.Invoke(1);
            }
        }

        private delegate void ExampleCallback(int lineCount);

        [Test]
        public void Test()
        {
            ThreadWithState tws = new ThreadWithState(
                "This report displays the number {0}.",
                42,
                ResultCallback
            );

            Thread t = new Thread(new ThreadStart(tws.ThreadProc));
            t.Start();
            Console.WriteLine("Main thread does some work, then waits.");
            t.Join();
            Console.WriteLine("Independent task has completed; main thread ends.");
            return;

            void ResultCallback(int lineCount)
            {
                Console.WriteLine("Independent task printed {0} lines.", lineCount);
            }
        }
    }

    /// <summary>
    /// <a href="https://learn.microsoft.com/zh-cn/dotnet/standard/threading/pausing-and-resuming-threads">暂停和中断线程</a>
    /// </summary>
    private class PauseAndInterruptThreads
    {
        /// <summary>
        /// Thread.Sleep
        /// <list type="bullet">
        /// <item>调用 Thread.Sleep 方法会导致当前线程立即受阻止</item>
        /// <item>直到另一个对睡眠线程调用 Thread.Interrupt 方法的线程中断它，或直到 Thread.Abort 方法调用终止它</item>
        /// <item>.NET 5+（包括 .NET Core）不再支持 Thread.Abort，可以使用 CancellationToken 来请求协作式取消操作</item>
        /// </list>
        /// </summary>
        [Test]
        public void Sleep()
        {
            var sleepingThread = new Thread(SleepIndefinitely)
            {
                Name = "Sleeping"
            };
            sleepingThread.Start();
            Thread.Sleep(200);
            sleepingThread.Interrupt();
            return;

            void SleepIndefinitely()
            {
                Console.WriteLine("Thread '{0}' about to sleep indefinitely.", Thread.CurrentThread.Name);
                try
                {
                    Thread.Sleep(Timeout.Infinite);
                }
                catch (ThreadInterruptedException)
                {
                    Console.WriteLine("Thread '{0}' awoken.", Thread.CurrentThread.Name);
                }
                catch (ThreadAbortException)
                {
                    Console.WriteLine("Thread '{0}' aborted.", Thread.CurrentThread.Name);
                }
                finally
                {
                    Console.WriteLine("Thread '{0}' executing finally block.", Thread.CurrentThread.Name);
                }
                Console.WriteLine("Thread '{0} finishing normal execution.", Thread.CurrentThread.Name);
            }
        }
    }

    /// <summary>
    /// <a href="https://learn.microsoft.com/zh-cn/dotnet/standard/threading/cancellation-in-managed-threads">取消线程</a>
    /// </summary>
    [Test]
    public void CancelThreads()
    {
        // 1.实例化 CancellationTokenSource 对象，此对象管理取消通知并将其发送给单个取消标记
        CancellationTokenSource cts = new CancellationTokenSource();

        // 2.将 CancellationTokenSource.Token 属性返回的标记传递给每个侦听取消的任务或线程
        ThreadPool.QueueUserWorkItem(new WaitCallback(DoSomeWork), cts.Token);
        Thread.Sleep(250);

        // 4.调用 CancellationTokenSource.Cancel 方法以提供取消通知
        cts.Cancel();
        Console.WriteLine("Cancellation set in token source...");
        Thread.Sleep(250);

        cts.Dispose();
        return;

        void DoSomeWork(object? obj)
        {
            if (obj is null)
                return;

            CancellationToken token = (CancellationToken)obj;

            for (int i = 0; i < 100000; i++)
            {
                // 3.为每个任务或线程提供响应取消的机制
                if (token.IsCancellationRequested)
                {
                    Console.WriteLine("In iteration {0}, cancellation has been requested...", i + 1);
                    break;
                }
                Thread.SpinWait(500000);
            }
        }
    }
}
