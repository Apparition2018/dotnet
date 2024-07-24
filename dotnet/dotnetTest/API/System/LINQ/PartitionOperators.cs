namespace dotnetTest.API.System.LINQ;

/// <summary>
/// <a href="https://localhost:6291/101-linq-samples/index.md#partition-operators">LINQ - Partition Operators</a>
/// </summary>
/// <remarks>
/// Take、Skip、TakeWhile 和 SkipWhile 方法对输出序列进行分区。您可以使用这些来限制传输到输出序列的输入序列部分
/// </remarks>
public class PartitionOperators
{
    private static readonly int[] Numbers = [1, 2, 3, 4, 5, 6, 7, 8, 9];

    /// <summary>
    /// <a href="https://localhost:6291/101-linq-samples/docs/partitions.md#take-elements">Take 获取前几个元素</a>
    /// <a href="https://localhost:6291/101-linq-samples/docs/partitions.md#skip-elements">Skip 获取前几个元素以外的所有元素</a>
    /// </summary>
    [Test]
    public void TakeAndSkipElements()
    {
        var first3Numbers = Numbers.Take(3);
        Console.WriteLine("First 3 numbers:");
        foreach (var n in first3Numbers)
        {
            Console.WriteLine(n);
        }

        var allButFirst4Numbers = Numbers.Skip(4);
        Console.WriteLine("All but first 4 numbers:");
        foreach (var n in allButFirst4Numbers)
        {
            Console.WriteLine(n);
        }
    }

    /// <summary>
    /// <a href="https://localhost:6291/101-linq-samples/docs/partitions-2.md#takewhile-syntax">TakeWhile 获取前几个元素</a>
    /// <a href="https://localhost:6291/101-linq-samples/docs/partitions-2.md#skipwhile-syntax">SkipWhile 获取前几个元素以外的所有元素</a>
    /// </summary>
    [Test]
    public void TakeWhileAndSkipWhileSyntax()
    {
        var firstSmallNumbers = Numbers.TakeWhile((n, index) => n >= index);
        Console.WriteLine("First numbers not less than their position:");
        foreach (var n in firstSmallNumbers)
        {
            Console.WriteLine(n);
        }

        var laterNumbers = Numbers.SkipWhile((n, index) => n >= index);
        Console.WriteLine("All elements starting from first element less than its position:");
        foreach (var n in laterNumbers)
        {
            Console.WriteLine(n);
        }
    }
}
