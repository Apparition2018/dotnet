namespace dotnetTest.API.System.LINQ;

/// <summary>
/// <a href="https://localhost:6291/101-linq-samples/index.md#sequence-operations">LINQ - Sequence operations</a>
/// </summary>
/// <remarks>
/// SequenceEqual、Concat 和 Zip 比较或操纵整个序列
/// </remarks>
public class SequenceOperations
{
    /// <summary>
    /// <a href="https://localhost:6291/101-linq-samples/docs/sequence-operations.md#compare-two-sequences-for-equality">比较两个序列是否相等</a>
    /// </summary>
    [Test]
    public void CompareTwoSequencesForEquality()
    {
        var wordsA = new[] { "cherry", "apple", "blueberry" };
        var wordsB = new[] { "apple", "blueberry", "cherry" };

        bool match = wordsA.SequenceEqual(wordsB);

        Console.WriteLine($"The sequences match: {match}");
    }

    /// <summary>
    /// <a href="https://localhost:6291/101-linq-samples/docs/sequence-operations.md#concatenate-two-sequences">连接两个序列</a>
    /// </summary>
    [Test]
    public void ConcatenateTwoSequences()
    {
        int[] numbersA = [0, 2, 4, 5, 6, 8, 9];
        int[] numbersB = [1, 3, 5, 7, 8];

        var allNumbers = numbersA.Concat(numbersB);
        allNumbers = (from n in numbersA select n).Concat(from n in numbersB select n);

        Console.WriteLine("All numbers from both arrays:");
        foreach (var n in allNumbers)
        {
            Console.WriteLine(n);
        }
    }

    /// <summary>
    /// <a href="https://localhost:6291/101-linq-samples/docs/sequence-operations.md#combine-sequences-with-zip">使用 zip 组合序列</a>
    /// </summary>
    [Test]
    public void CombineSequencesWithZip()
    {
        int[] vectorA = [0, 2, 4, 5, 6];
        int[] vectorB = [1, 3, 5, 7, 8];

        int dotProduct = vectorA.Zip(vectorB, (a, b) => a * b).Sum();

        Console.WriteLine($"Dot product: {dotProduct}");
    }
}
