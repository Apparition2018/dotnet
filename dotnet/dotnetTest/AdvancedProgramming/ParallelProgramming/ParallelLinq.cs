namespace dotnetTest.AdvancedProgramming.ParallelProgramming;

/// <summary>
/// <a href="https://learn.microsoft.com/zh-cn/dotnet/standard/parallel-programming/introduction-to-plinq">Parallel LINQ (PLINQ)</a>
/// </summary>
public class ParallelLinq
{
    [Test]
    public void Test()
    {
        var source = Enumerable.Range(1, 100);

        var evenNums = from num in source
                // PLINQ 的入口点。如果可能，应并行化查询的其余部分
                .AsParallel()
                // 顺序保留：在并行执行时保持元素的原始顺序
                .AsOrdered()
                // 指定执行模式：https://learn.microsoft.com/zh-cn/dotnet/standard/parallel-programming/how-to-specify-the-execution-mode-in-plinq
                .WithExecutionMode(ParallelExecutionMode.ForceParallelism)
                // 并行度：默认处理器数
                .WithDegreeOfParallelism(Environment.ProcessorCount)
                // 合并选项：https://learn.microsoft.com/zh-cn/dotnet/standard/parallel-programming/introduction-to-plinq#options-for-merging-query-results
                // 并行查询对原序列进行分区，以便多个线程能够并发处理不同的部分，通常是在不同的线程中。
                // 如果要在一个线程中使用结果（如 foreach），必须将每个线程的结果合并回一个序列中。
                // 虽然无需显式设置合并选项，但可以提升性能。
                .WithMergeOptions(ParallelMergeOptions.NotBuffered)
            // 从并行切换回串行
            // .AsSequential()
            where num % 2 == 0
            select num;

        Console.WriteLine("foreach: 顺序保留");
        foreach (var e in evenNums)
        {
            Console.Write($"{e} ");
        }

        Console.WriteLine("\nForAll: 顺序无保留");
        evenNums.ForAll(e => Console.Write($"{e} "));
    }
}
