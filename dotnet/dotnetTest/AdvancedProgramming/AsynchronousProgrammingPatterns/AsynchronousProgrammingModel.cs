using System.Net;
using dotnet.L.Demo;

namespace dotnetTest.AdvancedProgramming.AsynchronousProgrammingPatterns;

/// <summary>
/// <a href="https://learn.microsoft.com/zh-cn/dotnet/standard/asynchronous-programming-patterns/asynchronous-programming-model-apm">异步编程模型</a>
/// </summary>
public abstract class AsynchronousProgrammingModel
{
    /// <summary>
    /// <a href="https://learn.microsoft.com/zh-cn/dotnet/standard/asynchronous-programming-patterns/calling-asynchronous-methods-using-iasyncresult">使用 IAsyncResult 调用异步方法</a>
    /// 使用 IAsyncResult 设计模式的异步操作是通过名为 BeginOperationName 和 EndOperationName 的两个方法来实现的，这两个方法分别开始和结束异步操作
    /// </summary>
    private class UsingIAsyncResult
    {
        /// <summary>
        /// <a href="https://learn.microsoft.com/zh-cn/dotnet/standard/asynchronous-programming-patterns/blocking-application-execution-using-an-asyncwaithandle">使用 AsyncWaitHandle 阻止执行</a>
        /// <list type="number">
        /// <item>WaitOne   等待单个异步操作</item>
        /// <item>WaitWall  等待一组异步操作</item>
        /// <item>WaitAny   等待一组异步操作，直到任意一个完成</item>
        /// </list>
        /// </summary>
        [Test]
        public void BlockExecutionUsingAsyncWaitHandle()
        {
            // 开始异步操作
            IAsyncResult result = Dns.BeginGetHostEntry(Demo.BaiDuHost, null, null);
            // 等待操作完成
            result.AsyncWaitHandle.WaitOne();
            // 结束异步操作，获取操作结果
            IPHostEntry hostEntry = Dns.EndGetHostEntry(result);
            WriteLineAddresses(hostEntry);
        }

        /// <summary>
        /// <a href="https://learn.microsoft.com/zh-cn/dotnet/standard/asynchronous-programming-patterns/polling-for-the-status-of-an-asynchronous-operation">轮询异步操作的状态</a>
        /// </summary>
        [Test]
        public void PollTheStatusOfAsyncOperation()
        {
            IAsyncResult result = Dns.BeginGetHostEntry(Demo.BaiDuHost, null, null);
            // 使用 IsCompleted 确定操作是否已完成
            while (result.IsCompleted != true)
            {
                Thread.Sleep(100);
            }
            IPHostEntry hostEntry = Dns.EndGetHostEntry(result);
            WriteLineAddresses(hostEntry);
        }

        /// <summary>
        /// <a href="https://learn.microsoft.com/zh-cn/dotnet/standard/asynchronous-programming-patterns/using-an-asynccallback-delegate-to-end-an-asynchronous-operation">使用 AsyncCallback 委托结束异步操作</a>
        /// </summary>
        [Test]
        public async Task UseAsyncCallbackDelegateToEndAsyncOperation()
        {
            var tcs = new TaskCompletionSource<IPHostEntry>();
            Dns.BeginGetHostEntry(Demo.BaiDuHost, CallBack, null);
            IPHostEntry hostEntry = await tcs.Task;
            WriteLineAddresses(hostEntry);
            return;

            void CallBack(IAsyncResult ar)
            {
                try
                {
                    var host = Dns.EndGetHostEntry(ar);
                    tcs.SetResult(host);
                }
                catch (Exception ex)
                {
                    tcs.SetException(ex);
                }
            }
        }

        [Test]
        public async Task Other()
        {
            Task<IPHostEntry> resolveTask = Task.Run(() => Dns.GetHostEntryAsync(Demo.BaiDuHost));
            IPHostEntry hostEntry = await resolveTask;
            WriteLineAddresses(hostEntry);
        }

        private static void WriteLineAddresses(IPHostEntry host)
        {
            IPAddress[] addresses = host.AddressList;
            addresses.ToList().ForEach(address => Console.WriteLine("{0}", address.ToString()));
        }
    }

    /// <summary>
    /// <a href="https://learn.microsoft.com/zh-cn/dotnet/standard/asynchronous-programming-patterns/asynchronous-programming-using-delegates">使用委托进行异步编程</a>
    /// <list type="bullet">
    /// <item>使用 .NET 可以以异步方式调用任何方法。为此，请定义一个委托，该委托具有与你要调用的方法相同的签名。公共语言运行时将自动用适当的签名为此委托定义 BeginInvoke 和 EndInvoke 方法。</item>
    /// <item>BeginInvoke 和 EndInvoke 在 .NET Core 及以上版本中不受支持</item>
    /// </list>
    /// </summary>
    private class UsingDelegates
    {
        private delegate string AsyncMethodCaller(int callDuration);

        private static string CallerMethod(int callDuration)
        {
            Console.WriteLine("Test method begins.");
            Thread.Sleep(callDuration);
            return $"My call time was {callDuration}.";
        }

        [Test]
        public void Test()
        {
            AsyncMethodCaller caller = CallerMethod;
            Random random = new Random();
            for (int i = 1; i <= 10; i++)
            {
                caller.BeginInvoke(random.Next(0, 100), CallBack, i);
            }
            return;

            void CallBack(IAsyncResult result)
            {
                string returnValue = caller.EndInvoke(result);
                Console.WriteLine("The call executed on task {0}, on task with return value \"{1}\".", result.AsyncState, returnValue);
            }
        }
    }
}
