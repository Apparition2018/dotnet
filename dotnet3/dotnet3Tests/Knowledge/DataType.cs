using System;
using NUnit.Framework;

namespace dotnet3Tests.Knowledge
{
    public class DataType
    {
        [Test]
        public void Test()
        {
            Console.WriteLine("有符号整型类型 (Signed integral types):");
            Console.WriteLine($"sbyte  : {sbyte.MinValue} to {sbyte.MaxValue}");
            Console.WriteLine($"short  : {short.MinValue} to {short.MaxValue}");
            Console.WriteLine($"int    : {int.MinValue} to {int.MaxValue}");
            Console.WriteLine($"long   : {long.MinValue} to {long.MaxValue}");

            Console.WriteLine();
            Console.WriteLine("无符号整型类型 (Unsigned integral types):");
            Console.WriteLine($"byte   : {byte.MinValue} to {byte.MaxValue}");
            Console.WriteLine($"ushort : {ushort.MinValue} to {ushort.MaxValue}");
            Console.WriteLine($"uint   : {uint.MinValue} to {uint.MaxValue}");
            Console.WriteLine($"ulong  : {ulong.MinValue} to {ulong.MaxValue}");

            Console.WriteLine("");
            Console.WriteLine("浮点型类型 (Floating point types):");
            Console.WriteLine($"float  : {float.MinValue} to {float.MaxValue} (with ~6-9 digits of precision)");
            Console.WriteLine($"double : {double.MinValue} to {double.MaxValue} (with ~15-17 digits of precision)");
            Console.WriteLine($"decimal: {decimal.MinValue} to {decimal.MaxValue} (with 28-29 digits of precision)");
        }

        /// <summary>类型转换</summary>
        /// <remarks>https://docs.microsoft.com/zh-CN/dotnet/standard/base-types/conversion-tables</remarks>
        [Test]
        public void TypeConversion()
        {
            /* Int32 */
            // int      Parse(string s)
            Console.WriteLine(int.Parse("5") + int.Parse("7"));
            // bool     TryParse(string? s, out int result)
            if (int.TryParse("123", out int result))
            {
                Console.WriteLine(result);
            }

            /* Convert */
            // int      ToInt32(Decimal value)
            Console.WriteLine((int) 1.5m); // 1
            Console.WriteLine(Convert.ToInt32(1.5m)); // 2
        }
    }
}