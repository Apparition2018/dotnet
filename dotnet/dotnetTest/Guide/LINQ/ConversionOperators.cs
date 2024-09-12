namespace dotnetTest.Guide.LINQ;

/// <summary>
/// <a href="https://localhost:6291/101-linq-samples/index.md#conversion-operators">LINQ - Conversion Operators</a><br/>
/// <a href="https://learn.microsoft.com/zh-cn/dotnet/csharp/linq/standard-query-operators/converting-data-types">转换数据类型</a>
/// </summary>
/// <remarks>
/// ToArray、ToList、ToDictionary 和 OfType 方法提供了将 LINQ 结果转换为集合的方法
/// </remarks>
public class ConversionOperators
{
    /// <summary>
    /// <a href="https://localhost:6291/101-linq-samples/docs/conversions.md#convert-to-a-dictionary">转换为 Dictionary</a>
    /// </summary>
    [Test]
    public void ConvertToDictionary()
    {
        var scoreRecords = new[]
        {
            new { Name = "Alice", Score = 50 },
            new { Name = "Bob", Score = 40 },
            new { Name = "Cathy", Score = 45 }
        };

        var scoreRecordsDict = scoreRecords.ToDictionary(sr => sr.Name);

        Console.WriteLine("Bob's score: {0}", scoreRecordsDict["Bob"]);
    }

    /// <summary>
    /// <a href="https://localhost:6291/101-linq-samples/docs/conversions.md#convert-elements-that-match-a-type">转换与类型匹配的元素</a>
    /// </summary>
    [Test]
    public void ConvertElementsThatMatchType()
    {
        object[] numbers = [null, 1.0, "two", 3, "four", 5, "six", 7.0];

        var doubles = numbers.OfType<double>();

        Console.WriteLine("Numbers stored as doubles:");
        foreach (var d in doubles)
        {
            Console.WriteLine(d);
        }
    }
}
