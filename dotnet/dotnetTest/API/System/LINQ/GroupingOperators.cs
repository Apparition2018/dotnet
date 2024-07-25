using dotnet.L.Demo;
using dotnetTest.API.System.LINQ.Model;

namespace dotnetTest.API.System.LINQ;

/// <summary>
/// <a href="https://localhost:6291/101-linq-samples/index.md#grouping-operators">LINQ - Grouping operators</a><br/>
/// <a href="https://learn.microsoft.com/zh-cn/dotnet/csharp/linq/standard-query-operators/grouping-data">对数据分组</a>
/// </summary>
/// <remarks>
/// group by 和 into 关键字提供了分组构造，将输入序列的元素组织到桶中
/// </remarks>
public class GroupingOperators : Demo
{
    /// <summary>
    /// <a href="https://localhost:6291/101-linq-samples/docs/groupings.md#group-by-into-buckets">分组</a>
    /// </summary>
    [Test]
    public void GroupByIntoBuckets()
    {
        int[] numbers = [5, 4, 1, 3, 9, 8, 6, 7, 2, 0];

        var numberGroups = from n in numbers
            group n by n % 5
            into g
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
    /// <a href="https://learn.microsoft.com/zh-cn/dotnet/csharp/linq/standard-query-operators/grouping-data#group-by-value-example">按值分组</a>
    /// </summary>
    [Test]
    public void GroupByValue()
    {
        var groupByFirstLetterQuery =
            from student in Students
            let firstLetter = student.LastName[0]
            group student by firstLetter;

        groupByFirstLetterQuery = Students
            .GroupBy(student => student.LastName[0]);

        foreach (var studentGroup in groupByFirstLetterQuery)
        {
            Console.WriteLine($"Key: {studentGroup.Key}");
            foreach (var student in studentGroup)
            {
                Console.WriteLine($"\t{student.LastName}, {student.FirstName}");
            }
        }
    }

    /// <summary>
    /// <a href="https://learn.microsoft.com/zh-cn/dotnet/csharp/linq/standard-query-operators/grouping-data#group-by-a-range-example">按范围分组</a>
    /// </summary>
    [Test]
    public void GroupByRange()
    {
        static int GetPercentile(Student s)
        {
            double avg = s.Scores.Average();
            return avg > 0 ? (int)avg / 10 : 0;
        }

        var groupByPercentileQuery =
            from student in Students
            let percentile = GetPercentile(student)
            group new
            {
                student.FirstName,
                student.LastName
            } by percentile into percentGroup
            orderby percentGroup.Key
            select percentGroup;

        var groupByPercentileQuery2 = Students
            .Select(student => new { student, percentile = GetPercentile(student) })
            .GroupBy(student => student.percentile)
            .Select(percentGroup => new
            {
                percentGroup.Key,
                Students = percentGroup.Select(s => new { s.student.FirstName, s.student.LastName })
            })
            .OrderBy(percentGroup => percentGroup.Key);

        foreach (var studentGroup in groupByPercentileQuery)
        {
            Console.WriteLine($"Key: {studentGroup.Key * 10}");
            foreach (var item in studentGroup)
            {
                Console.WriteLine($"\t{item.LastName}, {item.FirstName}");
            }
        }
    }

    /// <summary>
    /// <a href="https://learn.microsoft.com/zh-cn/dotnet/csharp/linq/standard-query-operators/grouping-data#group-by-comparison-example">按比较分组</a>
    /// </summary>
    [Test]
    public void GroupByComparison()
    {
        var groupByHighAverageQuery =
            from student in Students
            group new
            {
                student.FirstName,
                student.LastName
            } by student.Scores.Average() > 75 into studentGroup
            select studentGroup;

        var groupByHighAverageQuery2 = Students
            .GroupBy(student => student.Scores.Average() > 75)
            .Select(group => new
            {
                group.Key,
                Students = group.AsEnumerable().Select(s => new { s.FirstName, s.LastName })
            });

        foreach (var studentGroup in groupByHighAverageQuery)
        {
            Console.WriteLine($"Key: {studentGroup.Key}");
            foreach (var student in studentGroup)
            {
                Console.WriteLine($"\t{student.FirstName} {student.LastName}");
            }
        }
    }

    /// <summary>
    /// <a href="https://learn.microsoft.com/zh-cn/dotnet/csharp/linq/standard-query-operators/grouping-data#group-by-anonymous-type">按匿名类型分组</a>
    /// </summary>
    [Test]
    public void GroupByAnonymousType()
    {
        var groupByCompoundKey =
            from student in Students
            group student by new
            {
                FirstLetterOfLastName = student.LastName[0],
                IsScoreOver85 = student.Scores[0] > 85
            } into studentGroup
            orderby studentGroup.Key.FirstLetterOfLastName
            select studentGroup;

        groupByCompoundKey = Students
            .GroupBy(student => new
            {
                FirstLetterOfLastName = student.LastName[0],
                IsScoreOver85 = student.Scores[0] > 85
            })
            .OrderBy(studentGroup => studentGroup.Key.FirstLetterOfLastName);

        foreach (var scoreGroup in groupByCompoundKey)
        {
            var s = scoreGroup.Key.IsScoreOver85 ? "more than 85" : "less than 85";
            Console.WriteLine($"Name starts with {scoreGroup.Key.FirstLetterOfLastName} who scored {s}");
            foreach (var item in scoreGroup)
            {
                Console.WriteLine($"\t{item.FirstName} {item.LastName}");
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
