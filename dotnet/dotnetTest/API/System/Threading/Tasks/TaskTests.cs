using dotnetTest.AdvancedProgramming.AsynchronousProgrammingPatterns;
using dotnetTest.AdvancedProgramming.ParallelProgramming.TaskParallelLibrary;

namespace dotnetTest.API.System.Threading.Tasks;

/// <summary>
/// <a href="https://learn.microsoft.com/zh-cn/dotnet/api/system.threading.tasks.task">Task</a>
/// </summary>
/// <seealso cref="TaskBasedAsynchronousPattern"/>
/// <seealso cref="TaskBasedAsynchronous"/>
public class TaskTests
{
    /// <summary>确定任务状态</summary>
    [Test]
    public async Task DetermineStateOfTask()
    {
        var task1 = Task.Run(() => Thread.Sleep(100));
        await task1;
        PrintStatus(task1, "正常任务");

        var task2 = Task.Run(() => throw new Exception("自定义异常"));
        try
        {
            await task2;
        }
        catch
        {
            /* ignored */
        }
        PrintStatus(task2, "异常任务");

        var cts = new CancellationTokenSource();
        var task3 = Task.Run(() =>
        {
            Thread.Sleep(100);
            cts.Token.ThrowIfCancellationRequested();
        }, cts.Token);
        cts.CancelAfter(10);
        try
        {
            await task3;
        }
        catch
        {
            /* ignored */
        }
        PrintStatus(task3, "取消任务");
    }

    /// <summary>
    /// <list type="bullet">
    /// <item>IsCompleted：RanToCompletion、Canceled、Faulted</item>
    /// <item>IsCompletedSuccessfully：RanToCompletion</item>
    /// </list>
    /// </summary>
    /// <seealso cref="TaskStatus"/>
    private static void PrintStatus(Task task, string name)
    {
        Console.WriteLine($"[{name}]");
        Console.WriteLine($"IsCanceled: {task.IsCanceled}");
        Console.WriteLine($"IsCompleted: {task.IsCompleted}");
        Console.WriteLine($"IsCompletedSuccessfully: {task.IsCompletedSuccessfully}");
        Console.WriteLine($"IsFaulted: {task.IsFaulted}\n");
    }

    /// <summary>
    /// <a href="https://learn.microsoft.com/zh-cn/dotnet/api/system.threading.tasks.task.delay">Task.Delay</a>
    /// 创建一个任务，该任务将在时间延迟后完成
    /// </summary>
    [Test]
    public void Delay()
    {
        Task<int> t = Task.Run(async delegate
        {
            await Task.Delay(1000);
            return 42;
        });
        t.Wait();
        Console.WriteLine("Task t Status: {0}, Result: {1}", t.Status, t.Result);
    }

    /// <summary>
    /// <a href="https://learn.microsoft.com/zh-cn/dotnet/api/system.threading.tasks.task.waitall">Task.WaitAll</a>
    /// 等待提供的所有 Task 对象完成执行
    /// <list type="bullet">
    /// <item>阻塞线程</item>
    /// <item>没有返回值</item>
    /// <item>抛出所有失败任务的异常 (AggregateException)</item>
    /// </list>
    /// </summary>
    [Test]
    public void WaitAll()
    {
        Task[] tasks =
        [
            Task.Run(() => throw new ArgumentException("task1")),
            Task.Run(() => 2),
            Task.Run(() => throw new ArgumentException("task3"))
        ];
        try
        {
            Task.WaitAll(tasks);
        }
        catch (AggregateException ae)
        {
            foreach (Exception ex in ae.InnerExceptions)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }

    /// <summary>
    /// <a href="https://learn.microsoft.com/zh-cn/dotnet/api/system.threading.tasks.task.delay">Task.WhenAll</a>
    /// 创建一个任务，该任务将在所有提供的任务完成时完成
    /// <list type="bullet">
    /// <item>不会阻塞线程</item>
    /// <item>返回一个 Task，该 Task 的泛型参数是一个包含所有输入任务返回值的数组</item>
    /// <item>任何一个任务失败，立即抛出失败任务的异常</item>
    /// </list>
    /// </summary>
    [Test]
    public async Task WhenAll()
    {
        Task task1 = Task.Run(() => throw new ArgumentException("task1"));
        Task task2 = Task.Run(() => 2);
        Task task3 = Task.Run(() => throw new ArgumentException("task3"));
        try
        {
            await Task.WhenAll(task1, task2, task3);
        }
        catch (Exception ae)
        {
            Console.WriteLine(ae.Message);
        }
    }
}
