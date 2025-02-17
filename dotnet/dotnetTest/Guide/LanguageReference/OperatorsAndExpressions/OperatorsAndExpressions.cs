using System.Numerics;
using dotnetTest.Guide.LanguageReference.Keywords;
using dotnetTest.Guide.ProgrammingGuide;
using dotnetTest.Guide.ProgrammingGuide.ClassesStructsRecords;
using dotnetTest.Guide.ProgrammingGuide.StatementsExpressionsEquality;

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
    /// <a href="https://learn.microsoft.com/zh-cn/dotnet/csharp/language-reference/operators/type-testing-and-cast">类型 - 测试运算符 和 强制转换表达式</a>
    /// </summary>
    class Type
    {
        /// <summary>
        /// <a href="https://learn.microsoft.com/zh-cn/dotnet/csharp/language-reference/operators/type-testing-and-cast#as-operator">as 运算符</a>
        /// <list type="bullet">
        /// <item>将表达式结果显式转换为给定的引用或可以为 null 值的类型</item>
        /// <item>如果无法进行转换，则返回 null</item>
        /// <item>与强制转换表达式不同，as 运算符永远不会引发异常</item>
        /// </list>
        /// </summary>
        [Test]
        public void AsOperator()
        {
            IEnumerable<int> numbers = new List<int> {10, 20, 30};
            IList<int> indexable = (numbers as IList<int>)!;
            if (indexable != null)
            {
                Console.WriteLine(indexable[0] + indexable[^1]);
            }
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

        /// <summary>
        /// <a href="https://learn.microsoft.com/zh-cn/dotnet/csharp/language-reference/operators/type-testing-and-cast#typeof-operator">typeof 运算符</a>
        /// 用于获取某个类型的 System.Type 实例
        /// </summary>
        [Test]
        public void TypeofOperator()
        {
            Assert.That(typeof(int).ToString(), Is.EqualTo("System_.Int32"));
        }
    }

    /// <summary>
    /// <a href="https://learn.microsoft.com/zh-cn/dotnet/csharp/language-reference/operators/await">await 运算符</a> - 异步等待任务完成
    /// <list type="bullet">
    /// <item>暂停对其所属的 async 方法的求值，直到其操作数表示的异步操作完成</item>
    /// <item>只能在 async 修改的方法、lambda 表达式或匿名方法中使用 await 运算符</item>
    /// <item>在异步方法中，不能在同步函数的本地主体、lock 语句块内以及不安全的上下文中使用 await 运算符</item>
    /// </list>
    /// <a href="https://learn.microsoft.com/zh-cn/dotnet/csharp/language-reference/operators/await#asynchronous-streams-and-disposables">异步流和可释放对象</a>
    /// </summary>
    /// <seealso cref="Modifiers.Async"/>
    class Await;

    /// <summary>
    /// <a href="https://learn.microsoft.com/zh-cn/dotnet/csharp/language-reference/operators/default">默认值表达式</a> - 生成类型的默认值
    /// </summary>
    class DefaultValueExpressions
    {
        /// <summary>
        /// <a href="https://learn.microsoft.com/zh-cn/dotnet/csharp/language-reference/operators/default#default-operator">default 运算符</a>
        /// default 运算符的实参必须是类型或类型形参的名称
        /// </summary>
        /// <remarks>
        /// <a href="https://learn.microsoft.com/zh-cn/dotnet/csharp/language-reference/builtin-types/default-values">内置类型的默认值</a>
        /// </remarks>
        [Test]
        public void DefaultOperator()
        {
            // 值类型
            Assert.That(default(int), Is.EqualTo(0));
            // 引用类型
            Assert.That(default(object), Is.EqualTo(null));
            // bool
            Assert.That(default(bool), Is.EqualTo(false));
            // char
            Assert.That(default(char), Is.EqualTo('\0'));
            // enum
            Assert.That(default(DayOfWeek), Is.EqualTo((DayOfWeek)0));
            // struct
            Assert.That(default(Complex), Is.EqualTo(new Complex(0, 0)));
            // 可为 null 的值类型
            Assert.That(default(int?), Is.EqualTo(null));
        }

        /// <summary>
        /// <a href="https://learn.microsoft.com/zh-cn/dotnet/csharp/language-reference/operators/default#default-literal">default 文本</a>
        /// 当编译器可以推断表达式类型时，可以使用 default 文本生成类型的默认值
        /// <para>
        /// 可以在以下情况使用 default 文本
        /// <list type="bullet">
        /// <item>对变量进行赋值或初始化时</item>
        /// <item>在声明<see cref="Method.NamedAndOptionalArguments.OptionalArguments">可选方法参数</see>的默认值时</item>
        /// <item>在方法调用中提供参数值时</item>
        /// <item>在 return 语句中或作为<see cref="ExpressionBodiedMembers">表达式主体成员</see>中的表达式时</item>
        /// </list>
        /// </para>
        /// </summary>
        [Test]
        public void DefaultLiteral()
        {
            var array = new bool[4];
            for (var i = 0; i < array.Length; i++)
            {
                array[i] = default;
            }

            Assert.That(string.Join(" ", array), Is.EqualTo("False False False False"));
        }
    }

    /// <summary>
    /// <a href="https://learn.microsoft.com/zh-cn/dotnet/csharp/language-reference/operators/delegate-operator">delegate</a>
    /// <list type="bullet">
    /// <item>delegate 运算符创建一个可以转换为委托类型的<see cref="Delegates.Declare">匿名方法</see></item>
    /// <item>delegate 关键字声明委托类型</item>
    /// </list>
    /// <para>
    /// 匿名方法 vs lambda
    /// <list type="bullet">
    /// <item>lambda 本身就是匿名方法</item>
    /// <item>lambda 允许参数不指定类型</item>
    /// <item>lambda 方法体允许是单一表达式</item>
    /// </list>
    /// </para>
    /// </summary>
    class DelegateOperator;

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
    /// <a href="https://learn.microsoft.com/zh-cn/dotnet/csharp/language-reference/operators/new-operator">new 运算符</a>
    /// 创建一个类型的新实例
    /// </summary>
    /// <seealso cref="Modifiers.NewModifier">成员声明修饰符</seealso>
    /// <seealso cref="Keywords.GenericTypeConstraintKeywords.NewConstraint">泛型类型约束</seealso>
    [Test]
    public void NewOperator()
    {
        // 构造函数调用
        var dict = new Dictionary<string, int>();

        // Target-typed new：如果表达式的目标类型是已知的，则可以省略类型名称
        List<int> xs = new();
        List<int> ys = new(capacity: 10_000);
        List<int> zs = new() { Capacity = 20_000 };
        Dictionary<int, List<int>> lookup = new()
        {
            [1] = new() { 1, 2, 3 },
            [2] = new() { 5, 8, 3 },
            [5] = new() { 1, 0, 4 }
        };

        // 数组创建
        var numbers = new int[3];
        var a = new int[3] { 10, 20, 30 };
        var b = new int[] { 10, 20, 30 };
        var c = new[] { 10, 20, 30 };

        // 匿名类型的实例化
        var anonymous = new { Greeting = "Hello", Name = "World" };
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
    public void StackallocExpression() { }

    /// <summary>
    /// <a href="https://learn.microsoft.com/zh-cn/dotnet/csharp/language-reference/operators/with-expression">with 表达式</a>
    /// 生成其操作数的副本，使用<see cref="ObjectAndCollectionInitializers">对象初始值设定项</see>语法修改指定的属性和字段
    /// </summary>
    [Test]
    public void WithExpression()
    {
        var apples = new { Item = "Apples", Price = 1.19m };
        Console.WriteLine($"Original: {apples}");

        var saleApples = apples with { Price = 0.79m };
        Console.WriteLine($"Sale: {saleApples}");
    }

    /// <summary>
    /// <a href="https://learn.microsoft.com/zh-cn/dotnet/csharp/language-reference/operators/operator-overloading">运算符重载</a>
    /// 用户定义的类型可重载预定义的 C# 运算符。当一个或两个操作数都是某类型时，此类型可提供操作的自定义实现。
    /// <para>
    /// 使用 operator 关键字来声明运算符。 运算符声明必须符合以下规则：
    /// <list type="number">
    /// <item>同时包含 public 和 static 修饰符</item>
    /// <item>一元运算符有一个输入参数。二元运算符有两个输入参数。在每种情况下，都至少有一个参数必须具有类型 T 或 T?，其中 T 是包含运算符声明的类型。</item>
    /// </list>
    /// </para>
    /// </summary>
    class OperatorOverloading
    {
        /// <summary>
        /// 一个表示有理数的简单结构，重载一些算术运算符
        /// </summary>
        readonly struct Fraction
        {
            private readonly int _num;
            private readonly int _den;

            public Fraction(int numerator, int denominator)
            {
                if (denominator == 0)
                {
                    throw new ArgumentException("Denominator cannot be zero.", nameof(denominator));
                }

                _num = numerator;
                _den = denominator;
            }

            public static Fraction operator +(Fraction a) => a;
            public static Fraction operator -(Fraction a) => new(-a._num, a._den);

            public static Fraction operator +(Fraction a, Fraction b)
                => new(a._num * b._den + b._num * a._den, a._den * b._den);

            public static Fraction operator -(Fraction a, Fraction b) => a + (-b);

            public static Fraction operator *(Fraction a, Fraction b) => new(a._num * b._num, a._den * b._den);

            public static Fraction operator /(Fraction a, Fraction b)
            {
                if (b._num == 0)
                {
                    throw new DivideByZeroException();
                }

                return new Fraction(a._num * b._den, a._den * b._num);
            }

            public override string ToString() => $"{_num} / {_den}";
        }

        [Test]
        public void Test()
        {
            Fraction a = new Fraction(5, 4);
            Fraction b = new Fraction(1, 2);
            Assert.That((-a).ToString(), Is.EqualTo("-5 / 4"));
            Assert.That((a + b).ToString(), Is.EqualTo("14 / 8"));
            Assert.That((a - b).ToString(), Is.EqualTo("6 / 8"));
            Assert.That((a * b).ToString(), Is.EqualTo("5 / 8"));
            Assert.That((a / b).ToString(), Is.EqualTo("10 / 4"));
        }
    }
}
