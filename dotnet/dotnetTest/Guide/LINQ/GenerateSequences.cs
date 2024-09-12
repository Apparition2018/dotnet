namespace dotnetTest.Guide.LINQ;

/// <summary>
/// <a href="https://localhost:6291/101-linq-samples/index.md#generate-sequences">LINQ - Generate elements</a>
/// </summary>
/// <remarks>
/// Range 和 Repeat 方法创建整数序列。这些可以是查询的源序列
/// </remarks>
public class GenerateSequences
{
    /// <summary>
    /// <a href="https://localhost:6291/101-linq-samples/docs/generators.md#create-a-range-of-numbers">创建一个数字范围</a>
    /// </summary>
    [Test]
    public void CreateRangeOfNumbers()
    {
        var numbers = from n in Enumerable.Range(100, 50)
            select (Number: n, OddEven: n % 2 == 1 ? "odd" : "even");

        foreach (var n in numbers)
        {
            Console.WriteLine("The number {0} is {1}.", n.Number, n.OddEven);
        }
    }

    /// <summary>
    /// <a href="https://localhost:6291/101-linq-samples/docs/generators.md#repeat-the-same-number">重复相同的数字</a>
    /// </summary>
    [Test]
    public void RepeatTheSameNumber()
    {
        var numbers = Enumerable.Repeat(7, 10);

        foreach (var n in numbers)
        {
            Console.WriteLine(n);
        }
    }
}
