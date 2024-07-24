using dotnet.L.Demo;

namespace dotnetTest.API.System.LINQ;

/// <summary>
/// <a href="https://localhost:6291/101-linq-samples/index.md#aggregator-operators">LINQ - Aggregators</a>
/// </summary>
/// <remarks>
/// 聚合器方法返回从序列中的所有元素计算出的单个值。聚合器方法包括 Count、Sum、Min、Max、Average 和 Aggregate
/// </remarks>
public class AggregatorOperators : Demo
{
    /// <summary>
    /// <a href="https://localhost:6291/101-linq-samples/docs/aggregates.md#count-all-elements-matching-a-condition">计算符合条件的所有元素</a>
    /// </summary>
    [Test]
    public void CountAllElementsMatchingCondition()
    {
        int[] numbers = [5, 4, 1, 3, 9, 8, 6, 7, 2, 0];

        int oddNumbers = numbers.Count(n => n % 2 == 1);

        Console.WriteLine("There are {0} odd numbers in the list.", oddNumbers);
    }

    /// <summary>
    /// <a href="https://localhost:6291/101-linq-samples/docs/aggregates.md#count-all-elements-that-are-members-of-a-group">计算属于组的所有元素</a>
    /// </summary>
    [Test]
    public void CountAllElementsThatAreMembersOfGroup()
    {
        var ageCounts = from p in PersonList
            group p by p.Age into g
            select (g.Key, g.Count());

        foreach (var valueTuple in ageCounts)
        {
            Console.WriteLine(valueTuple);
        }
    }

    /// <summary>
    /// <a href="https://localhost:6291/101-linq-samples/docs/aggregates-1.md#sum-a-projection-from-a-sequence">相加序列中的投影</a>
    /// </summary>
    [Test]
    public void SumProjectionFromSequence()
    {
        string[] words = ["cherry", "apple", "blueberry"];

        double totalChars = words.Sum(w => w.Length);

        Console.WriteLine($"There are a total of {totalChars} characters in these words.");
    }

    /// <summary>
    /// <a href="https://localhost:6291/101-linq-samples/docs/aggregates-1.md#sum-all-elements-that-are-members-of-a-group">相加属于组的所有元素</a>
    /// </summary>
    [Test]
    public void SumAllElementsThatAreMembersOfGroup()
    {
        var ages = from p in PersonList
            group p by p.Age into g
            select (g.Key, g.Sum(p => p.Age));

        foreach (var valueTuple in ages)
        {
            Console.WriteLine(valueTuple);
        }
    }

    /// <summary>
    /// <a herf="https://localhost:6291/101-linq-samples/docs/aggregates-2.md#find-all-elements-matching-the-minimum">匹配最小的所有元素</a>
    /// </summary>
    [Test]
    public void FindAllElementsMatchingTheMinimum()
    {
        var ages = from p in PersonList
            group p by p.Age into g
            let minNameLen = g.Min(p => p.Name.Length)
            select (g.Key, minNamePersonList: g.Where(p => p.Name.Length == minNameLen));

        foreach (var age in ages)
        {
            foreach (var person in age.minNamePersonList)
            {
                Console.WriteLine(person);
            }
        }
    }

    /// <summary>
    /// <a herf="https://localhost:6291/101-linq-samples/docs/aggregates-4.md#compute-an-aggregate-value-from-all-elements-of-a-sequence">计算序列的聚合值</a>
    /// </summary>
    [Test]
    public void ComputeAggregateValueFromAllElementsOfSequence()
    {
        double[] doubles = [1.7, 2.3, 1.9, 4.1, 2.9];

        double product = doubles.Aggregate((runningProduct, nextFactor) => runningProduct * nextFactor);

        Console.WriteLine($"Total product of all numbers: {product}");
    }

    /// <summary>
    /// <a herf="https://localhost:6291/101-linq-samples/docs/aggregates-4.md#compute-an-aggregate-value-from-a-seed-value-and-all-elements-of-a-sequence">根据种子计算序列的聚合值</a>
    /// </summary>
    [Test]
    public void ComputeAggregateValueFromSeedValueAndAllElementsOfSequence()
    {
        double startBalance = 100.0;

        int[] attemptedWithdrawals = [20, 10, 40, 50, 10, 70, 30];

        double endBalance =
            attemptedWithdrawals.Aggregate(startBalance,
                (balance, nextWithdrawal) => (nextWithdrawal <= balance) ? (balance - nextWithdrawal) : balance);

        Console.WriteLine($"Ending balance: {endBalance}");
    }
}
