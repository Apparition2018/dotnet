using System.Runtime.CompilerServices;
using dotnetTest.AdvancedProgramming.Threading.ThreadingObjectsAndFeatures;
using dotnetTest.API.System.Runtime;

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
    /// <seealso cref="SynchronizationPrimitives"/>
    /// <seealso cref="CompilerServicesTests.MethodImplAttribute.SynchronizedOption"/>
    private class SynchronizationCodeRegions
    {
        private class BankAccount
        {
            private int _balance;

            private readonly object _lockObject = new();

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

            [MethodImpl(MethodImplOptions.Synchronized)]
            public void MethodImplSyncDeposit(int amount)
            {
                Deposit(amount);
            }

            // 全局命名 Mutex，支持跨进程同步
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

            // 命名信号量，支持跨进程同步
            private readonly Semaphore _semaphore = new(2, 2, "Global/MySemaphore");

            public void SemaphoreDeposit(int amount)
            {
                // 如果 Semaphore initialCount 为 0，需要先调用 Release(int releaseCount) 释放信号量
                // _semaphore.Release(2);
                _semaphore.WaitOne();
                try
                {
                    Deposit(amount);
                }
                finally
                {
                    _semaphore.Release();
                }
            }

            private readonly SemaphoreSlim _semaphoreSlim = new(2, 2);

            public void SemaphoreSlimDeposit(int amount)
            {
                // 如果 SemaphoreSlim initialCount 为 0，需要先调用 Release(int releaseCount) 释放信号量
                // _semaphoreSlim.Release(2);
                _semaphoreSlim.WaitAsync();
                try
                {
                    Deposit(amount);
                }
                finally
                {
                    _semaphoreSlim.Release();
                }
            }

            // true 将初始状态设为 signaled，首次调用 WaitOne() 的线程不会倍阻塞
            private readonly EventWaitHandle _autoResetEvent = new AutoResetEvent(true);

            public void AutoResetEventDeposit(int amount)
            {
                try
                {
                    _autoResetEvent.WaitOne();
                    Deposit(amount);
                }
                finally
                {
                    _autoResetEvent.Set();
                }
            }

            private void Deposit(int amount)
            {
                Console.WriteLine($"正在存款 {amount} 到账户，当前余额: {_balance}");
                Thread.Sleep(10);
                _balance += amount;
                Console.WriteLine($"存款完成，新的余额: {_balance}");
            }
        }

        [Test]
        public async Task Test()
        {
            BankAccount account = new BankAccount();

            Task[] tasks = new[]
                {
                    account.MonitorDeposit,
                    account.LockDeposit,
                    account.MethodImplSyncDeposit,
                    account.MutexDeposit,
                    account.SpinLockDeposit,
                    account.SemaphoreDeposit,
                    account.SemaphoreSlimDeposit,
                    account.AutoResetEventDeposit
                }
                .Select(m => Task.Run(() => m(100)))
                .ToArray();

            await Task.WhenAll(tasks);

            Console.WriteLine("所有存款操作已完成");
        }
    }
}
