using dotnet.L.Demo;

namespace dotnetTest.API.System.LINQ;

/// <summary>
/// <a href="https://localhost:6291/101-linq-samples/index.md#projection-operators-the-select-keyword">LINQ - Projection Operators</a>
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
    /// <a href="https://localhost:6291/101-linq-samples/docs/projections-4.md#select-from-multiple-input-sequences">Select 多个输入序列</a>
    /// <a href="https://localhost:6291/101-linq-samples/docs/projections-4.md#select-from-related-input-sequences">Select 相关输入序列</a>
    /// </summary>
    [Test]
    public void SelectFromMultipleAndRelatedInputSequences()
    {
        var personList =
            from p in PersonList where p.Id != 0
            from infos in p.OtherInfo where infos.Length == 0
            select (p.Id, p.Name);

        foreach (var person in personList)
        {
            Console.WriteLine(person);
        }
    }
}
