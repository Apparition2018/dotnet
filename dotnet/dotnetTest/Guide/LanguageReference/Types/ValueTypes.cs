using System.Runtime.CompilerServices;
using dotnet.L.Demo;
using dotnetTest.Guide.LanguageReference.Keywords;
using dotnetTest.Guide.LanguageReference.OperatorsAndExpressions;
using dotnetTest.Guide.ProgrammingGuide.ClassesStructsRecords;

namespace dotnetTest.Guide.LanguageReference.Types;

using Range = (int Minimum, int Maximum);

/// <summary>
/// <a href="https://learn.microsoft.com/zh-cn/dotnet/csharp/language-reference/builtin-types/value-types">值类型</a>
/// <para>
/// 种类：
/// <list type="number">
/// <item><see cref="StructureTypes">结构类型</see></item>
/// <item><see cref="EnumerationTypes">枚举类型</see></item>
/// </list>
/// </para>
/// <para>
/// 所有简单值都是结构类型，与其他结构类型的区别：
/// <list type="bullet">
/// <item>可以使用文字为简单类型提供值。例如，<c>int i = 2001</c></item>
/// <item>可以使用 const 关键字声明简单类型的常数。不能具有其他结构类型的常数。</item>
/// <item>常数表达式的操作数都是简单类型的常数，在编译时进行评估。</item>
/// </list>
/// </para>
/// </summary>
public class ValueTypes
{
    /// <summary>
    /// <a href="https://learn.microsoft.com/zh-cn/dotnet/csharp/language-reference/builtin-types/value-types#built-in-value-types">内置值类型</a>
    /// <list type="number">
    /// <item><a href="https://learn.microsoft.com/zh-cn/dotnet/csharp/language-reference/builtin-types/integral-numeric-types">整型数值类型</a></item>
    /// <item><a href="https://learn.microsoft.com/zh-cn/dotnet/csharp/language-reference/builtin-types/floating-point-numeric-types">浮点数值类型</a></item>
    /// <item>bool</item>
    /// <item><see cref="Char">char</see>：表示 Unicode UTF-16 字符</item>
    /// </list>
    /// </summary>
    class BuiltInValueTypes
    {
        [Test]
        public void Test()
        {
            Console.WriteLine("有符号整型类型");
            Console.WriteLine($"sbyte (SByte)    : {sbyte.MinValue} to {sbyte.MaxValue}");
            Console.WriteLine($"short (Int16)    : {short.MinValue} to {short.MaxValue}");
            Console.WriteLine($"int (Int32)      : {int.MinValue} to {int.MaxValue}");
            Console.WriteLine($"long (Int64)     : {long.MinValue} to {long.MaxValue}");
            Console.WriteLine($"nint (IntPtr)    : {nint.MinValue} to {nint.MaxValue}");

            Console.WriteLine("\n无符号整型类型");
            Console.WriteLine($"byte (Byte)      : {byte.MinValue} to {byte.MaxValue}");
            Console.WriteLine($"ushort (UInt16)  : {ushort.MinValue} to {ushort.MaxValue}");
            Console.WriteLine($"uint (UInt32)    : {uint.MinValue} to {uint.MaxValue}");
            Console.WriteLine($"ulong (UInt64)   : {ulong.MinValue} to {ulong.MaxValue}");
            Console.WriteLine($"nuint (UIntPtr)  : {nuint.MinValue} to {nuint.MaxValue}");

            Console.WriteLine("\n浮点数值类型");
            Console.WriteLine($"float (Single)   : {float.MinValue} to {float.MaxValue} (with ~6-9 digits of precision)");
            Console.WriteLine($"double (Double)  : {double.MinValue} to {double.MaxValue} (with ~15-17 digits of precision)");
            Console.WriteLine($"decimal (Decimal): {decimal.MinValue} to {decimal.MaxValue} (with 28-29 digits of precision)");

            Console.WriteLine("");
            Console.WriteLine($"bool (Boolean)   : {bool.FalseString} and {bool.TrueString}");
            Console.WriteLine($"char (Char)      : {char.MinValue} to {char.MaxValue}");
        }

        /// <summary>
        /// <a href="https://learn.microsoft.com/zh-cn/dotnet/csharp/language-reference/builtin-types/integral-numeric-types#integer-literals">整数文本</a>
        /// </summary>
        [Test]
        public void IntegerLiterals()
        {
            // 十六进制：使用 0x 或 0x 前缀
            var hexLiteral = 0x2A;
            Assert.That(hexLiteral, Is.EqualTo(42));
            // 二进制：使用 0b 或 0B 前缀
            var binaryLiteral = 0b_0010_1010;
            Assert.That(binaryLiteral, Is.EqualTo(42));
        }

