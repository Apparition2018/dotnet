using System.Numerics;

namespace dotnetTest.Guide.LanguageReference.OperatorsAndExpressions;

/// <summary>
/// <a href="https://learn.microsoft.com/zh-cn/dotnet/csharp/language-reference/operators/">运算符和表达式</a>
/// </summary>
public class OperatorsAndExpressions
{
    /// <summary>
    /// <a href="https://learn.microsoft.com/zh-cn/dotnet/csharp/language-reference/operators/collection-expressions">集合表达式</a>
    /// </summary>
    class CollectionExpressions
    {
        private int Sum(IEnumerable<int> values) => values.Sum();

        public void Example()
        {
            // As a parameter:
            int sum = Sum([1, 2, 3, 4, 5]);
        }

        /// <summary>
        /// <a href="https://learn.microsoft.com/zh-cn/dotnet/csharp/language-reference/operators/collection-expressions#spread-element">分布元素</a>
        /// </summary>
        [Test]
        public void SpreadElement()
        {
            string[] vowels = ["a", "e", "i", "o", "u"];
            string[] consonants =
                ["b", "c", "d", "f", "g", "h", "j", "k", "l", "m", "n", "p", "q", "r", "s", "t", "v", "w", "x", "z"];
            string[] alphabet = [.. vowels, .. consonants, "y"];
        }
    }

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

        /// <summary>
        /// <a href="https://learn.microsoft.com/zh-cn/dotnet/csharp/language-reference/operators/type-testing-and-cast#is-operator">is 运算符</a>
        /// 检查表达式结果的运行时类型是否与给定类型兼容
        /// </summary>
        class IsOperator
        {
            class Base;

            class Derived : Base;

            [Test]
            public void Test()
            {
                object b = new Base();
                Assert.That(b is Base, Is.EqualTo(true));
                Assert.That(b is Derived, Is.EqualTo(false));

                object d = new Derived();
                Assert.That(d is Base, Is.EqualTo(true));
                Assert.That(d is Derived, Is.EqualTo(true));

                int i = 27;
                Assert.That(i is IFormattable, Is.EqualTo(true));
                object iBox = i;
                Assert.That(iBox is int, Is.EqualTo(true));
                Assert.That(iBox is long, Is.EqualTo(false));
            }

            /// <summary>
            /// <a href="https://learn.microsoft.com/zh-cn/dotnet/csharp/language-reference/operators/type-testing-and-cast#type-testing-with-pattern-matching">带模式匹配的类型测试</a>
            /// </summary>
            [Test]
            public void TypeTestingWithPatternMatching()
            {
                int i = 23;
                object iBoxed = i;
                int? jNullable = 7;
                // a、b 分别存储类型测试后转换得来的结果
                if (iBoxed is int a && jNullable is int b)
                {
                    Assert.That(a + b, Is.EqualTo(30));
                }
            }
        }
    }

    /// <summary>
    /// <a href="https://learn.microsoft.com/zh-cn/dotnet/csharp/language-reference/operators/default">默认值表达式</a>：生成类型的默认值
    /// <list type="number">
    /// <item>default 运算符</item>
    /// <item>default 文本</item>
    /// </list>
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
            Assert.That(default(Complex).ToString(), Is.EqualTo("<0; 0>"));
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
    /// <a href="https://learn.microsoft.com/zh-cn/dotnet/csharp/language-reference/operators/stackalloc">stackalloc 表达式</a>
    /// 在堆栈上分配内存块。 当该方法返回时，将自动丢弃在方法执行期间创建的已分配堆栈内存块。<br/>
    /// <para>
    /// stackalloc 表达式的结果可分配给以下变量：
    /// <list type="number">
    /// <item><see cref="Span{T}"/>或<see cref="ReadOnlySpan{T}"/></item>
    /// <item><see cref="UnsafeCodeAndPointers.PointerTypes">指针类型</see></item>
    /// </list>
    /// </para>
    /// <para>
    /// 避免在堆栈上分配过多的内存：
    /// <list type="number">
    /// <item>限制使用 stackalloc 分配的内存量</item>
    /// <item>免在循环内使用 stackalloc</item>
    /// </list>
    /// </para>
    /// </summary>
    [Test]
    public void StackallocExpression()
    {
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
