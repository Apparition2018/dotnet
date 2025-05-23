using System.Collections.Concurrent;
using System.Diagnostics;
using dotnetTest.AdvancedProgramming.AsynchronousProgrammingPatterns;
using dotnetTest.AdvancedProgramming.Threading;
using dotnetTest.API.System.Threading.Tasks;
using dotnetTest.Guide.AsynchronousPrograming;
using dotnetTest.Guide.ProgrammingGuide.ClassesStructsRecords;

namespace dotnetTest.AdvancedProgramming.ParallelProgramming.TaskParallelLibrary;

/// <summary>
/// <a href="https://learn.microsoft.com/zh-cn/dotnet/standard/parallel-programming/task-based-asynchronous-programming">基于任务的异步编程</a>
/// </summary>
/// <seealso cref="TaskBasedAsynchronousPattern"/>
/// <seealso cref="TaskTests"/>
public class TaskBasedAsynchronous
{
    /// <summary>
    /// <a href="https://learn.microsoft.com/zh-cn/dotnet/standard/parallel-programming/task-based-asynchronous-programming#creating-and-running-tasks-implicitly">隐式创建和运行任务</a>
    /// </summary>
    [Test]
    public void CreatingAndRunningTasksImplicitly()
    {
        Parallel.Invoke(() => { Console.WriteLine("Task 1"); }, () => { Console.WriteLine("Task 2"); });
    }

    /// <summary>
    /// <a href="https://learn.microsoft.com/zh-cn/dotnet/standard/parallel-programming/task-based-asynchronous-programming#creating-and-running-tasks-implicitly">显式创建和运行任务</a>
    /// </summary>
    /// <remarks>
    /// <a href="https://learn.microsoft.com/zh-cn/dotnet/fundamentals/runtime-libraries/system-threading-tasks-task#task-instantiation">任务实例化</a>
    /// </remarks>
    [Test]
    public void CreatingAndRunningTasksExplicitly()
    {
        Console.WriteLine("Main   Thread={0}", Environment.CurrentManagedThreadId);
        Action<object> action = method => Console.WriteLine("Task={0} Thread={1, -2} method={2} ", Task.CurrentId, Environment.CurrentManagedThreadId, method);

        Task t1 = new Task(action!, "new+start");
        t1.Start();
        t1.Wait();

        Task t2 = Task.Factory.StartNew(action!, "Task.Factory.StartNew");
        t2.Wait();

        Task t3 = Task.Run(() => Console.WriteLine("Task={0} Thread={1, -2} method={2}", Task.CurrentId, Environment.CurrentManagedThreadId, "Task.Run"));
        t3.Wait();

        Task t4 = new Task(action!, "new+runSync");
        t4.RunSynchronously();
    }

    /// <summary>
    /// <a href="https://learn.microsoft.com/zh-cn/dotnet/standard/parallel-programming/task-based-asynchronous-programming#creating-task-continuations">创建任务延续</a>
    /// <list type="bullet">
    /// <item>ContinueWith 方法，可以指定在前一个任务完成时启动的任务</item>
    /// <item>ContinueWhenAll 和 ContinueWhenAny 方法，可以从多个任务继续</item>
    /// </list>
    /// </summary>
    [Test]
    public void CreatingTaskContinuations()
    {
        Task<string> taskA = Task.Factory.StartNew(() => "A");
        Task<string> taskB = taskA.ContinueWith(x => x.Result + "B");
        Task<string> taskC = taskB.ContinueWith(x => x.Result + "C");
        Console.WriteLine(taskC.Result);
    }

    /// <summary>
    /// <a href="https://learn.microsoft.com/zh-cn/dotnet/standard/parallel-programming/task-based-asynchronous-programming#creating-detached-child-tasks">创建分离的子任务</a>
    /// <list type="bullet">
    /// <item>如果在任务中创建一个新任务，且未指定 AttachedToParent 选项，则该新任务不采用任何特殊方式与父任务同步</item>
    /// <item>这种不同步的任务类型称为 “分离的嵌套任务” 或 “分离的子任务”</item>
    /// <item>父任务不会等待分离子任务完成</item>
    /// </list>
    /// </summary>
    [Test]
    public void CreatingDetachedChildTasks()
    {
        Task outer = Task.Factory.StartNew(() =>
        {
            Console.WriteLine("Outer task beginning.");

            Task child = Task.Factory.StartNew(() =>
            {
                Thread.SpinWait(5000000);
                Console.WriteLine("Detached task completed.");
            });
        });

        outer.Wait();
        Console.WriteLine("Outer task completed.");
    }

    /// <summary>
    /// <a href="https://learn.microsoft.com/zh-cn/dotnet/standard/parallel-programming/task-based-asynchronous-programming#creating-detached-child-tasks">创建子任务</a>
    /// <list type="bullet">
    /// <item>如果任务中创建任务时指定了 AttachedToParent 选项，新任务就称为父任务的附加子任务</item>
    /// <item>父任务隐式地等待所有附加子任务完成</item>
    /// </list>
    /// </summary>
    [Test]
    public void CreatingChildTasks()
    {
        Task parent = Task.Factory.StartNew(() =>
        {
            Console.WriteLine("Parent task beginning.");
            for (int ctr = 0; ctr < 10; ctr++)
            {
                int taskNo = ctr;
                Task.Factory.StartNew((x) =>
                    {
                        Thread.SpinWait(5000000);
                        Console.WriteLine("Attached child #{0} completed.", x);
                    },
                    taskNo, TaskCreationOptions.AttachedToParent);
            }
        });

        parent.Wait();
        Console.WriteLine("Parent task completed.");
    }