        /// <summary>
        /// <a href="https://learn.microsoft.com/zh-cn/dotnet/csharp/language-reference/builtin-types/floating-point-numeric-types#real-literals">真实文本</a>
        /// </summary>
        [Test]
        public void RealLiterals()
        {
            // double
            Console.WriteLine(0.42e2); // 42
            // float
            Console.WriteLine(134.45E-2f); // 1.3445
            // decimal
            Console.WriteLine(1.5E6m); // 1500000
        }

        /// <summary>
        /// <a href="https://learn.microsoft.com/zh-cn/dotnet/csharp/language-reference/builtin-types/char#literals">char</a>
        /// </summary>
        [Test]
        public void Char()
        {
            var chars = new[]
            {
                'j',
                // Unicode
                '\u006A',
                // 十六进制
                '\x006A',
                (char)106,
            };
            Assert.That(string.Join(" ", chars), Is.EqualTo("j j j j"));
        }
    }

    /// <summary>
    /// <a href="https://learn.microsoft.com/zh-cn/dotnet/csharp/language-reference/builtin-types/enum">枚举类型</a>
    /// 由基础整型数值类型的一组命名常量定义的值类型
    /// </summary>
    [Test]
    public void EnumerationTypes()
    {
        Days meetingDays = Days.Monday | Days.Wednesday | Days.Friday;
        Days workingFromHomeDays = Days.Thursday | Days.Friday;
        Console.WriteLine($"Join a meeting by phone on {meetingDays & workingFromHomeDays}");
        bool isMeetingOnTuesday = (meetingDays & Days.Tuesday) == Days.Tuesday;
        Console.WriteLine($"Is there a meeting on Tuesday: {isMeetingOnTuesday}");
        var d = (Days)37;
        Console.WriteLine(d); // Monday, Wednesday, Saturday
    }

    /// <summary>
    /// <a href="https://learn.microsoft.com/zh-cn/dotnet/csharp/language-reference/builtin-types/struct">结构类型</a>
    /// 一种可封装数据和相关功能的值类型
    /// <para>
    /// 设计限制：
    /// <list type="bullet">
    /// <item>不能从其他类或结构类型继承，也不能作为类的基础类型，可以实现接口</item>
    /// <item>不能在结构类型中声明 <see cref="Finalizers"/></item>
    /// <item>在 C# 11 之前，结构类型的构造函数必须初始化该类型的所有实例字段</item>
    /// </list>
    /// </para>
    /// <para>
    /// readonly 结构：
    /// <list type="bullet">
    /// <item>任何字段声明都必须具有 readonly 修饰符（除构造函数外的其他实例成员是隐式 readonly）</item>
    /// <item>任何属性（包括自动实现的属性）都必须是只读的或仅 init</item>
    /// </list>
    /// </para>
    /// </summary>
    class StructureTypes
    {
        /// <summary>
        /// <a href="https://learn.microsoft.com/zh-cn/dotnet/csharp/language-reference/builtin-types/struct#nondestructive-mutation">非破坏性变化</a>
        /// </summary>
        /// <seealso cref="OperatorsAndExpressions.WithExpression"/>
        [Test]
        public void NondestructiveMutation()
        {
            var p1 = new Coords(0, 0);
            Console.WriteLine(p1); // (0, 0)
            var p2 = p1 with { X = 3 };
            Console.WriteLine(p2); // (3, 0)
            var p3 = p1 with { X = 1, Y = 4 };
            Console.WriteLine(p3); // (1, 4)
        }

        /// <summary>
        /// <a href="https://learn.microsoft.com/zh-cn/dotnet/csharp/language-reference/builtin-types/struct#inline-arrays">内联数组</a>
        /// <list type="bullet">
        /// <item>可以像访问数组一样访问内联数组，以读取和写入值</item>
        /// <item>使用<a href="https://learn.microsoft.com/zh-cn/dotnet/csharp/language-reference/operators/member-access-operators#range-operator-">范围</a>和<a href="https://learn.microsoft.com/zh-cn/dotnet/csharp/language-reference/operators/member-access-operators#indexer-access">索引</a>运算符</item>
        /// </list>
        /// <para>
        /// 特征：①单个字段 ②未指定显式布局
        /// </para>
        /// </summary>
        /// <remarks>
        /// <a href="https://learn.microsoft.com/zh-cn/dotnet/csharp/language-reference/proposals/csharp-12.0/inline-arrays">Inline Arrays</a>
        /// </remarks>
        [InlineArray(10)]
        struct CharBuffer
        {
            private char _firstElement;
        }

