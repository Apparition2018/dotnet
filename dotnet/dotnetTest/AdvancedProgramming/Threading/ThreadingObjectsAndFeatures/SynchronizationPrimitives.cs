using dotnetTest.AdvancedProgramming.Threading.ManagedThreadingBasics;

namespace dotnetTest.AdvancedProgramming.Threading.ThreadingObjectsAndFeatures;

/// <summary>
/// <a href="https://learn.microsoft.com/zh-cn/dotnet/standard/threading/overview-of-synchronization-primitives">同步基元</a>
/// 同步对共享资源的访问、协调线程交互
/// </summary>
/// <seealso cref="SynchronizeDataForMultithreading.SynchronizationCodeRegions.BankAccount"/>
public abstract class SynchronizationPrimitives
{
    /// <summary>
    /// <a href="https://learn.microsoft.com/zh-cn/dotnet/standard/threading/overview-of-synchronization-primitives#synchronization-of-access-to-a-shared-resource">同步对共享资源的访问</a>
    /// <list type="bullet">
    /// <item><a href="https://learn.microsoft.com/zh-cn/dotnet/fundamentals/runtime-libraries/system-threading-monitor">Monitor</a></item>
    /// <item><a href="https://learn.microsoft.com/zh-cn/dotnet/standard/threading/mutexes">Mutex</a>：授予对共享资源的独占访问</item>
    /// <item><a href="https://learn.microsoft.com/zh-cn/dotnet/standard/threading/spinlock">SpinLock</a>：根据锁的可用性授予对共享资源的独占访问，在等待获取锁时自旋；适用于 极短临界区（执行时间短、低争用度、高频率访问）</item>
    /// <item><a href="https://learn.microsoft.com/zh-cn/dotnet/fundamentals/runtime-libraries/system-threading-readerwriterlockslim">ReaderWriterLockSlim</a>：用于管理对资源访问的锁，允许多个线程读取或独占访问写入</item>
    /// <item><a href="https://learn.microsoft.com/zh-cn/dotnet/standard/threading/semaphore-and-semaphoreslim">Semaphore 和 SemaphoreSlim</a>：限制可以同时访问资源或资源池的线程数量，SemaphoreSlim 是 Semaphore 的轻量级替代方案</item>
    /// </list>
    /// </summary>
    /// <remarks>Threading.md#同步基元</remarks>
    private class SynchronizationOfAccessTqoSharedResource;

    /// <summary>
    /// <a href="https://learn.microsoft.com/zh-cn/dotnet/standard/threading/overview-of-synchronization-primitives#thread-interaction-or-signaling">线程交互、线程信号</a>
    /// 线程必须等待来自一个或多个线程的通知或信号才能继续
    /// <para>
    /// <list type="bullet">
    /// <item><see cref="EventWaitHandleTests">EventWaitHandle</see>、AutoResetEvent、ManualResetEvent</item>
    /// <item>ManualResetEventSlim：ManualResetEvent 的轻量级替代；内部已集成 SpinWait 机制，优先在用户态下自旋，超时后自动切换至内核态等待</item>
    /// <item><see cref="CountdownEventTests">CountdownEvent</see></item>
    /// <item><see cref="BarrierTests">Barrier</see></item>
    /// </list>
    /// </para>
    /// </summary>
    public abstract class ThreadInteractionOrThreadSignaling
    {
        /// <summary>
        /// <a href="https://learn.microsoft.com/zh-cn/dotnet/standard/threading/eventwaithandle">EventWaitHandle</a>
        /// 借助 EventWaitHandle 类，线程可以通过发出信号和等待信号进行相互通信
        /// <para>
        /// 重置模式：
        /// <list type="bullet">
        /// <item>自动重置：EventResetMode.AutoReset，set() 释放单个等待线程后，标志会自动重置；派生类 AutoResetEvent，适用于互斥或单次通知</item>
        /// <item>手动重置：EventResetMode.ManualReset，set() 释放所有等待线程后，保持信号状态，直到调用其 Reset 方法；派生类 ManualResetEvent，适用于广播通知</item>
        /// </list>
        /// </para>
        /// </summary>
        private class EventWaitHandleTests;

        /// <summary>
        /// <a href="https://learn.microsoft.com/zh-cn/dotnet/standard/threading/countdownevent">CountdownEvent</a>
        /// <list type="bullet">
        /// <item>在收到信号特定次数后取消阻止等待线程</item>
        /// <item>使用场景：使用 ManualResetEvent 或 ManualResetEventSlim 并手动递减变量，然后再向事件发送信号</item>
        /// <item>
        /// 其它功能：
        /// <list type="bullet">
        /// <item>可以使用取消令牌取消等待操作</item>
        /// <item>创建实例后，可以递增信号计数</item>
        /// <item>在 Wait() 后调用 Reset()，可以重用实例</item>
        /// <item>实例公开了一个WaitHandle，以便与其他实例 .NET 同步API 集成</item>
        /// </list>
        /// </item>
        /// </list>
        /// </summary>
        private class CountdownEventTests
        {
            private const int TaskCount = 3;
            private static readonly ManualResetEvent Mre = new(false);
            private static readonly CountdownEvent Countdown = new(TaskCount);

