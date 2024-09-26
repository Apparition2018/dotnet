using System.Collections.Concurrent;
using System.Diagnostics;
using System.Drawing;
using dotnet.L.Demo;
using dotnetTest.API.System.Threading.Tasks;
using dotnetTest.Guide.AsynchronousPrograming;

namespace dotnetTest.AdvancedProgramming.ParallelProgramming.TaskParallelLibrary;

/// <summary>
/// <a href="https://learn.microsoft.com/zh-cn/dotnet/standard/parallel-programming/task-based-asynchronous-programming">基于任务的异步编程</a>
/// </summary>
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
    [Test]
    public void CreatingAndRunningTasksExplicitly()
    {
        // new Task()
        Task taskA = new Task(() => { Console.WriteLine("taskA from thread '{0}'.", Thread.CurrentThread.ManagedThreadId); });
        taskA.Start();
        taskA.Wait();

        // Task.Run
        Task taskB = Task.Run(() => { Console.WriteLine("taskB from thread '{0}'.", Thread.CurrentThread.ManagedThreadId); });
        taskB.Wait();

        // Task.Factory.StartNew
        Task[] taskArray = new Task[3];
        KnownColor[] knownColors = Enum.GetValues(typeof(KnownColor)).Cast<KnownColor>().ToArray();
        for (int i = 0; i < taskArray.Length; i++)
        {
            KnownColor color = knownColors[i];
            taskArray[i] = Task.Factory.StartNew(obj =>
                {
                    Product data = (obj as Product)!;
                    Console.WriteLine("task{0} from thread '{1}'.", data.ID, Thread.CurrentThread.ManagedThreadId);
                },
                // 状态，作为参数传递给任务委托
                new Product(i, color.ToString()));
        }

        Task.WaitAll(taskArray);
        for (int i = 0; i < taskArray.Length; i++)
        {
            // 访问传递的状态
            if (taskArray[i].AsyncState is Product data)
                Console.WriteLine("task{0} asyncState {1}.", i, data.Name);
        }
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
    class ComposingTasks
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
    /// <a href="https://learn.microsoft.com/zh-cn/dotnet/standard/parallel-programming/task-based-asynchronous-programming#custom-task-types">自定义任务类型</a>
    /// <list type="bullet">
    /// <item>不要从 Task 继承</item>
    /// <item>使用 AsyncState 属性将其他数据或状态与 Task 对象相关联</item>
    /// <item>使用扩展方法扩展 Task 类的功能</item>
    /// </list>
    /// </summary>
    [Test]
    public void CustomTaskTypes()
    {
    }
}
