using dotnet.L.Demo;

namespace dotnetTest.API.System.LINQ;

/// <summary>
/// <a href="https://localhost:6291/101-linq-samples/index.md#ordering-operators">LINQ - Ordering Operators</a><br/>
/// <a href="https://learn.microsoft.com/zh-cn/dotnet/csharp/linq/standard-query-operators/sorting-data">对数据排序</a>
/// </summary>
/// <remarks>
/// orderby 子句对输出序列进行排序。您可以控制用于排序的属性，并指定升序或降序
/// </remarks>
public class OrderingOperators : Demo
{
    /// <summary>
    /// <a href="https://localhost:6291/101-linq-samples/docs/orderings-3.md#linq-ordering-operators">按多个属性排序</a><br/>
    /// <a href="https://learn.microsoft.com/zh-cn/dotnet/csharp/linq/standard-query-operators/sorting-data#secondary-ascending-sort">次要升序排序</a>
    /// </summary>
    [Test]
    public void OrderbyMultipleProperties()
    {
        var query = from teacher in Teachers
            orderby teacher.City, teacher.Last
            select (teacher.Last, teacher.City);

        query = Teachers
            .OrderBy(teacher => teacher.City)
            .ThenBy(teacher => teacher.Last)
            .Select(teacher => (teacher.Last, teacher.City));

        foreach ((string last, string city) in query)
        {
            Console.WriteLine($"City: {city}, Last Name: {last}");
        }
    }

    /// <summary>
    /// <a href="https://localhost:6291/101-linq-samples/docs/orderings-3.md#reverse-the-sequence">反转序列</a>
    /// </summary>
    [Test]
    public void ReverseTheSequence()
    {
        string[] Digits = ["zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine"];

        var reversedIDigits = (
                from digit in Digits
                where digit[1] == 'i'
                select digit)
            .Reverse();

        Console.WriteLine("A backwards list of the digits with a second character of 'i':");
        foreach (var d in reversedIDigits)
        {
            Console.WriteLine(d);
        }
    }

    /// <summary>不区分大小写比较器</summary>
    private class CaseInsensitiveComparer : IComparer<string>
    {
        public int Compare(string x, string y) =>
            string.Compare(x, y, StringComparison.OrdinalIgnoreCase);
    }

    /// <summary>
    /// <a href="https://localhost:6291/101-linq-samples/docs/orderings-4.md#ordering-with-a-custom-comparer">使用自定义比较器排序</a>
    /// </summary>
    [Test]
    public void OrdersWithCustomComparer()
    {
        string[] words = { "aPPLE", "AbAcUs", "bRaNcH", "BlUeBeRrY", "ClOvEr", "cHeRry" };

        var sortedWords = words.OrderByDescending(a => a, new CaseInsensitiveComparer());

        foreach (var word in sortedWords)
        {
            Console.WriteLine(word);
        }
    }
}
