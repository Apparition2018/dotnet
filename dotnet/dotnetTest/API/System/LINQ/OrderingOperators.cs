namespace dotnetTest.API.System.LINQ;

/// <summary>
/// <a href="https://localhost:6291/101-linq-samples/index.md#ordering-operators">LINQ - Ordering Operators</a>
/// </summary>
/// <remarks>
/// orderby 子句对输出序列进行排序。您可以控制用于排序的属性，并指定升序或降序
/// </remarks>
public class OrderingOperators
{
    private static readonly string[] Digits = ["zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine"];

    /// <summary>
    /// <a href="https://localhost:6291/101-linq-samples/docs/orderings-3.md#multiple-ordering-descending">多字段降序排序</a>
    /// </summary>
    [Test]
    public void MultipleOrderingDescending()
    {
        var sortedDigits = from digit in Digits
            orderby digit.Length descending, digit
            select digit;

        Console.WriteLine("Sorted digits:");
        foreach (var d in sortedDigits)
        {
            Console.WriteLine(d);
        }
    }

    /// <summary>
    /// <a href="https://localhost:6291/101-linq-samples/docs/orderings-3.md#reverse-the-sequence">反转序列</a>
    /// </summary>
    [Test]
    public void ReverseTheSequence()
    {
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
