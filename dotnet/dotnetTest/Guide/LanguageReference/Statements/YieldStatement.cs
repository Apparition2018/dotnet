namespace dotnetTest.Guide.LanguageReference.Statements;

/// <summary>
/// <a href="https://learn.microsoft.com/zh-cn/dotnet/csharp/language-reference/statements/yield">yield 语句</a>
/// 在迭代器中使用 yield 语句提供下一个值或标记迭代结束
/// </summary>
public class YieldStatement
{
    /// <summary>提供下一个值：yield return</summary>
    [Test]
    public void ProvideTheNextValue()
    {
        IEnumerable<int> ProduceEvenNumbers(int upto)
        {
            for (int i = 0; i <= upto; i += 2)
            {
                yield return i;
            }
        }

        Assert.That(string.Join(" ", ProduceEvenNumbers(9)), Is.EqualTo("0 2 4 6 8"));
    }

    /// <summary>标记结束：yield break</summary>
    [Test]
    public void SignalTheEnd()
    {
        IEnumerable<int> TakeWhilePositive(IEnumerable<int> numbers)
        {
            foreach (int n in numbers)
            {
                if (n > 0)
                {
                    yield return n;
                }
                else
                {
                    yield break;
                }
            }
        }

        Assert.That(string.Join(" ", TakeWhilePositive([2, 3, 4, 5, -1, 3, 4])), Is.EqualTo("2 3 4 5"));
        Assert.That(string.Join(" ", TakeWhilePositive([9, 8, 7])), Is.EqualTo("9 8 7"));
    }
}
