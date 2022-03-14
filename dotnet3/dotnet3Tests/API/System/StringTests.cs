using System;
using NUnit.Framework;

namespace dotnet3Tests.API.System
{
    public class StringTests
    {
        [Test]
        public void Test()
        {
            // unsafe char[]        ToCharArray()
            Array.ForEach("123".ToCharArray(), Console.WriteLine);

            // string[]             Split(string? separator, StringSplitOptions options = StringSplitOptions.None)
            Array.ForEach("1,2,3".Split(","), Console.WriteLine);

            // static string        Format(string format, params object?[] args)
            string a = "a", b = "b", c = "c", d = "d";
            Console.WriteLine(string.Format("{0} {1} {2}", a, b, c, d)); // a b c
            Console.WriteLine(string.Format("{0} {0} {0}", a, a, a)); // a a a

            // string               PadLeft(int totalWidth)
            Console.WriteLine("123".PadLeft(5, '*')); // **123
            // string               PadRight(int totalWidth)
            Console.WriteLine("123".PadRight(5, '*')); // 123**

            // int                  IndexOfAny(char[] anyOf, int startIndex)
            Console.WriteLine("(1)[2]{3}".IndexOfAny(new[] {'(', '[', '{'}, 0)); // 0
            // int                  LastIndexOfAny(char[] anyOf, int startIndex)
            Console.WriteLine("(1)[2]{3}".LastIndexOfAny(new[] {')', ']', '}'}, 0)); // -1

            // unsafe string        Remove(int startIndex, int count)
            Console.WriteLine("123".Remove(1, 1)); // 13
            // unsafe string        Replace(string oldValue, string? newValue)
            Console.WriteLine("123".Replace("2", "")); // 13
        }

        [Test]
        public void Format()
        {
            /* :C 货币格式 */
            decimal price = 123.45m;
            int discount = 50;
            Console.WriteLine($"Price: {price:C} (Save {discount:C})"); // Price: ¥123.45 (Save ¥50.00)

            /* :N 数值格式 */
            decimal measurement = 123456.78912m;
            Console.WriteLine($"Measurement: {measurement:N} units"); // Measurement: 123,456.79 units
            Console.WriteLine($"Measurement: {measurement:N4} units"); // Measurement: 123,456.7891 units

            /* :P 百分比格式 */
            decimal tax = .36785m;
            Console.WriteLine($"Tax rate: {tax:P}"); // Tax rate: 36.79 %
            Console.WriteLine($"Tax rate: {tax:P4}"); // Tax rate: 36.7850%
        }
    }
}