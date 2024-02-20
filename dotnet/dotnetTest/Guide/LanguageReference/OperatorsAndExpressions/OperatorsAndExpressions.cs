namespace dotnetTest.Guide.LanguageReference.OperatorsAndExpressions;

/// <summary>
/// <a href="https://learn.microsoft.com/zh-cn/dotnet/csharp/language-reference/operators/">运算符和表达式</a>
/// </summary>
public class OperatorsAndExpressions
{
    /// <summary>
    /// <a href="https://learn.microsoft.com/zh-cn/dotnet/csharp/language-reference/operators/type-testing-and-cast">类型</a> - 测试运算符 和 强制转换表达式
    /// </summary>
    class Type
    {
        /// <summary>
        /// <a href="https://learn.microsoft.com/zh-cn/dotnet/csharp/language-reference/operators/type-testing-and-cast#typeof-operator">typeof 运算符</a>
        /// 用于获取某个类型的 System.Type 实例
        /// </summary>
        [Test]
        public void TypeofOperator()
        {
            Assert.That(typeof(int).ToString(), Is.EqualTo("System.Int32"));
        }
    }

    /// <summary>
    /// <a href="https://learn.microsoft.com/zh-cn/dotnet/csharp/language-reference/operators/default">默认值表达式</a>：生成类型的默认值
    ///     <list type="number">
    ///     <item>default 运算符</item>
    ///     <item>default 文本</item>
    ///     </list>
    /// </summary>
    class DefaultValueExpressions
    {
        /// <summary>
        /// <a href="https://learn.microsoft.com/zh-cn/dotnet/csharp/language-reference/operators/default#default-operator">default 运算符</a>
        /// </summary>
        [Test]
        public void DefaultOperator()
        {
            Assert.That(default(int), Is.EqualTo(0));
            Assert.That(default(int?), Is.EqualTo(null));
            Assert.That(default(System.Numerics.Complex).ToString(), Is.EqualTo("<0; 0>"));
            Assert.That(default(List<int>), Is.EqualTo(null));
        }

        /// <summary>
        /// <a href="https://learn.microsoft.com/zh-cn/dotnet/csharp/language-reference/operators/default#default-literal">default 文本</a>
        /// </summary>
        [Test]
        public void DefaultLiteral()
        {
            var array = new bool[4];
            for (var i = 0; i < array.Length; i++)
            {
                array[i] = default;
            }

            Assert.That(string.Join(",", array), Is.EqualTo("False,False,False,False"));
        }
    }

    /// <summary>
    /// <a href="https://learn.microsoft.com/zh-cn/dotnet/csharp/language-reference/operators/nameof">nameof 表达式</a>
    /// 生成变量、类型或成员的名称作为字符串常量
    /// </summary>
    [Test]
    public void NameofExpression()
    {
        Assert.That(nameof(System.Collections.Generic), Is.EqualTo("Generic"));
    }

    /// <summary>
    /// <a href="https://learn.microsoft.com/zh-cn/dotnet/csharp/language-reference/operators/with-expression">with 表达式</a>
    /// 使用修改的特定属性和字段生成其操作数的副本
    /// </summary>
    [Test]
    public void WithExpression()
    {
        var apples = new { Item = "Apples", Price = 1.19m };
        Console.WriteLine($"Original: {apples}");

        var saleApples = apples with { Price = 0.79m };
        Console.WriteLine($"Sale: {saleApples}");
    }
}
