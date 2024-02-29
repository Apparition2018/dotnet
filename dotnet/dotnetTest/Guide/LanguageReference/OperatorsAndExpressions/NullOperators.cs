namespace dotnetTest.Guide.LanguageReference.OperatorsAndExpressions;

/// <summary>null 运算符</summary>
public class NullOperators
{
    /// <summary>
    /// <a href="https://learn.microsoft.com/zh-cn/dotnet/csharp/language-reference/operators/null-coalescing-operator">null 合并运算符</a>
    /// <list type="bullet">
    /// <item>??= 左操作数必须是变量、属性、索引器</item>
    /// <item>?? 和 ??= 左操作数的类型必须是可为空的值类型</item>
    /// </list>
    /// </summary>
    class NullCoalescingOperators
    {
        [Test]
        public void Test()
        {
            List<int>? numbers = null;
            int? a = null;

            // ??：左操作数不为 null，返回左值，否则计算并返回右值
            Assert.That(a ?? 3, Is.EqualTo(3));

            // ??=：左操作数为 null，才赋值
            (numbers ??= new List<int>()).Add(5);
            Assert.That(string.Join(" ", numbers), Is.EqualTo("5"));

            // throw 表达式 作为右操作符，使参数检查代码更简洁
            int b = a ?? throw new ArgumentNullException(nameof(a), "cannot be null");
        }

        // 和 null 条件运算符一起使用
        private double SumNumbers(List<double[]> setsOfNumbers, int indexOfSetToSum)
        {
            return setsOfNumbers?[indexOfSetToSum]?.Sum() ?? double.NaN;
        }
    }

    /// <summary>
    /// <a href="https://learn.microsoft.com/zh-cn/dotnet/csharp/language-reference/operators/null-forgiving">! （null 包容）运算符</a>
    /// 取消表达式的所有可为 null 警告
    /// </summary>
    class NullForgivingOperator
    {
        class Person
        {
            public Person(string name) => Name = name ?? throw new ArgumentNullException(nameof(name));
            public string Name { get; }
        }

        [Test]
        public void Test()
        {
            var person = new Person(null!);
        }
    }

    /// <summary>
    /// <a href="https://learn.microsoft.com/zh-cn/dotnet/csharp/language-reference/operators/member-access-operators#null-conditional-operators--and-">Null 条件运算符</a>
    /// 仅当操作数的计算结果为非 NULL 时，NULL 条件运算符才对其操作数应用成员访问 (?.) 或元素访问 (?[]) 操作；否则，它会返回 null。
    /// Null 条件成员访问运算符 (?.) 也称为 Elvis 运算符。
    /// </summary>
    [Test]
    public void NullConditionalOperators()
    {
        List<double[]?> numberSets =
        [
            [1.0, 2.0, 3.0],
            null
        ];
        Assert.That(SumNumbers(numberSets!, 1), Is.EqualTo(double.NaN));
        return;

        double SumNumbers(List<double[]> setsOfNumbers, int indexOfSetToSum)
        {
            return setsOfNumbers?[indexOfSetToSum]?.Sum() ?? double.NaN;
        }
    }
}
