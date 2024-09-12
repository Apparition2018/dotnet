using dotnet.L.Demo;

namespace dotnetTest.Guide.LINQ;

/// <summary>
/// <a href="https://localhost:6291/101-linq-samples/index.md#projection-operators-the-select-keyword">LINQ - Projection Operators</a><br/>
/// <a href="https://learn.microsoft.com/en-us/dotnet/csharp/linq/standard-query-operators/projection-operations">投影运算</a>
/// </summary>
/// <remarks>
/// select 子句投影输出序列。它将每个输入元素转换为输出序列的形状
/// </remarks>
public class ProjectionOperators : Demo
{
    /// <summary>
    /// <a href="https://localhost:6291/101-linq-samples/docs/projections-2.md#select-anonymous-types-or-tuples">Select 匿名类型或元组</a>
    /// </summary>
    [Test]
    public void SelectAnonymousTypesOrTuples()
    {
        string[] words = ["aPPLE", "BlUeBeRrY", "cHeRry"];

        var upperLowerWords = from w in words
            select new { Upper = w.ToUpper(), Lower = w.ToLower() };

        foreach (var ul in upperLowerWords)
        {
            Console.WriteLine($"Uppercase: {ul.Upper}, Lowercase: {ul.Lower}");
        }

        var upperLowerWords2 = from w in words
            select (Upper: w.ToUpper(), Lower: w.ToLower());

        foreach (var ul in upperLowerWords2)
        {
            Console.WriteLine($"Uppercase: {ul.Upper}, Lowercase: {ul.Lower}");
        }
    }

    /// <summary>
    /// <a href="https://localhost:6291/101-linq-samples/docs/projections-3.md#select-with-index-of-item">Select 项目索引</a>
    /// </summary>
    [Test]
    public void SelectWithIndexOfItem()
    {
        int[] numbers = [5, 4, 1, 3, 9, 8, 6, 7, 2, 0];

        var numsInPlace = numbers.Select((num, index) => (Num: num, InPlace: (num == index)));

        Console.WriteLine("Number: In-place?");
        foreach (var n in numsInPlace)
        {
            Console.WriteLine($"{n.Num}: {n.InPlace}");
        }
    }

    /// <summary>
    /// <a href="https://localhost:6291/101-linq-samples/docs/projections-4.md#select-from-multiple-input-sequences">Select 多个输入序列</a><br/>
    /// <a href="https://localhost:6291/101-linq-samples/docs/projections-4.md#select-from-related-input-sequences">Select 相关输入序列</a>
    /// </summary>
    [Test]
    public void SelectFromMultipleAndRelatedInputSequences()
    {
        var studentList =
            from student in Students
            from score in student.Scores where score > 80
            select (student.ID, student.FirstName, score);

        foreach (var student in studentList)
        {
            Console.WriteLine(student);
        }
    }

    /// <summary>
    /// <a href="https://learn.microsoft.com/zh-cn/dotnet/csharp/linq/standard-query-operators/projection-operations#selectmany">SelectMany</a><br/>
    /// <a href="https://learn.microsoft.com/zh-cn/dotnet/csharp/linq/standard-query-operators/projection-operations#select-versus-selectmany">Select 与 SelectMany</a>
    /// </summary>
    [Test]
    public void SelectMany()
    {
        List<string> phrases = ["an apple a day", "the quick brown fox"];

        var query = from phrase in phrases
            from word in phrase.Split(' ')
            select word;

        query = phrases.SelectMany(p => p.Split(' '));

        foreach (string s in query)
        {
            Console.WriteLine(s);
        }
    }
}
