namespace dotnetTest.AdvancedProgramming.Threading.SupplementalAPI;

/// <summary>
/// <a href="https://learn.microsoft.com/zh-cn/dotnet/fundamentals/runtime-libraries/system-threading-tasks-taskscheduler">TaskScheduler</a>
/// 任务调度器。默认情况下，Task.Run 和 Task.Factory.StartNew 会使用 TaskScheduler.Default
/// </summary>
public class TaskSchedulerTests
{
    /// <summary>
    /// <a href="https://learn.microsoft.com/zh-cn/dotnet/api/system.threading.tasks.taskscheduler">TaskScheduler</a>
    /// </summary>
    /// <remarks>
    /// <a href="https://github.com/dotnet/samples/tree/main/csharp/parallel/ParallelExtensionsExtras/TaskSchedulers">TaskScheduler samples</a>
    /// </remarks>
    private class CustomTaskScheduler;

    /// <summary>
    /// <a href="https://learn.microsoft.com/zh-cn/dotnet/fundamentals/runtime-libraries/system-threading-tasks-taskscheduler#the-default-task-scheduler-and-the-thread-pool">默认任务调度器和线程池</a>
    /// 在 TPL 和 PLINQ 中，默认的任务调度器使用 .NET 线程池（ThreadPool）来排队和执行工作
    /// <list type="bullet">
    /// <item>工作窃取：本地队列头部 → 全局队列 → 其它线程本地队列</item>
    /// <item>线程注入：任务积压时创建新线程；线程回收：空闲线程自动销毁</item>
    /// <item>总体良好的性能</item>
    /// </list>
    /// </summary>
    private class DefaultTaskSchedulerAndThreadPool
    {
        /// <summary>
        /// <a href="https://learn.microsoft.com/zh-cn/dotnet/fundamentals/runtime-libraries/system-threading-tasks-taskscheduler#long-running-tasks">长时间运行的任务</a>
        /// TaskCreationOptions.LongRunning，提示任务调度器为任务分配一个独立的线程，而不是将其放入线程池的本地队列，从而避免阻塞本地队列中的其他任务
        /// </summary>
        [Test]
        public void LongRunning()
        {
            Task.Factory.StartNew(() =>
            {
                Thread.Sleep(1000);
                Console.WriteLine("Long-running task completed.");
            }, TaskCreationOptions.LongRunning).Wait();
        }

        /// <summary>
        /// <a href="https://learn.microsoft.com/zh-cn/dotnet/fundamentals/runtime-libraries/system-threading-tasks-taskscheduler#task-inlining">任务内联</a>
        /// 当通过 Task.Wait() 或 Task.Result 等方式同步等待任务完成时，如果目标任务尚执行，.NET 运行时可能会直接在当前线程（Wait 的线程）上执行该任务，从而避免额外的线程调度开
        /// </summary>
        [Test]
        public void TaskInlining()
        {
            int parentTaskThreadId = 0, childTaskThreadId = 0;
            Task parentTask = Task.Run(() =>
            {
                parentTaskThreadId = Environment.CurrentManagedThreadId;
                Task childTask = Task.Run(() =>
                {
                    childTaskThreadId = Environment.CurrentManagedThreadId;
                    Thread.Sleep(1000);
                });
                childTask.Wait();
            });
            parentTask.Wait();
            Assert.That(parentTaskThreadId, Is.EqualTo(childTaskThreadId));
        }
    }

    /// <summary>
    /// <a href="https://learn.microsoft.com/zh-cn/dotnet/fundamentals/runtime-libraries/system-threading-tasks-taskscheduler#specify-a-synchronization-context">指定同步上下文</a>
    /// <list type="bullet">
    /// <item>使用 TaskScheduler.FromCurrentSynchronizationContext 方法来指定任务应在特定线程上运行</item>
    /// <item>适用于 WinForms 和 WPF：UI 控件的创建和操作必须由创建 UI 对象的同一线程上完成
    /// <list type="bullet">
    /// <item>UI 对象未设计为多线程安全</item>
    /// <item>UI 线程通过消息队列处理用户输入、渲染等事件，跨线程操作会破坏这一机制</item>
    /// </list>
    /// </item>
    /// </list>
    /// </summary>
    private class SpecifySynchronizationContext;
}
