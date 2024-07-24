using Microsoft.AspNetCore.Http.Features;

namespace dotnetTest.API.System.LINQ;

/// <summary>
/// <a href="https://localhost:6291/101-linq-samples/index.md#eager-and-lazy-query-execution">LINQ - lazy and eager execution</a>
/// </summary>
public class EagerAndLazyQueryExecution
{
    private static readonly int[] Numbers = [5, 4, 1, 3, 9, 8, 6, 7, 2, 0];

    /// <summary>
    /// <a href="https://localhost:6291/101-linq-samples/docs/query-execution.md#queries-execute-lazily">Lazy Query</a>
    /// </summary>
    [Test]
    public void LazyQuery()
    {
        int i = 0;
        var q = from n in Numbers select ++i;

        foreach (var v in q)
        {
            Console.WriteLine($"v = {v}, i = {i}");
        }
    }

    /// <summary>
    /// <a href="https://localhost:6291/101-linq-samples/docs/query-execution.md#request-eager-query-execution">Eager Query</a>
    /// </summary>
    [Test]
    public void EagerQuery()
    {
        int i = 0;
        var q = (from n in Numbers select ++i).ToList();

        foreach (var v in q)
        {
            Console.WriteLine($"v = {v}, i = {i}");
        }
    }

    /// <summary>
    /// <a href="https://localhost:6291/101-linq-samples/docs/query-execution.md#request-eager-query-execution">重复使用具有新结果的查询</a>
    /// </summary>
    [Test]
    public void ReuseQueriesWithNewResults()
    {

        var lowNumbers = from n in Numbers
            where n <= 3
            select n;

        Console.WriteLine("First run numbers <= 3:");
        foreach (int n in lowNumbers)
        {
            Console.WriteLine(n);
        }

        for (int i = 0; i < Numbers.Length; i++)
        {
            Numbers[i] = -Numbers[i];
        }

        Console.WriteLine("Second run numbers <= 3:");
        foreach (int n in lowNumbers)
        {
            Console.WriteLine(n);
        }
    }
}
