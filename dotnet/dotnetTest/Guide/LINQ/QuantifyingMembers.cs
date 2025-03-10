using dotnet.L.Demo;

namespace dotnetTest.Guide.LINQ;

/// <summary>
/// <a href="https://localhost:6291/101-linq-samples/index.md#quantifying-members">LINQ - Quantifiers</a><br/>
/// <a href="https://learn.microsoft.com/zh-cn/dotnet/csharp/linq/standard-query-operators/quantifier-operations">限定符运算</a>
/// </summary>
/// <remarks>
/// Any 和 All 方法确定所有元素或任何元素匹配条件
/// </remarks>
public class QuantifyingMembers : Demo
{
    /// <summary>
    /// <a href="https://localhost:6291/101-linq-samples/docs/quantifiers.md#check-for-any-matching-elements">检查是否有匹配的元素</a>
    /// </summary>
    [Test]
    public void CheckForAnyMatchingElements()
    {
        string[] words = { "believe", "relief", "receipt", "field" };

        bool iAfterE = words.Any(w => w.Contains("ei"));

        Console.WriteLine($"There is a word that contains in the list that contains 'ei': {iAfterE}");
    }

    /// <summary>
    /// <a href="https://localhost:6291/101-linq-samples/docs/quantifiers.md#group-by-any-elements-matching-a-condition">按符合条件的 Any 元素分组</a>
    /// </summary>
    [Test]
    public void GroupByAnyElementsMatchingCondition()
    {
        var studentList = from student in Students
            where student.Scores.Any(score => score > 90)
            select $"{student.FirstName} {student.LastName}: {string.Join(", ", student.Scores.Select(s => s.ToString()))}";

        foreach (string name in studentList)
        {
            Console.WriteLine($"{name}");
        }
    }

    /// <summary>
    /// <a href="https://localhost:6291/101-linq-samples/docs/quantifiers.md#code-container-inline">检查所有元素是否符合条件</a>
    /// </summary>
    [Test]
    public void CheckAllElementsMatchCondition()
    {
        int[] numbers = [1, 11, 3, 19, 41, 65, 19];

        bool onlyOdd = numbers.All(n => n % 2 == 1);

        Console.WriteLine($"The list contains only odd numbers: {onlyOdd}");
    }

    /// <summary>
    /// <a href="https://localhost:6291/101-linq-samples/docs/quantifiers.md#group-by-all-elements-matching-a-condition">按符合条件的所有元素分组</a>
    /// </summary>
    [Test]
    public void GroupByAllElementsMatchingCondition()
    {
        var studentList = from student in Students
            where student.Scores.All(score => score > 70)
            select $"{student.FirstName} {student.LastName}: {string.Join(", ", student.Scores.Select(s => s.ToString()))}";

        foreach (string name in studentList)
        {
            Console.WriteLine($"{name}");
        }
    }

    /// <summary>
    /// <a href="https://learn.microsoft.com/zh-cn/dotnet/csharp/linq/standard-query-operators/quantifier-operations#contains">包含</a>
    /// </summary>
    [Test]
    public void Contains()
    {
        var studentList = from student in Students
            where student.Scores.Contains(77)
            select $"{student.FirstName} {student.LastName}: {string.Join(", ", student.Scores.Select(s => s.ToString()))}";

        foreach (string name in studentList)
        {
            Console.WriteLine($"{name}");
        }
    }
}