        /// <summary>
        /// <a href="https://learn.microsoft.com/zh-cn/dotnet/csharp/language-reference/builtin-types/struct#struct-initialization-and-default-values">结构初始化和默认值</a>
        /// </summary>
        [Test]
        public void StructInitializationAndDefaultValues()
        {
            var c1 = new Coords();
            Console.WriteLine(c1); // (NaN, NaN)
            var c2 = default(Coords);
            Console.WriteLine(c2); // (0, 0)
            var cs = new Coords[2];
            Console.WriteLine(string.Join(", ", cs)); // (0, 0), (0, 0)
        }
    }

    /// <summary>
    /// <a href="https://learn.microsoft.com/zh-cn/dotnet/csharp/language-reference/builtin-types/value-tuples">元组类型</a>
    /// 提供了简洁的语法来将多个数据元素分组成一个轻型数据结构
    /// <para>
    /// 元组由 System.ValueTuple 支持，与 System.Tuple 的区别如下：
    /// <list type="bullet">
    /// <item>System.ValueTuple 值类型；System.Tuple 引用类型</item>
    /// <item>System.ValueTuple 可变；System.Tuple 不可变</item>
    /// <item>System.ValueTuple 数据成员是字段；System.Tuple 数据成员是属性</item>
    /// </list>
    /// </para>
    /// </summary>
    /// <remarks>BaseTypes.md 在匿名类型和元组类型之间进行选择</remarks>
    class TupleTypes
    {
        [Test]
        public void Test()
        {
            (double, int) t1 = (4.5, 3);
            // 元组字段的默认名称：Item1、Item2 ……
            Console.WriteLine($"Tuple with elements {t1.Item1} and {t1.Item2}.");

            // 可指定字段名称：https://learn.microsoft.com/zh-cn/dotnet/csharp/language-reference/builtin-types/value-tuples#tuple-field-names
            (double Sum, int Count) t2 = (4.5, 3);
            Console.WriteLine($"Sum of {t2.Count} elements is {t2.Sum}.");
            // 不能在元组类型中定义方法，但可以使用 .NET 提供的方法
            Console.WriteLine($"Hash code of {t2} is {t2.GetHashCode()}.");
        }

        /// <summary>
        /// <a href="https://learn.microsoft.com/zh-cn/dotnet/csharp/language-reference/builtin-types/value-tuples#use-cases-of-tuples">最常见用例：作为方法返回类型</a>
        /// </summary>
        private (int min, int max) FindMinMax(int[] input)
        {
            if (input is null || input.Length == 0)
            {
                throw new ArgumentException("Cannot find minimum and maximum of a null or empty array.");
            }

            var min = int.MaxValue;
            var max = int.MinValue;
            foreach (var i in input)
            {
                if (i < min)
                {
                    min = i;
                }

                if (i > max)
                {
                    max = i;
                }
            }

            return (min, max);
        }

        /// <summary>
        /// 使用 using 指令指定元组类型的别名
        /// <see cref="GlobalUsings"/>
        /// </summary>
        /// <seealso cref="Keywords.NamespaceKeywords.UsingDirective.UsingAlias"/>
        [Test]
        public void SpecifyAnAlias()
        {
            BandPass bracket = (40, 100);
            Console.WriteLine($"The bandpass filter is {bracket.Min} to {bracket.Max}");

            // 可以解构使用 BandPass 别名声明的元组
            (int a, int b) = bracket;
            Assert.That($"{a}-{b}", Is.EqualTo($"{bracket.Min}-{bracket.Max}"));

            // 具有相同参数个数和成员类型的第二个别名可以与原始别名互换使用
            Range range = bracket;
            Console.WriteLine($"The range is {range.Minimum} to {range.Maximum}");
        }

        /// <summary>
        /// <a href="https://learn.microsoft.com/zh-cn/dotnet/csharp/language-reference/builtin-types/value-tuples#tuple-field-names">元组赋值和析构</a>
        /// 元组类型之间的赋值，需满足：
        /// <list type="number">
        /// <item>相同数量的元素</item>
        /// <item>相应的元素类型相同，或可隐式转换为相应左侧元素类型</item>
        /// </list>
        /// </summary>
        [Test]
        public void AssignmentAndDeconstruction()
        {
            (int, double) t1 = (17, 3.14);
            (double First, double Second) t2 = (0.0, 1.0);
            t2 = t1;
            Assert.That(t2.First, Is.EqualTo(17));
            Assert.That(t2.Second, Is.EqualTo(3.14));

            // 与模式匹配相结
            for (var i = 0; i < 20; i++)
            {
                if (Math.DivRem(i, 3) is (Quotient: var q, Remainder: 0))
                {
                    Console.Write($"{i} ");
                }
            }
        }

