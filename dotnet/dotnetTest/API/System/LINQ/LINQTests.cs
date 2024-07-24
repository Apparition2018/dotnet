namespace dotnetTest.API.System.LINQ;

/// <summary>
/// <a href="https://learn.microsoft.com/zh-cn/dotnet/csharp/linq/">语言集成查询 (LINQ)</a>
/// </summary>
public class LINQTests
{
    [Test]
    public void LINQ()
    {
        int[] scores = [3, 45, 82, 97, 92, 100, 81, 60];

        IEnumerable<string> scoreQuery =
            from score in scores
            where score > 80
            orderby score descending
            select $"The score is {score}";

        IEnumerable<string> scoreQuery2 = scores
            .Where(s => s > 80)
            .OrderByDescending(s => s)
            .Select(s => $"The score is {s}");

        List<string> myScores = scoreQuery.ToList();
        foreach (string score in myScores)
        {
            Console.WriteLine(score);
        }
    }
}
