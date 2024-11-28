using dotnetTest.Guide.LanguageReference.BuiltinTypes;

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
        #region 逻辑与
        Assert.That(true & true, Is.EqualTo(true));
        Assert.That(true & false, Is.EqualTo(false));
        Assert.That(false & true, Is.EqualTo(false));
        Assert.That(false & false, Is.EqualTo(false));
        #endregion

        #region 逻辑或
        Assert.That(true | true, Is.EqualTo(true));
        Assert.That(true | false, Is.EqualTo(true));
        Assert.That(false | true, Is.EqualTo(true));
        Assert.That(false | false, Is.EqualTo(false));
        #endregion

        #region 条件逻辑异或（计算结果与不等运算符 != 相同）
        Assert.That(true ^ true, Is.EqualTo(false));
        Assert.That(true ^ false, Is.EqualTo(true));
        Assert.That(false ^ true, Is.EqualTo(true));
        Assert.That(false ^ false, Is.EqualTo(false));
        #endregion

        #region 始终计算两个操作数
        Assert.That(false & SecondOperand(), Is.EqualTo(false));
        Assert.That(true | SecondOperand(), Is.EqualTo(true));
        #endregion
    }

    /// <summary>条件逻辑运算符</summary>
    [Test]
    public void ConditionalLogicOperators()
    {
        #region 条件逻辑与
        Assert.That(true && true, Is.EqualTo(true));
        Assert.That(true && false, Is.EqualTo(false));
        Assert.That(false && true, Is.EqualTo(false));
        Assert.That(false && false, Is.EqualTo(false));
        #endregion

        #region 条件逻辑或
        Assert.That(true || true, Is.EqualTo(true));
        Assert.That(true || false, Is.EqualTo(true));
        Assert.That(false || true, Is.EqualTo(true));
        Assert.That(false || false, Is.EqualTo(false));
        #endregion

        #region 不计算右侧操作数
        Assert.That(false && SecondOperand(), Is.EqualTo(false));
        Assert.That(true || SecondOperand(), Is.EqualTo(true));
        #endregion
    }

    /// <summary>
    /// <a href="https://learn.microsoft.com/zh-cn/dotnet/csharp/language-reference/operators/boolean-logical-operators#nullable-boolean-logical-operators">可为 null 的布尔逻辑运算符</a><br/>
    /// <a href="https://learn.microsoft.com/zh-cn/dotnet/csharp/language-reference/builtin-types/bool#three-valued-boolean-logic">三值布尔逻辑</a>
    /// </summary>
    /// <seealso cref="ValueTypes.NullableValueTypes.LiftedOperators">提升的运算符</seealso>
    [Test]
    public void NullableBooleanLogicalOperators()
    {
        bool? @null = null;

        #region 逻辑与
        Assert.That(true & null, Is.EqualTo(null));
        Assert.That(false & null, Is.EqualTo(false));
        Assert.That(null & true, Is.EqualTo(null));
        Assert.That(null & false, Is.EqualTo(false));
        Assert.That(@null & @null, Is.EqualTo(null));
        #endregion

        #region 逻辑或
        Assert.That(true | null, Is.EqualTo(true));
        Assert.That(false | null, Is.EqualTo(null));
        Assert.That(null | true, Is.EqualTo(true));
        Assert.That(null | false, Is.EqualTo(null));
        Assert.That(@null | @null, Is.EqualTo(null));
        #endregion

        #region 可为 null 的值类型
        int? @null2 = null;
        Assert.That(0 & @null2, Is.EqualTo(null));
        Assert.That(@null2 & 0, Is.EqualTo(null));
        Assert.That(1 & @null2, Is.EqualTo(null));
        Assert.That(@null2 & 1, Is.EqualTo(null));
        Assert.That(@null2 & @null2, Is.EqualTo(null));
        #endregion
    }
}
