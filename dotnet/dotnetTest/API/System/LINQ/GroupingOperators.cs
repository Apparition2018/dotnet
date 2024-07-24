namespace dotnetTest.API.System.LINQ;

/// <summary>
/// <a href="https://localhost:6291/101-linq-samples/index.md#grouping-operators">LINQ - Grouping operators</a>
/// </summary>
/// <remarks>
/// group by 和 into 关键字提供了分组构造，将输入序列的元素组织到桶中
/// </remarks>
public class GroupingOperators
{
    /// <summary>
    /// <a href="https://localhost:6291/101-linq-samples/docs/groupings.md#group-by-into-buckets">分组</a>
    /// </summary>
    [Test]
    public void GroupByIntoBuckets()
    {
        int[] numbers = [5, 4, 1, 3, 9, 8, 6, 7, 2, 0];

        var numberGroups = from n in numbers
            group n by n % 5 into g
            select (Remainder: g.Key, Numbers: g);

        foreach (var g in numberGroups)
        {
            Console.WriteLine($"Numbers with a remainder of {g.Remainder} when divided by 5:");
            foreach (var n in g.Numbers)
            {
                Console.WriteLine(n);
            }
        }
    }

    /// <summary>
    /// <a href="https://localhost:6291/101-linq-samples/docs/groupings.md#nested-group-by-queries">嵌套分组查询</a>
    /// </summary>
    [Test]
    public void NestedGroupByQueries() { }

    private class AnagramEqualityComparer : IEqualityComparer<string>
    {
        public bool Equals(string x, string y) => getCanonicalString(x) == getCanonicalString(y);

        public int GetHashCode(string obj) => getCanonicalString(obj).GetHashCode();

        private string getCanonicalString(string word)
        {
            char[] wordChars = word.ToCharArray();
            Array.Sort<char>(wordChars);
            return new string(wordChars);
        }
    }

    /// <summary>
    /// <a href="https://localhost:6291/101-linq-samples/docs/groupings-2.md#groupby-with-a-custom-comparer">按自定义比较器分组</a>
    /// </summary>
    [Test]
    public void GroupbyWithCustomComparer()
    {
        string[] anagrams = ["from   ", " salt", " earn ", "  last   ", " near ", " form  "];

        var orderGroups = anagrams.GroupBy(w => w.Trim(), new AnagramEqualityComparer());

        foreach (var set in orderGroups)
        {
            // The key would be the first item in the set
            foreach (var word in set)
            {
                Console.WriteLine(word);
            }
            Console.WriteLine("...");
        }
    }
}
