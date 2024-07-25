using dotnet.L.Demo;
using dotnetTest.API.System.LINQ.Model;

namespace dotnetTest.API.System.LINQ;

/// <summary>
/// <a href="https://localhost:6291/101-linq-samples/index.md#set-operators">LINQ - Set Operators</a><br/>
/// <a href="https://learn.microsoft.com/zh-cn/dotnet/csharp/linq/standard-query-operators/set-operations">Set 运算</a>
/// </summary>
/// <remarks>
/// Distinct、Union、Intersect 和 Except 方法提供了比较多个序列的集合操作
/// </remarks>
public class SetOperators : Demo
{
    /// <summary>
    /// <a href="https://localhost:6291/101-linq-samples/docs/sets.md#find-distinct-elements">不同的元素</a><br/>
    /// <a href="https://learn.microsoft.com/zh-cn/dotnet/csharp/linq/standard-query-operators/set-operations#distinct-and-distinctby">Distinct 和 DistinctBy</a>
    /// </summary>
    [Test]
    public void FindDistinctElements()
    {
        string[] words = ["the", "quick", "brown", "fox", "jumped", "over", "the", "lazy", "dog"];

        IEnumerable<string> query = from word in words.Distinct()
            select word;

        foreach (var str in query)
        {
            Console.WriteLine(str);
        }

        foreach (string word in words.DistinctBy(p => p.Length))
        {
            Console.WriteLine(word);
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
    /// <a href="https://learn.microsoft.com/zh-cn/dotnet/csharp/linq/standard-query-operators/set-operations#union-and-unionby">Union 和 UnionBy</a>
    /// </summary>
    [Test]
    public void UnionBy()
    {
        foreach (var person in Students.Select(s => (s.FirstName, s.LastName)).UnionBy(
                     Teachers.Select(t => (FirstName: t.First, LastName: t.Last)), s => (s.FirstName, s.LastName)))
        {
            Console.WriteLine($"{person.FirstName} {person.LastName}");
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
    /// <a href="https://learn.microsoft.com/zh-cn/dotnet/csharp/linq/standard-query-operators/set-operations#intersect-and-intersectby">Intersect 和 IntersectBy</a>
    /// </summary>
    [Test]
    public void IntersectBy()
    {
        foreach (Student person in Students.IntersectBy(
                     Teachers.Select(t => (t.First, t.Last)), s => (s.FirstName, s.LastName)))
        {
            Console.WriteLine($"{person.FirstName} {person.LastName}");
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

    /// <summary>
    /// <a href="https://learn.microsoft.com/zh-cn/dotnet/csharp/linq/standard-query-operators/set-operations#except-and-exceptby">Except 和 ExceptBy</a>
    /// </summary>
    [Test]
    public void ExceptBy()
    {
        int[] teachersToExclude = [2];

        foreach (Teacher teacher in Teachers.ExceptBy(teachersToExclude, teacher => teacher.ID))
        {
            Console.WriteLine($"{teacher.First} {teacher.Last}");
        }
    }
}
