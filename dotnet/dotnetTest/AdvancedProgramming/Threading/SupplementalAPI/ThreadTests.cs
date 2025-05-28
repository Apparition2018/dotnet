using System.Diagnostics;

namespace dotnetTest.AdvancedProgramming.Threading.SupplementalAPI;

/// <summary>
/// <a href="https://learn.microsoft.com/en-us/dotnet/fundamentals/runtime-libraries/system-threading-thread">Thread</a>
/// <para>
/// 前台线程 vs 后台线程：
/// <list type="bullet">
/// <item>前台线程：①主应用程序线程；②所有通过调用 Thread 类构造函数创建的线程</item>
/// <item>后台线程：①线程池线程；②所有从非托管代码进入托管执行环境的线程</item>
/// <item>一旦所有前台线程都已停止，运行时将停止所有后台线程并关闭</item>
/// </list>
/// </para>
/// </summary>
public class ThreadTests
{

    /// <summary>
    /// <a href="https://learn.microsoft.com/zh-cn/dotnet/fundamentals/runtime-libraries/system-threading-thread#start-a-thread">启动线程</a>
    /// 通过在类构造函数中提供一个代表线程要执行的方法的委托来启动线程，然后调用 Start 方法开始执行；
    /// 线程启动后不必保留对 Thread 对象的引用，线程会一直执行直到完成。
    /// <para>
    /// Thread 构造函数可以接受两种委托类型，取决于是否将参数传递给要执行的方法：
    /// <list type="bullet">
    /// <item>方法没有参数，向构造传递 <see cref="ThreadStart"/> 委托</item>
    /// <item>方法有参数，向构造传递 <see cref="ParameterizedThreadStart"/> 委托</item>
    /// </list>
    /// </para>
    /// </summary>
    private class StartThread
    {
        [Test]
        public void ParameterizedThreadStart()
        {
            Thread th = new Thread(ExecuteInForeground!);
            th.Start(5000);
            Thread.Sleep(1000);
            Console.WriteLine($"Main thread ({Environment.CurrentManagedThreadId}) exiting...");
            Thread.Sleep(1000);
        }

        private static void ExecuteInForeground(object obj)
        {
            int interval;
            try {
                interval = (int) obj;
            }
            catch (InvalidCastException) {
                interval = 5000;
            }
            Stopwatch sw = Stopwatch.StartNew();
            Console.WriteLine("Thread {0}: {1}, Priority {2}",
                Environment.CurrentManagedThreadId, Thread.CurrentThread.ThreadState, Thread.CurrentThread.Priority);
            do {
                Console.WriteLine($"Thread {Environment.CurrentManagedThreadId}: Elapsed {sw.ElapsedMilliseconds / 1000.0:N2} seconds");
                Thread.Sleep(500);
            } while (sw.ElapsedMilliseconds <= interval);
            sw.Stop();
        }
    }

    /// <summary>
    /// <a href="https://learn.microsoft.com/zh-cn/dotnet/fundamentals/runtime-libraries/system-threading-thread#retrieve-thread-objects">检索 Thread 对象</a>
    /// 使用静态的 <see cref="Thread.CurrentThread"/> 属性获取当前正在执行线程的引用
    /// </summary>
    private class RetrieveThreadObjects
    {
        private static readonly object Obj = new();

        [Test]
        public void CurrentThread()
        {
            ThreadPool.QueueUserWorkItem(ShowThreadInformation,  "线程池线程");

            Thread th1 = new Thread(ShowThreadInformation);
            th1.Start("前台线程");

            Thread th2 = new Thread(ShowThreadInformation);
            th2.IsBackground = true;
            th2.Start("后台线程");

            ShowThreadInformation("主线程");
        }

        private static void ShowThreadInformation(object? state)
        {
            lock (Obj) {
                Thread th  = Thread.CurrentThread;
                Console.WriteLine($"{state} #{th.ManagedThreadId}: ");
                Console.WriteLine($"   Background thread: {th.IsBackground}");
                Console.WriteLine($"   Thread pool thread: {th.IsThreadPoolThread}");
                Console.WriteLine($"   Priority: {th.Priority}");
                Console.WriteLine($"   Culture: {th.CurrentCulture.Name}");
                Console.WriteLine($"   UI culture: {th.CurrentUICulture.Name}");
                Console.WriteLine();
            }
        }
    }
}
