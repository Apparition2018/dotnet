namespace dotnetTest.API.System.Threading;

/// <summary>
/// <a href="https://learn.microsoft.com/zh-cn/dotnet/api/system.threading.threadpool">ThreadPool</a>
/// <a href="https://learn.microsoft.com/zh-cn/dotnet/standard/threading/the-managed-thread-pool">ThreadPool</a>
/// </summary>
public class ThreadPoolTests
{
    [Test]
    public void GetThreads()
    {
        // 返回最大线程池线程数和当前活动线程数之间的差值
        ThreadPool.GetAvailableThreads(out int workerThreads, out int portThreads);
        Console.WriteLine("\n可用工作线程数：\t{0}\n可用异步IO线程数：\t{1}", workerThreads, portThreads);

        ThreadPool.GetMaxThreads(out workerThreads, out portThreads);
        Console.WriteLine("\n最大可用工作线程数：\t{0}\n最大异步IO线程数：\t{1}", workerThreads, portThreads);

        ThreadPool.GetMinThreads(out workerThreads, out portThreads);
        Console.WriteLine("\n最小可用工作线程数：\t{0}\n最小异步IO线程数：\t{1}", workerThreads, portThreads);
    }

    /// <summary>
    /// <a href="https://learn.microsoft.com/zh-cn/dotnet/api/system.threading.threadpool.queueuserworkitem">QueueUserWorkItem</a>
    /// 以队列方式执行方法
    /// </summary>
    [Test]
    public void QueueUserWorkItem()
    {
        ThreadPool.QueueUserWorkItem(ThreadProc);
        Console.WriteLine("Main thread does some work, then sleeps.");
        Thread.Sleep(1000);

        Console.WriteLine("Main thread exits.");
        return;

        void ThreadProc(object? stateInfo)
        {
            Console.WriteLine("Hello from the thread pool.");
        }
    }
}
