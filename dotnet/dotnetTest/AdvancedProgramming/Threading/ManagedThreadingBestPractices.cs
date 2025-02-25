namespace dotnetTest.AdvancedProgramming.Threading;

/// <summary>
/// <a href="https://learn.microsoft.com/zh-cn/dotnet/standard/threading/managed-threading-best-practices">托管线程最佳实践</a>
/// </summary>
public abstract class ManagedThreadingBestPractices
{
    /// <summary>
    /// <a href="https://learn.microsoft.com/zh-cn/dotnet/standard/threading/managed-threading-best-practices#deadlocks-and-race-conditions">死锁和争用条件</a>
    /// 多线程处理会带来两个问题：死锁和争用条件
    /// </summary>
    private class DeadlocksAndRaceConditions
    {
        /// <summary>
        /// 死锁
        /// <list type="bullet">
        /// <item>释义：两个线程中的每一个线程都尝试锁定另外一个线程已锁定的资源</item>
        /// <item>解决：超时设定</item>
        /// </list>
        /// </summary>
        [Test]
        public void Deadlocks()
        {
            object lockObject = new();
            if (Monitor.TryEnter(lockObject, 300))
            {
                try
                {
                    Console.WriteLine("临界区操作");
                }
                finally
                {
                    Monitor.Exit(lockObject);
                }
            }
            else
            {
                Console.WriteLine("锁获取超时");
            }
        }

        /// <summary>
        /// 争用条件
        /// <list type="bullet">
        /// <item>释义：程序的结果取决于两个或更多个线程中的哪一个先到达某一特定代码块时出现的一种 bug</item>
        /// <item>解决：①Interlocked ②<see cref="ManagedThreadingBasics.SynchronizeDataForMultithreading">为多线程处理同步数据</see></item>
        /// </list>
        /// </summary>
        [Test]
        public void RaceConditions()
        {
            int counter = 0;
            const int threadCount = 20;
            const int iterations = 100000;

            Thread[] threads = Enumerable.Range(0, threadCount)
                .Select(_ => new Thread(() =>
                {
                    for (int j = 0; j < iterations; j++)
                    {
                        // counter++;
                        Interlocked.Increment(ref counter);
                    }
                })).ToArray();

            Array.ForEach(threads, t => t.Start());
            Array.ForEach(threads, t => t.Join());

            Console.WriteLine($"预期: {threadCount * iterations}, 实际: {counter}");
        }
    }

    /// <summary>
    /// 生产者-消费者模型
    /// </summary>
    private class ProducerConsumerModel
    {
        private static readonly object Lock = new();
        private static bool _producerFinished;
        private static readonly Queue<int> Queue = new();

        [Test]
        public void Test()
        {
            Thread[] threads = new Thread[3];
            threads[0] = new Thread(Produce);
            threads[1] = new Thread(Consume);
            threads[2] = new Thread(Consume);

            foreach (var t in threads) t.Start();
            foreach (var t in threads) t.Join();
        }

        private static void Produce()
        {
            for (int i = 0; i < 5; i++)
            {
                lock (Lock)
                {
                    while (Queue.Count >= 3) Monitor.Wait(Lock);
                    Queue.Enqueue(i);
                    Console.WriteLine($"Produced: {i}");
                    Monitor.PulseAll(Lock);
                }
                Thread.Sleep(100);
            }
            lock (Lock)
            {
                _producerFinished = true;
                Monitor.PulseAll(Lock);
            }
        }

        private static void Consume()
        {
            while (!_producerFinished || Queue.Count > 0)
            {
                lock (Lock)
                {
                    while (Queue.Count == 0 && !_producerFinished) Monitor.Wait(Lock);
                    if (Queue.Count == 0 && _producerFinished) return;
                    int item = Queue.Dequeue();
                    Console.WriteLine($"{Thread.CurrentThread.Name} Consumed: {item}");
                    Monitor.PulseAll(Lock);
                }
                Thread.Sleep(150);
            }
        }
    }
}
