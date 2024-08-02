using System.Collections.Concurrent;

namespace dotnetTest.AdvancedProgramming.ParallelProgramming.TaskParallelLibrary;

/// <summary>
/// <a href="https://learn.microsoft.com/zh-cn/dotnet/standard/parallel-programming/data-parallelism-task-parallel-library">数据并行</a>
/// </summary>
public class DataParallelism
{
    private static readonly string[] Files = Directory.GetFiles(@"c:\windows\");

    /// <summary>
    /// 计算一个目录中的文件总大小
    /// </summary>
    [Test]
    public void ParallelLoop()
    {
        // Parallel.For loop
        long totalSize = 0;
        Parallel.For(0, Files.Length,
            index =>
            {
                FileInfo fi = new FileInfo(Files[index]);
                long size = fi.Length;
                // 原子操作
                Interlocked.Add(ref totalSize, size);
            });
        Console.WriteLine("{0:N0} files, {1:N0} bytes", Files.Length, totalSize);

        // Parallel.For loop with thread-local variables
        totalSize = 0;
        Parallel.For<long>(0, Files.Length, () => 0,
            (index, _, subTotalSize) =>
            {
                FileInfo fi = new FileInfo(Files[index]);
                long size = fi.Length;
                return subTotalSize + size;
            },
            subTotalSize => Interlocked.Add(ref totalSize, subTotalSize));
        Console.WriteLine("{0:N0} files, {1:N0} bytes", Files.Length, totalSize);

        // Parallel.ForEach loop
        totalSize = 0;
        Parallel.ForEach(Files,
            file =>
            {
                FileInfo fi = new FileInfo(file);
                long size = fi.Length;
                Interlocked.Add(ref totalSize, size);
            });
        Console.WriteLine("{0:N0} files, {1:N0} bytes", Files.Length, totalSize);

        // Parallel.ForEach loop with partition-local variables
        totalSize = 0;
        Parallel.ForEach<string, long>(Files, () => 0,
            (file, _, subTotalSize) =>
            {
                FileInfo fi = new FileInfo(file);
                long size = fi.Length;
                return subTotalSize + size;
            },
            finalResult => Interlocked.Add(ref totalSize, finalResult));
        Console.WriteLine("{0:N0} files, {1:N0} bytes", Files.Length, totalSize);
    }

    /// <summary>
    /// <a href="https://learn.microsoft.com/zh-cn/dotnet/standard/parallel-programming/how-to-handle-exceptions-in-parallel-loops">处理异常</a>
    /// </summary>
    [Test]
    public void HandleExceptions()
    {
        try
        {
            long totalSize = CalTotalSize();
            Console.WriteLine("{0:N0} files, {1:N0} bytes", Files.Length, totalSize);
        }
        catch (AggregateException ae)
        {
            List<Exception> ignoredExceptions = [];
            foreach (Exception ex in ae.Flatten().InnerExceptions)
            {
                if (ex is ArgumentException) Console.WriteLine(ex.Message);
                else ignoredExceptions.Add(ex);
            }

            if (ignoredExceptions.Count > 0)
            {
                throw new AggregateException(ignoredExceptions);
            }
        }
    }


    private long CalTotalSize()
    {
        long totalSize = 0;
        ConcurrentQueue<Exception> exceptions = new();
        Parallel.For(0, Files.Length,
            index =>
            {
                try
                {
                    int flag = 25;
                    if (index >= flag) throw new ArgumentException($"Index is {index}. Index must be less than to {flag}.");
                    FileInfo fi = new FileInfo(Files[index]);
                    long size = fi.Length;
                    Interlocked.Add(ref totalSize, size);
                }
                catch (Exception e)
                {
                    exceptions.Enqueue(e);
                }

                // 将所有异常包装到一个 System.AggregateException
                if (!exceptions.IsEmpty) throw new AggregateException(exceptions);
            });
        return totalSize;
    }

    /// <summary>
    /// <a href="https://learn.microsoft.com/zh-cn/dotnet/standard/parallel-programming/how-to-speed-up-small-loop-bodies">加快小型循环主体</a>
    /// </summary>
    [Test]
    public void SpeedUpSmallLoopBodies()
    {
        long totalSize = 0;
        // 为委托主体提供一个顺序循环，以便每个分区仅调用一次委托，而不是每个迭代调用一次委托
        var rangePartitioner = Partitioner.Create(0, Files.Length);
        Parallel.ForEach(rangePartitioner,
            (range, _) =>
            {
                for (int i = range.Item1; i < range.Item2; i++)
                {
                    FileInfo fi = new FileInfo(Files[i]);
                    long size = fi.Length;
                    Interlocked.Add(ref totalSize, size);
                }
            });
        Console.WriteLine("{0:N0} files, {1:N0} bytes", Files.Length, totalSize);
    }
}
