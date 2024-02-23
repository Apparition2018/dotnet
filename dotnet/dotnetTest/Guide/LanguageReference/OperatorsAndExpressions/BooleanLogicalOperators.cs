namespace dotnetTest.Guide.LanguageReference.OperatorsAndExpressions;

/// <summary>
/// <a href="https://learn.microsoft.com/zh-cn/dotnet/csharp/language-reference/operators/boolean-logical-operators#nullable-boolean-logical-operators">布尔逻辑运算符</a>
/// <list type="number">
/// <item>一元 !（逻辑非）运算符</item>
/// <item>二元 &（逻辑与）、|（逻辑或）和 ^（逻辑异或）运算符</item>
/// <item>二元 &&（条件逻辑与）和 ||（条件逻辑或）运算符。</item>
/// </list>
/// </summary>
public class BooleanLogicalOperators
{
    private bool SecondOperand()
    {
        Console.WriteLine("Second operand is evaluated.");
        return true;
    }

    /// <summary>逻辑运算符</summary>
    [Test]
    public void LogicOperators()
    {
        /* 逻辑与 */
        Assert.That(true & true, Is.EqualTo(true));
        Assert.That(true & false, Is.EqualTo(false));
        Assert.That(false & true, Is.EqualTo(false));
        Assert.That(false & false, Is.EqualTo(false));

        /* 逻辑或 */
        Assert.That(true | true, Is.EqualTo(true));
        Assert.That(true | false, Is.EqualTo(true));
        Assert.That(false | true, Is.EqualTo(true));
        Assert.That(false | false, Is.EqualTo(false));

        /* 条件逻辑异或
         * 计算结果与不等运算符 != 相同 */
        Assert.That(true ^ true, Is.EqualTo(false));
        Assert.That(true ^ false, Is.EqualTo(true));
        Assert.That(false ^ true, Is.EqualTo(true));
        Assert.That(false ^ false, Is.EqualTo(false));

        // 始终计算两个操作数
        Assert.That(false & SecondOperand(), Is.EqualTo(false));
        Assert.That(true | SecondOperand(), Is.EqualTo(true));
    }

    /// <summary>条件逻辑运算符</summary>
    [Test]
    public void ConditionalLogicOperators()
    {
        /* 条件逻辑与 */
        Assert.That(true && true, Is.EqualTo(true));
        Assert.That(true && false, Is.EqualTo(false));
        Assert.That(false && true, Is.EqualTo(false));
        Assert.That(false && false, Is.EqualTo(false));

        /* 条件逻辑或 */
        Assert.That(true || true, Is.EqualTo(true));
        Assert.That(true || false, Is.EqualTo(true));
        Assert.That(false || true, Is.EqualTo(true));
        Assert.That(false || false, Is.EqualTo(false));

        // 不计算右侧操作数
        Assert.That(false && SecondOperand(), Is.EqualTo(false));
        Assert.That(true || SecondOperand(), Is.EqualTo(true));
    }

    /// <summary>
    /// <a href="https://learn.microsoft.com/zh-cn/dotnet/csharp/language-reference/operators/boolean-logical-operators#nullable-boolean-logical-operators">可以为 null 的布尔逻辑运算符</a><br/>
    /// <a href="https://learn.microsoft.com/zh-cn/dotnet/csharp/language-reference/builtin-types/bool#three-valued-boolean-logic">三值布尔逻辑</a>
    /// </summary>
    [Test]
    public void NullableBooleanLogicalOperators()
    {
        bool? @null = null;

        /* 逻辑与 */
        Assert.That(true & null, Is.EqualTo(null));
        Assert.That(false & null, Is.EqualTo(false));
        Assert.That(null & true, Is.EqualTo(null));
        Assert.That(null & false, Is.EqualTo(false));
        Assert.That(@null & @null, Is.EqualTo(null));

        /* 逻辑或 */
        Assert.That(true | null, Is.EqualTo(true));
        Assert.That(false | null, Is.EqualTo(null));
        Assert.That(null | true, Is.EqualTo(true));
        Assert.That(null | false, Is.EqualTo(null));
        Assert.That(@null | @null, Is.EqualTo(null));

        // 上述行为不同于可为 null 的值类型的典型运算符行为
        // 提升运算符 @see ValueType.NullableValueTypes#LiftedOperators
        int? @null2 = null;
        Assert.That(0 & @null2, Is.EqualTo(null));
        Assert.That(@null2 & 0, Is.EqualTo(null));
        Assert.That(1 & @null2, Is.EqualTo(null));
        Assert.That(@null2 & 1, Is.EqualTo(null));
    }
}
