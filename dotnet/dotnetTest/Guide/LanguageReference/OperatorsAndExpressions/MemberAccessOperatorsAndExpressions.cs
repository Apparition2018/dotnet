namespace dotnetTest.Guide.LanguageReference.OperatorsAndExpressions;

/// <summary>
/// <a href="https://learn.microsoft.com/zh-cn/dotnet/csharp/language-reference/operators/member-access-operators#indexer-operator-">成员访问操作符和表达式</a>
/// <list type="bullet">
/// <item>成员访问 .：用于访问命名空间或类型的成员</item>
/// <item><see cref="IndexerOperator">数组元素或索引器访问 []</see>：用于访问数组元素或类型索引器</item>
/// <item><see cref="NullOperators.NullConditionalOperators">null 条件运算符 ?. 和 ?[]</see>：仅当操作数为非 null 时才用于执行成员或元素访问运算</item>
/// <item>调用 ()：用于调用被访问的方法或调用委托</item>
/// <item><see cref="IndexFromEndOperator">从末尾开始索引 ^</see>：指示元素位置来自序列的末尾</item>
/// <item><see cref="RangeOperator">范围 ..</see>：指定可用于获取一系列序列元素的索引范围</item>
/// </list>
/// </summary>
public class MemberAccessOperatorsAndExpressions
{
    /// <summary>
    /// <a href="https://learn.microsoft.com/zh-cn/dotnet/csharp/language-reference/operators/member-access-operators#indexer-operator-">索引访问器</a>
    /// 用于访问数组、索引器、指针元素
    /// </summary>
    [Test]
    public void IndexerOperator()
    {
        var dict = new Dictionary<string, double>();
        dict["one"] = 1;
        dict["two"] = 2;
        dict["pi"] = Math.PI;
        Assert.That(dict["one"] + dict["two"] < dict["pi"]);
    }

    /// <summary>
    /// <a href="https://learn.microsoft.com/zh-cn/dotnet/csharp/language-reference/operators/member-access-operators#index-from-end-operator-">从末尾运算符</a>
    /// 指示序列末尾的元素位置
    /// </summary>
    [Test]
    public void IndexFromEndOperator()
    {
        Assert.That("Twenty"[^2], Is.EqualTo('t'));
    }

    /// <summary>
    /// <a href="https://learn.microsoft.com/zh-cn/dotnet/csharp/language-reference/operators/member-access-operators#range-operator-">范围运算符</a>
    /// <list type="bullet">
    /// <item>指定某一索引范围的开头和末尾作为其操作数</item>
    /// <item>左侧操作数是范围的包含性开头；右侧操作数是范围的不包含性末尾</item>
    /// <item>表达式 a..b 属于 System.Range 类型</item>
    /// <item>可以省略 .. 运算符的任何操作数来获取无限制范围，例如 a..等效于 a..^0、.. 等效于 0..^0</item>
    /// </list>
    /// </summary>
    [Test]
    public void RangeOperator()
    {
        int[] numbers = [0, 10, 20, 30, 40, 50];
        // 表达式 ^end 属于 System.Index 类型
        Index index = ^1;
        // 表达式 a..b 属于 System.Range 类型
        Range range = 1..index;
        Assert.That(string.Join(" ", numbers[range]), Is.EqualTo("10 20 30 40"));
        Assert.That(string.Join(" ", numbers[..^1]), Is.EqualTo("0 10 20 30 40"));
        Assert.That(string.Join(" ", numbers[1..]), Is.EqualTo("10 20 30 40 50"));
    }
}
