namespace dotnetTest.API.System.LINQ;

/// <summary>
/// <a href="https://localhost:6291/101-linq-samples/index.md#set-operators">LINQ - Set Operators</a>
/// </summary>
/// <remarks>
/// Distinct、Union、Intersect 和 Except 方法提供了比较多个序列的集合操作
/// </remarks>
public class SetOperators
{
    /// <summary>
    /// <a href="https://localhost:6291/101-linq-samples/docs/sets.md#find-distinct-elements">不同的元素</a>
    /// </summary>
    [Test]
    public void FindDistinctElements()
    {
        int[] factorsOf300 = [2, 2, 3, 5, 5];

        var uniqueFactors = factorsOf300.Distinct();

        Console.WriteLine("Prime factors of 300:");
        foreach (var f in uniqueFactors)
        {
            Console.WriteLine(f);
        }
    }

    private static readonly int[] NumbersA = [0, 2, 4, 5, 6, 8, 9];
    private static readonly int[] NumbersB = [1, 3, 5, 7, 8];

    /// <summary>
    /// <a href="https://localhost:6291/101-linq-samples/docs/sets.md#find-the-union-of-sets">并集</a>
    /// </summary>
    [Test]
    public void FindUnionOfSets()
    {
        var uniqueNumbers = NumbersA.Union(NumbersB);
        uniqueNumbers = (from i in NumbersA select i)
            .Union(from i in NumbersB select i);

        Console.WriteLine("Unique numbers from both arrays:");
        foreach (var n in uniqueNumbers)
        {
            Console.WriteLine(n);
        }
    }

    /// <summary>
    /// <a href="https://localhost:6291/101-linq-samples/docs/sets-2.md#find-the-intersection-of-two-sets">交集</a>
    /// </summary>
    [Test]
    public void FindIntersectionOfTwoSets()
    {
        var commonNumbers = NumbersA.Intersect(NumbersB);
        commonNumbers = (from i in NumbersA select i)
            .Intersect(from i in NumbersB select i);

        Console.WriteLine("Common numbers shared by both arrays:");
        foreach (var n in commonNumbers)
        {
            Console.WriteLine(n);
        }
    }

    /// <summary>
    /// <a href="https://localhost:6291/101-linq-samples/docs/sets-2.md#difference-of-two-sets">差集</a>
    /// </summary>
    [Test]
    public void DifferenceOfTwoSets()
    {
        IEnumerable<int> aOnlyNumbers = NumbersA.Except(NumbersB);
        aOnlyNumbers = (from i in NumbersA select i)
            .Except(from i in NumbersB select i);

        Console.WriteLine("Numbers in first array but not second array:");
        foreach (var n in aOnlyNumbers)
        {
            Console.WriteLine(n);
        }
    }
}
