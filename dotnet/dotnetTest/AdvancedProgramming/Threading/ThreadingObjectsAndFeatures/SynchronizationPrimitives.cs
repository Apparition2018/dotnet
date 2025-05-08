using dotnetTest.AdvancedProgramming.Threading.ManagedThreadingBasics;

namespace dotnetTest.AdvancedProgramming.Threading.ThreadingObjectsAndFeatures;

/// <summary>
/// <a href="https://learn.microsoft.com/zh-cn/dotnet/standard/threading/overview-of-synchronization-primitives">同步基元</a>
/// 同步对共享资源的访问、协调线程交互
/// </summary>
public class SynchronizationPrimitives
{
    /// <summary>
    /// <a href="https://learn.microsoft.com/zh-cn/dotnet/api/system.threading.waithandle">WaitHandle</a>
    /// <list type="bullet">
    /// <item>封装等待对共享资源进行独占访问的操作系统特定的对象</item>
    /// <item>派生自 MarshalByRefObject，因此其及其派生类可用于跨应用程序域边界同步线程的活动</item>
    /// </list>
    /// <para>
    /// 派生类：
    /// <list type="number">
    /// <item><see cref="SynchronizationOfAccessToSharedResource.MutexTests">Mutex</see></item>
    /// <item><see cref="">Semaphore</see></item>
    /// <item><see cref="">EventWaitHandle</see></item>
    /// <item><see cref="">AutoResetEvent</see></item>
    /// <item><see cref="">ManualResetEvent</see></item>
    /// </list>
    /// </para>
    /// </summary>
    private class WaitHandleTests
    {
        private static readonly WaitHandle[] WaitHandles =
        [
            new AutoResetEvent(false),
            new AutoResetEvent(false)
        ];

        private static readonly Random R = new();

        [Test]
        public void Test()
        {
            DateTime dt = DateTime.Now;
            Console.WriteLine("主线程正在等待两个任务完成");
            ThreadPool.QueueUserWorkItem(DoTask, WaitHandles[0]);
            ThreadPool.QueueUserWorkItem(DoTask, WaitHandles[1]);
            WaitHandle.WaitAll(WaitHandles);
            Console.WriteLine("两项任务均已完成（{0}）", (DateTime.Now - dt).TotalMilliseconds);
            Console.WriteLine();

            dt = DateTime.Now;
            Console.WriteLine("主线程正在等待任一任务完成");
            ThreadPool.QueueUserWorkItem(DoTask, WaitHandles[0]);
            ThreadPool.QueueUserWorkItem(DoTask, WaitHandles[1]);
            int index = WaitHandle.WaitAny(WaitHandles);
            Console.WriteLine("任务 {0} 首先完成（{1}）", index + 1, (DateTime.Now - dt).TotalMilliseconds);
        }

        private static void DoTask(object? state)
        {
            AutoResetEvent are = (AutoResetEvent) state!;
            int time = 100 * R.Next(2, 9);
            Console.WriteLine("执行任务 {0} 毫秒", time);
            Thread.Sleep(time);
            are.Set();
        }
    }

    /// <summary>
    /// <a href="https://learn.microsoft.com/zh-cn/dotnet/standard/threading/overview-of-synchronization-primitives#synchronization-of-access-to-a-shared-resource">同步对共享资源的访问</a>
    /// <list>
    /// <item><see cref="SynchronizeDataForMultithreading.SynchronizationCodeRegions.BankAccount.MonitorDeposit">Monitor</see></item>
    /// <item><see cref="SynchronizationOfAccessToSharedResource.MutexTests">Mutex</see></item>
    /// <item><see cref="SynchronizationOfAccessToSharedResource.MutexTests">SpinLock</see></item>
    /// <item><a href="https://learn.microsoft.com/zh-cn/dotnet/api/system.threading.readerwriterlockslim">ReaderWriterLockSlim：用于管理对资源访问的锁，允许多个线程读取或独占访问写入</a></item>
    /// </list>
    /// </summary>
    /// <seealso cref="SynchronizeDataForMultithreading.SynchronizationCodeRegions.BankAccount"/>
    private class SynchronizationOfAccessToSharedResource
    {
        /// <summary>
        /// <a href="https://learn.microsoft.com/zh-cn/dotnet/standard/threading/mutexes">Mutexes</a>
        /// <a href="https://learn.microsoft.com/zh-cn/dotnet/api/system.threading.mutex">Mutex</a>
        /// 可用于提供对资源的独占访问权限
        /// <para>
        /// VS Monitor
        /// <list type="bullet">
        /// <item>同步机制：Monitor 基于应用级别的锁，仅在同一进程的线程间同步；Mutex 是内核级同步对象，支持跨进程线程同步</item>
        /// <item>性能：Monitor 锁操作再用户模型下完成，上下文切换开销小；Mutex 锁操作涉及内核模式切换，开销较大</item>
        /// <item>容错性：Monitor 需要确保 Exit 的调用；Mutex 在线程异常终止时，操作系统会自动释放 Mutex</item>
        /// </list>
        /// </para>
        /// </summary>
        private class MutexTests;

        /// <summary>
        /// <a href="https://learn.microsoft.com/zh-cn/dotnet/standard/threading/spinlock">SpinLock</a>
        /// <a href="https://learn.microsoft.com/zh-cn/dotnet/api/system.threading.spinlock">SpinLock Struct</a>
        /// 在等待获取锁时自旋
        /// <para>
        /// VS Monitor
        /// <list type="bullet">
        /// <item>线程是否挂起：Monitor 自旋失败后挂起线程；SpinLock 线程保持活动状态</item>
        /// <item>CPU占用：Monitor 挂起后释放 CPU 资源；SpinLock 持续自旋消耗 CPU 资源</item>
        /// <item>适用场景：Monitor 大多数场景；SpinLock 在多核计算机上，极短临界区（执行时间短、低争用度、高频率访问）</item>
        /// </list>
        /// </para>
        /// </summary>
        private class SpinLockTests;
    }
}
