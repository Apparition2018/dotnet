namespace dotnetTest.AdvancedProgramming.Threading.ManagedThreadingBasics;

/// <summary>
/// <a href="https://learn.microsoft.com/zh-cn/dotnet/standard/threading/synchronizing-data-for-multithreading">为多线程处理同步数据</a>
/// <list type="bullet">
/// <item><see cref="SynchronizationCodeRegions">同步代码区域</see></item>
/// <item><see cref="System.Collections.Concurrent">线程安全集合</see></item>
/// <item>使用 SynchronizationAttribute 为 ContextBoundObject 对象启用简单的自动同步，仅对于 .NET Framework 和 Xamarin 应用程序</item>
/// </list>
/// </summary>
public abstract class SynchronizeDataForMultithreading
{
    /// <summary>
    /// 同步代码区域
    /// <list type="bullet">
    /// <item><see cref="SynchronizationCodeRegions.BankAccount.MonitorDeposit">Monitor</see></item>
    /// <item><see cref="SynchronizationCodeRegions.BankAccount.LockDeposit">lock</see> (编译器提供的语法糖，背后自动调用了 Monitor.Enter 和 Monitor.Exit)</item>
    /// </list>
    /// </summary>
    private class SynchronizationCodeRegions
    {
        private class BankAccount
        {
            private int _balance;

            private readonly object _lockObject = new();

            /// <summary>
            /// <a href="https://learn.microsoft.com/zh-cn/dotnet/standard/threading/overview-of-synchronization-primitives#monitor-class">Monitor</a>
            /// </summary>
            public void MonitorDeposit(int amount)
            {
                // 进入临界区
                Monitor.Enter(_lockObject);
                try
                {
                    Deposit(amount);
                }
                finally
                {
                    // 离开临界区
                    Monitor.Exit(_lockObject);
                }
            }

            public void LockDeposit(int amount)
            {
                // 使用 lock 简化 Monitor.Enter 和 Monitor.Exit 的使用
                lock (_lockObject)
                {
                    Deposit(amount);
                }
            }

            // 使用全局命名 Mutex，其他进程可以通过相同名称访问这个 Mutex
            private readonly Mutex _mutex = new(false, "Global\\MyMutex");

            public void MutexDeposit(int amount)
            {
                _mutex.WaitOne();
                try
                {
                    Deposit(amount);
                }
                finally
                {
                    _mutex.ReleaseMutex();
                }
            }

            private SpinLock _spinLock;

            public void SpinLockDeposit(int amount)
            {
                bool gotLock = false;
                try
                {
                    _spinLock.Enter(ref gotLock);
                    Deposit(amount);
                }
                finally
                {
                    if (gotLock)
                    {
                        _spinLock.Exit();
                    }
                }
            }

            private void Deposit(int amount)
            {
                Console.WriteLine($"正在存款 {amount} 到账户，当前余额: {_balance}");
                _balance += amount;
                Console.WriteLine($"存款完成，新的余额: {_balance}");
            }
        }

        [Test]
        public void Test()
        {
            BankAccount account = new BankAccount();

            List<Thread> threads = new[]
                {
                    account.MonitorDeposit,
                    account.LockDeposit,
                    account.MutexDeposit,
                    account.SpinLockDeposit
                }
                .Select(m => new Thread(() => m(100)))
                .ToList();

            threads.ForEach(t => t.Start());
            threads.ForEach(t => t.Join());

            Console.WriteLine("所有存款操作已完成");
        }
    }
}