            [Test]
            public void Test()
            {
                List<Task> tasks = Enumerable.Range(0, TaskCount)
                    .Select(_ => Task.Run(() =>
                    {
                        Console.WriteLine($"线程 {Environment.CurrentManagedThreadId} 等待执行...");
                        Countdown.Signal();
                        Mre.WaitOne();
                        Console.WriteLine($"线程 {Environment.CurrentManagedThreadId} 开始执行");
                    }))
                    .ToList();
                Countdown.Wait();
                Mre.Set();
                Task.WaitAll(tasks.ToArray());
            }
        }

        /// <summary>
        /// <a href="https://learn.microsoft.com/zh-cn/dotnet/standard/threading/barrier">Barrier</a>
        /// 使多个任务能够通过多个阶段并行地协同处理算法
        /// </summary>
        private class BarrierTests
        {
            [Test]
            public void Test()
            {
                int count = 0;

                // 创建具有2个参与者的 Barrier
                Barrier barrier = new(2, b =>
                {
                    Console.WriteLine("Post-Phase action: count={0}, phase={1}", count, b.CurrentPhaseNumber);
                    if (b.CurrentPhaseNumber == 1) throw new Exception("😄");
                });

                // 增加2个参与者
                barrier.AddParticipants(2);
                // 移除1个参与者，最终参与者数为3
                barrier.RemoveParticipant();

                // 所有参与者运行的逻辑
                Action action = () =>
                {
                    Enumerable.Range(0, 5).ToList().ForEach(_ =>
                    {
                        try
                        {
                            Interlocked.Increment(ref count);
                            // 指示参与者达到 barrier，并等待所有其它参与者达到 barrier
                            // 当所有参与者达到 barrier 后，执行一次 Post-Phase action
                            barrier.SignalAndWait();
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.InnerException?.Message);
                        }
                    });
                };

                // 启动3个并行动作服务3个参与者
                Parallel.Invoke(action, action, action);
            }
        }
    }

    /// <summary>
    /// <a href="https://learn.microsoft.com/zh-cn/dotnet/api/system.threading.waithandle">WaitHandle</a>
    /// <list type="bullet">
    /// <item>封装等待对共享资源进行独占访问的操作系统特定的对象</item>
    /// <item>派生自 MarshalByRefObject，因此其及其派生类可用于跨应用程序域边界同步线程的活动</item>
    /// </list>
    /// <para>
    /// 派生类：
    /// <list type="bullet">
    /// <item><see cref="SynchronizationOfAccessTqoSharedResource">同步对共享资源的访问</see>：Mutex、Semaphore</item>
    /// <item><see cref="ThreadInteractionOrThreadSignaling.EventWaitHandleTests">线程交互、线程信号</see>：EventWaitHandle、AutoResetEvent、ManualResetEvent</item>
    /// </list>
    /// </para>
    /// </summary>
    private class WaitHandleTests
    {
        private static readonly WaitHandle[] WaitHandles =
        [
            new EventWaitHandle(false, EventResetMode.AutoReset),
            new EventWaitHandle(false, EventResetMode.AutoReset)
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
            EventWaitHandle handle = (EventWaitHandle)state!;
            int time = 100 * R.Next(2, 9);
            Console.WriteLine("执行任务 {0} 毫秒", time);
            Thread.Sleep(time);
            handle.Set();
        }
    }

    /// <summary>
    /// <a href="https://learn.microsoft.com/zh-cn/dotnet/standard/threading/spinwait">SpinWait Struct</a>
    /// 提供 spin-based 等待；可以在低级场景中使用，避免内核事件昂贵的上下文切换和内核转换
    /// </summary>
    private class SpinWaitTests
    {
        private const int TaskCount = 3;
        private static readonly ManualResetEvent Mre = new(false);
        private static int _counter = TaskCount;

        [Test]
        public void Test()
        {
            List<Task> tasks = Enumerable.Range(0, TaskCount)
                .Select(_ => Task.Run(() =>
                {
                    Console.WriteLine($"线程 {Environment.CurrentManagedThreadId} 等待执行...");
                    Interlocked.Decrement(ref _counter);
                    Mre.WaitOne();
                    Console.WriteLine($"线程 {Environment.CurrentManagedThreadId} 开始执行");
                }))
                .ToList();
            SpinWait.SpinUntil(() => Volatile.Read(ref _counter) <= 0);
            Mre.Set();
            Task.WaitAll(tasks.ToArray());
        }
    }
}
