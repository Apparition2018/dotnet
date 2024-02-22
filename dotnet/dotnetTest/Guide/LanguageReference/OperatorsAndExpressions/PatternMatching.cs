namespace dotnetTest.Guide.LanguageReference.OperatorsAndExpressions;

/// <summary>
/// <a href="https://learn.microsoft.com/zh-cn/dotnet/csharp/language-reference/operators/patterns">模式匹配</a>
/// <para>
/// 支持模式匹配的表达式或语句：
/// <list type="number">
/// <item><a href="https://learn.microsoft.com/zh-cn/dotnet/csharp/language-reference/operators/is">is 表达式</a></item>
/// <item><a href="https://learn.microsoft.com/zh-cn/dotnet/csharp/language-reference/statements/selection-statements#the-switch-statement">switch 语句</a></item>
/// <item><a href="https://learn.microsoft.com/zh-cn/dotnet/csharp/language-reference/operators/switch-expression">switch 表达式</a></item>
/// </list>
/// </para>
/// </summary>
/// <remarks>
/// <a href="https://learn.microsoft.com/zh-cn/dotnet/csharp/fundamentals/functional/pattern-matching">模式匹配</a><br/>
/// <a href="https://learn.microsoft.com/zh-cn/dotnet/csharp/fundamentals/tutorials/pattern-matching">教程：使用模式匹配来生成类型驱动和数据驱动的算法</a>
/// </remarks>
public class PatternMatching
{
    /// <summary>
    /// <a href="https://learn.microsoft.com/zh-cn/dotnet/csharp/language-reference/operators/is">is 运算符</a>
    /// </summary>
    /// <seealso cref="OperatorsAndExpressions.Type.IsOperator"/>
    class IsOperator
    {
        /// <summary>将表达式与关系模式和带有嵌套常量的属性模式相匹配</summary>
        /// <remarks>
        /// <a href="https://learn.microsoft.com/zh-cn/dotnet/csharp/language-reference/operators/patterns#property-pattern">属性模式</a><br/>
        /// <a href="https://learn.microsoft.com/zh-cn/dotnet/csharp/language-reference/operators/patterns#relational-patterns">关系模式</a>
        /// </remarks>
        static bool IsFirstFridayOfOctober(DateTime date) =>
            date is { Month: 10, Day: <= 7, DayOfWeek: DayOfWeek.Friday };

        /// <summary>检查数组中处于预期位置的整数值</summary>
        /// <remarks>
        /// <a href="https://learn.microsoft.com/zh-cn/dotnet/csharp/language-reference/operators/patterns#list-patterns">列表模式</a>
        /// </remarks>
        [Test]
        public void ListPatterns()
        {
            int[] odd = [1, 3, 5];
            int[] even = [2, 4, 6];
            int[] fib = [1, 1, 2, 3, 5];

            Assert.That(odd is [1, _, 2, ..], Is.EqualTo(false));
            Assert.That(fib is [.., 1, 2, 3, _], Is.EqualTo(false));
            Assert.That(even is [2, _, 6], Is.EqualTo(false));
            Assert.That(even is [2, .., 6], Is.EqualTo(false));
        }
    }
}
