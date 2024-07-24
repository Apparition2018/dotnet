using dotnet.L.Demo;

namespace dotnetTest.API.System.LINQ;

/// <summary>
/// <a href="https://localhost:6291/101-linq-samples/index.md#restriction-operators-the-where-keyword">LINQ - Restriction Operators</a>
/// </summary>
/// <remarks>
/// where 子句限制了输出序列。只有符合条件的元素才会添加到输出序列中
/// </remarks>
public class RestrictionOperators : Demo
{
    /// <summary>
    /// <a href="https://localhost:6291/101-linq-samples/docs/restrictions.md#filter-elements-on-a-property">基于属性过滤元素</a>
    /// </summary>
    [Test]
    public void FilterElementsOnProperty()
    {
        var personList = from person in PersonList
            where person.Id > 1
            select person;

        foreach (var person in personList)
        {
            Console.WriteLine(person);
        }
    }

    /// <summary>
    /// <a href="https://localhost:6291/101-linq-samples/docs/restrictions.md#filter-elements-based-on-position">基于位置过滤元素</a>
    /// </summary>
    [Test]
    public void FilterElementsBasedOnPosition()
    {
        string[] digits = ["zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine"];

        var shortDigits = digits.Where((digit, index) => digit.Length < index);

        Console.WriteLine("Short digits:");
        foreach (var d in shortDigits)
        {
            Console.WriteLine($"The word {d} is shorter than its value.");
        }
    }
}
