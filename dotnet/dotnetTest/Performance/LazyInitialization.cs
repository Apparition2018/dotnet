namespace dotnetTest.Performance;

/// <summary>
/// <a href="https://learn.microsoft.com/zh-cn/dotnet/framework/performance/lazy-initialization">延迟初始化</a>
/// <list type="bullet">
/// <item><see cref="Lazy">Lazy</see>：为任何类库或用户定义类型提供迟缓初始化语义的包装类；提供多种线程安全模式，默认线程安全</item>
/// <item><see cref="ThreadLocal">ThreadLocal</see>：类似 Lazy，基于线程本地</item>
/// <item><see cref="LazyVsLazyInitializer">LazyInitializer</see>：更轻量级实现延迟初始化；由于是静态方法，所以不需要创建额外的对象</item>
/// </list>
/// </summary>
public class LazyInitialization
{
    [Test]
    public void Lazy()
    {
        Lazy<int> number = new Lazy<int>(() => Environment.CurrentManagedThreadId);

        Thread t1 = new Thread(() => Console.WriteLine("number on t1 = {0} ThreadID = {1}", number.Value, Environment.CurrentManagedThreadId));
        t1.Start();
        Thread t2 = new Thread(() => Console.WriteLine("number on t2 = {0} ThreadID = {1}", number.Value, Environment.CurrentManagedThreadId));
        t2.Start();
        Thread t3 = new Thread(() => Console.WriteLine("number on t3 = {0} ThreadID = {1}", number.Value, Environment.CurrentManagedThreadId));
        t3.Start();

        t1.Join();
        t2.Join();
        t3.Join();
        // number on t1 = 15 ThreadID = 15
        // number on t2 = 15 ThreadID = 16
        // number on t3 = 15 ThreadID = 17
    }

    [Test]
    public void ThreadLocal()
    {
        ThreadLocal<int> threadLocalNumber = new ThreadLocal<int>(() => Environment.CurrentManagedThreadId);

        Thread t4 = new Thread(() => Console.WriteLine("threadLocalNumber on t4 = {0} ThreadID = {1}", threadLocalNumber.Value, Environment.CurrentManagedThreadId));
        t4.Start();
        Thread t5 = new Thread(() => Console.WriteLine("threadLocalNumber on t5 = {0} ThreadID = {1}", threadLocalNumber.Value, Environment.CurrentManagedThreadId));
        t5.Start();
        Thread t6 = new Thread(() => Console.WriteLine("threadLocalNumber on t6 = {0} ThreadID = {1}", threadLocalNumber.Value, Environment.CurrentManagedThreadId));
        t6.Start();

        t4.Join();
        t5.Join();
        t6.Join();
        // number on t1 = 15 ThreadID = 15
        // number on t2 = 16 ThreadID = 16
        // number on t3 = 17 ThreadID = 17
    }

    [Test]
    public void LazyVsLazyInitializer()
    {
        #region Lazy
        Lazy<ExpensiveObject> lazyInstance = new Lazy<ExpensiveObject>(() => new ExpensiveObject());
        var instance = lazyInstance.Value;
        Console.WriteLine("Lazy instance is now created.");
        #endregion

        #region LazyInitializer
        ExpensiveObject? expensiveObjectField = null;
        LazyInitializer.EnsureInitialized(ref expensiveObjectField, () => new ExpensiveObject());
        Console.WriteLine("ExpensiveObject field is now initialized.");
        #endregion
    }

    class ExpensiveObject
    {
        public ExpensiveObject()
        {
            Thread.Sleep(1000);
            Console.WriteLine("ExpensiveObject created.");
        }
    }
}
