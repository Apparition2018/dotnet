using dotnet.L.Demo;

namespace dotnetTest.Guide.LanguageReference.Types;

/// <summary>
/// <a href="https://learn.microsoft.com/zh-cn/dotnet/csharp/language-reference/builtin-types/value-types">值类型</a>
///  </summary>
public class ValueTypes
{
    /// <summary>
    /// <a href="https://learn.microsoft.com/zh-cn/dotnet/csharp/language-reference/builtin-types/value-types#built-in-value-types">内置值类型</a>
    ///     <list type="number">
    ///     <item>整型数值类型 (Integral numeric types)</item>
    ///     <item>浮点型数值类型 (Floating-point numeric types)</item>
    ///     <item>bool (Boolean value)</item>
    ///     <item>char (Unicode UTF-16 character)</item>
    ///     </list>
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
    }

    /// <summary>
    /// <a href="https://learn.microsoft.com/zh-cn/dotnet/csharp/language-reference/builtin-types/floating-point-numeric-types">浮点数值类型</a>
    /// </summary>
    [Test]
    public void FloatingPointNumericTypes()
    {
        // double
        Console.WriteLine(0.42e2);      // 42
        // float
        Console.WriteLine(134.45E-2f);  // 1.3445
        // decimal
        Console.WriteLine(1.5E6m);      // 1500000
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

    /// <summary>
    /// <a href="https://learn.microsoft.com/zh-cn/dotnet/csharp/language-reference/builtin-types/enum">枚举类型</a>
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
    ///     <list type="bullet">
    ///     <item>任何字段声明都必须具有 readonly 修饰符（除构造函数外的其他实例成员是隐式 readonly）</item>
    ///     <item>任何属性（包括自动实现的属性）都必须是只读的或仅 init</item>
    ///     </list>
    /// </summary>
    class StructureTypes
    {
        /// <summary>
        /// <a href="https://learn.microsoft.com/zh-cn/dotnet/csharp/language-reference/builtin-types/struct#nondestructive-mutation">非破坏性变化</a>
        /// </summary>
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
}
