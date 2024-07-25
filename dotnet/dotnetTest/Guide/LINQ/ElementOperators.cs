namespace dotnetTest.API.System.LINQ;

/// <summary>
/// <a href="https://localhost:6291/101-linq-samples/index.md#element-operators">LINQ - Element Operators</a>
/// </summary>
/// <remarks>
/// First、FirstOrDefault 和 ElementAt 方法提供了按位置选择单个元素的方法
/// </remarks>
public class ElementOperators
{
    /// <summary>
    /// <a href="https://localhost:6291/101-linq-samples/docs/elements.md#find-the-first-matching-element">查找第一个匹配的元素</a>
    /// </summary>
    [Test]
    public void FindFirstMatchingElement()
    {
        string[] strings = ["zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine"];

        string startsWithO = strings.First(s => s[0] == 'o');

        Console.WriteLine($"A string starting with 'o': {startsWithO}");
    }

    /// <summary>
    /// <a href="https://localhost:6291/101-linq-samples/docs/elements.md#first-element-of-a-possibly-empty-sequence">可为空序列的第一个元素</a>
    /// </summary>
    [Test]
    public void FirstElementsOfPossiblyEmptySequence()
    {
        int[] numbers = [];

        int firstNumOrDefault = numbers.FirstOrDefault();

        Console.WriteLine(firstNumOrDefault);
    }

    /// <summary>
    /// <a href="https://localhost:6291/101-linq-samples/docs/elements.md#find-element-at-position">查找指定位置的元素</a>
    /// </summary>
    [Test]
    public void FindElementAtPosition()
    {
        int[] numbers = [5, 4, 1, 3, 9, 8, 6, 7, 2, 0];

        int fourthLowNum = (
                from n in numbers
                where n > 5
                select n)
            .ElementAt(1);

        Console.WriteLine($"Second number > 5: {fourthLowNum}");
    }
}