        /// <summary>
        /// <a href="https://learn.microsoft.com/zh-cn/dotnet/csharp/language-reference/builtin-types/value-tuples#tuple-equality">元组相等</a>
        /// 元组比较，需满足：
        /// <list type="number">
        /// <item>相同数量的元素</item>
        /// <item>相应元素可使用 == 和 != 进行比较</item>
        /// </list>
        /// </summary>
        [Test]
        public void Equality()
        {
            (int a, byte b) left = (5, 10);
            (long a, int b) right = (5, 10);
            Assert.That(left == right);

            // 不会考虑元组字段名称
            var t1 = (A: 5, B: 10);
            var t2 = (B: 5, A: 10);
            Assert.That(t1 == t2);
        }
    }

    /// <summary>
    /// <a href="https://learn.microsoft.com/zh-cn/dotnet/csharp/language-reference/builtin-types/nullable-value-types">可为 null 的值类型</a>
    /// <list type="bullet">
    /// <item>可以为 null 的值类型 T? 表示其基础值类型T的所有值和一个 null 值。例如，将以下三个值中的任何一个分配给 bool?：true、false、null</item>
    /// <item>任何可为空的值类型都是泛型 System.Nullable 结构的实例</item>
    /// </list>
    /// </summary>
    class NullableValueTypes
    {
        /// <summary>
        /// <a href="https://learn.microsoft.com/zh-cn/dotnet/csharp/language-reference/builtin-types/nullable-value-types#examination-of-an-instance-of-a-nullable-value-type">检查可为空值类型的实例</a>
        /// </summary>
        [Test]
        public void Examination()
        {
            int? a = null;

            // is 运算符与类型模式
            Assert.That(a is int, Is.EqualTo(true));

            // Nullable<T>.HasValue
            Assert.That(a.HasValue, Is.EqualTo(false));

            // 与 null 比较
            Assert.That(a == null, Is.EqualTo(true));
        }

        /// <summary>
        /// <a href="https://learn.microsoft.com/zh-cn/dotnet/csharp/language-reference/builtin-types/nullable-value-types#conversion-from-a-nullable-value-type-to-an-underlying-type">可为空的值类型 → 基础类型</a>
        /// </summary>
        /// <seealso cref="NullOperators.NullCoalescingOperators"/>
        [Test]
        public void ConversionToAnUnderlyingType()
        {
            // Null 合并操作符 (??)
            int? a = 28;
            int b = a ?? -1;
            Assert.That(b, Is.EqualTo(28));

            int? c = null;
            int d = c ?? -1;
            Assert.That(d, Is.EqualTo(-1));

            // 显式强制转换
            int e = (int)a;
            Assert.That(e, Is.EqualTo(28));
        }

        /// <summary>
        /// <a href="https://learn.microsoft.com/zh-cn/dotnet/csharp/language-reference/builtin-types/nullable-value-types#lifted-operators">提升运算符</a>
        /// </summary>
        [Test]
        public void LiftedOperators()
        {
            int? a = 10;
            int? b = null;

            // 一元运算符、二元运算符、值类型 T 支持的任何重载运算符
            // 如果一个或全部两个操作数为 null ，结果为 null
            Assert.That(0 & b, Is.EqualTo(null));
            Assert.That(a | b, Is.EqualTo(null));

            // <、>、<=、>=，如果一个或全部两个操作数为 null ，结果为 false
            Assert.That(a >= null, Is.EqualTo(false));
            Assert.That(a < null, Is.EqualTo(false));
        }


        /// <summary>
        /// <a href="https://learn.microsoft.com/zh-cn/dotnet/csharp/language-reference/builtin-types/nullable-value-types#how-to-identify-a-nullable-value-type">识别可为空的值类型</a>
        /// </summary>
        [Test]
        public void IdentifyANullableValueType()
        {
            Assert.That(IsNullable(typeof(int?)), Is.EqualTo(true));
            Assert.That(IsNullable(typeof(int)), Is.EqualTo(false));

            int? a = 14;
            int b = 17;
            // 不要使用 Object.GetType 方法 判断实例是否为可为空的值类型
            Assert.That(a.GetType().FullName, Is.EqualTo("System.Int32"));
            // 无法使用 is 运算符 判断实例是否为可为空的值类型
            Assert.That(a is int, Is.EqualTo(true));
            Assert.That(b is int?, Is.EqualTo(true));
        }

        private bool IsNullable(Type type) =>
            // 返回 null 类型的基础类型参数
            Nullable.GetUnderlyingType(type) != null;
    }
}
