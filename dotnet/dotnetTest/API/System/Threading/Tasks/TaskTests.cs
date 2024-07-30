namespace dotnetTest.API.System.Threading.Tasks;

/// <summary>
/// <a href="https://learn.microsoft.com/zh-cn/dotnet/api/system.threading.tasks.task">Task</a>
/// </summary>
public class TaskTest
{
    /// <summary>
    /// <a href="https://learn.microsoft.com/zh-cn/dotnet/api/system.threading.tasks.task.delay">Task.Delay</a>
    /// 创建一个任务，该任务将在时间延迟后完成
    /// </summary>
    [Test]
    public void Delay()
    {
        var t = Task.Run(async delegate
        {
            await Task.Delay(1000);
            return 42;
        });
        t.Wait();
        Console.WriteLine("Task t Status: {0}, Result: {1}", t.Status, t.Result);
    }
}