    /// <summary>
    /// <a href="https://learn.microsoft.com/zh-cn/dotnet/standard/parallel-programming/task-based-asynchronous-programming#waiting-for-tasks-to-finish">等待任务完成</a>
    /// Wait, WaitAll, WaitAny
    /// <para>
    /// 等待任务的原因：
    /// <list type="bullet">
    /// <item>主线程依赖于任务计算的最终结果</item>
    /// <item>必须处理可能从任务引发的异常</item>
    /// <item>应用程序可以在所有任务执行完毕之前终止</item>
    /// </list>
    /// </para>
    /// </summary>
    [Test]
    public void WaitingForTasksToFinish()
    {
        Task[] tasks =
        [
            Task.Factory.StartNew(() => Console.WriteLine("A")),
            Task.Factory.StartNew(() => Console.WriteLine("B")),
            Task.Factory.StartNew(() => Console.WriteLine("C"))
        ];

        Task.WaitAll(tasks);
        Console.WriteLine("Finish");
    }

    /// <summary>
    /// <a href="https://learn.microsoft.com/zh-cn/dotnet/standard/parallel-programming/task-based-asynchronous-programming#composing-tasks">组合任务</a>
    /// <list type="bullet">
    /// <item><see cref="TaskTests.WhenAll">Task.WhenAll</see></item>
    /// <item><see cref="AsynchronousProgramming.Test">Task.WhenAny</see></item>
    /// <item><see cref="TaskTests.Delay">Task.Delay</see></item>
    /// <item><see cref="CreatePreComputedTasks">Task(T).FromResult</see></item>
    /// </list>
    /// </summary>
    private class ComposingTasks
    {
        /// <summary>
        /// <a href="https://learn.microsoft.com/zh-cn/dotnet/standard/parallel-programming/how-to-create-pre-computed-tasks">创建预先计算的任务</a>
        /// 使用 Task.FromResult 方法检索缓存中包含的异步下载操作的结果
        /// </summary>
        [Test]
        public async Task CreatePreComputedTasks()
        {
            ConcurrentDictionary<string, int> cached = new();

            Stopwatch stopwatch = Stopwatch.StartNew();
            string[] keys = ["a", "b"];
            IEnumerable<Task<int>> getValues = keys.Select(GetValueAsync).ToList();
            await Task.WhenAll(getValues).ContinueWith(tasks => StopAndLogElapsedTime(1, tasks));
            stopwatch.Restart();
            await Task.WhenAll(getValues).ContinueWith(tasks => StopAndLogElapsedTime(2, tasks));

            Task<int> GetValueAsync(string key)
            {
                if (cached.TryGetValue(key, out int content))
                {
                    return Task.FromResult(content);
                }

                return Task.Run(async () =>
                {
                    await Task.Delay(1000);
                    cached.TryAdd(key, new Random().Next(10));
                    return cached.GetValueOrDefault(key);
                });
            }

            void StopAndLogElapsedTime(int attemptNumber, Task<int[]> tasks)
            {
                stopwatch.Stop();
                Console.WriteLine(
                    $"Attempt number: {attemptNumber}\n" +
                    $"Retrieved value: {tasks.Result.Aggregate(string.Empty, (current, next) => current + " " + next)}\n" +
                    $"Elapsed retrieval time: {stopwatch.ElapsedMilliseconds:#,0} milliseconds.\n");
            }
        }
    }

    /// <summary>
    /// <a href="https://learn.microsoft.com/zh-cn/dotnet/standard/parallel-programming/task-cancellation">任务取消</a>
    /// 使用 CancellationTokenSource 进行协作取消
    /// </summary>
    /// <seealso cref="UsingThreadsAndThreading.CancelThreads">取消线程</seealso>
    [Test]
    public async Task TaskCancellation()
    {
        using CancellationTokenSource tokenSource = new CancellationTokenSource();
        CancellationToken ct = tokenSource.Token;

        var task = Task.Run(() =>
        {
            bool moreToDo = true;
            while (moreToDo)
            {
                // 如果此令牌已请求取消，则引发 OperationCanceledException
                ct.ThrowIfCancellationRequested();
            }
        }, ct);

        tokenSource.Cancel();

        try
        {
            await task;
        }
        catch (OperationCanceledException e) when (e.CancellationToken == ct)
        {
            Console.WriteLine($"{nameof(OperationCanceledException)} thrown with message: {e.Message}");
        }
    }

    /// <summary>
    /// <a href="https://learn.microsoft.com/zh-cn/dotnet/standard/parallel-programming/task-based-asynchronous-programming#custom-task-types">自定义任务类型</a>
    /// <list type="bullet">
    /// <item>不要从 Task 继承</item>
    /// <item>使用 AsyncState 属性将其他数据或状态与 Task 对象相关联</item>
    /// <item>使用<see cref="Method.ExtensionMethods">扩展方法</see>扩展 Task 类的功能</item>
    /// </list>
    /// </summary>
    [Test]
    public void CustomTaskTypes()
    {
    }
}
