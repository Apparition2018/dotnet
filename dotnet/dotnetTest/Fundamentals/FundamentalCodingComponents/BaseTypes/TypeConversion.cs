using System.Globalization;

namespace dotnetTest.Fundamentals.FundamentalCodingComponents.BaseTypes;

/// <summary>
/// <a href="https://learn.microsoft.com/zh-cn/dotnet/standard/base-types/type-conversion">类型转换</a>
/// <para>
/// 自动支持以下转换：
/// <list type="number">
/// <item>派生类 → 基类</item>
/// <item>基类 → 派生类，需要强制转换</item>
/// <item>实现类 → 接口</item>
/// <item>接口 → 实现类，需要强制转换</item>
/// </list>
/// </para>
/// <para>
/// 自定义类型转换：
/// <list type="number">
/// <item>Implicit 运算符：扩大转换、隐式转换</item>
/// <item>Explicit 运算符：收缩转换、显示转换</item>
/// <item>IConvertible 接口</item>
/// <item>Convert 类</item>
/// <item>TypeConverter 类</item>
/// </list>
/// </para>
/// </summary>
public class TypeConversion
{
    /// <summary>
    /// <a href="https://learn.microsoft.com/zh-cn/dotnet/standard/base-types/type-conversion#the-convert-class">Convert 类</a><br/>
    /// <a href="https://learn.microsoft.com/zh-cn/dotnet/fundamentals/runtime-libraries/system-convert">System.Convert</a>
    /// </summary>
    /// <remarks>
    /// <a href="https://learn.microsoft.com/zh-cn/dotnet/api/system.convert">Convert</a>
    /// 将一个基本数据类型转换为另一个基本数据类型
    /// </remarks>
    class Convert_
    {
        [Test]
        public void Test()
        {
            double dNumber = 23.15;
            Assert.That(Convert.ToInt32(dNumber), Is.EqualTo(23));
            Assert.That(Convert.ToBoolean(dNumber), Is.EqualTo(true));
            var strNumber = Convert.ToString(dNumber, CultureInfo.CurrentCulture);
            Assert.That(strNumber, Is.EqualTo("23.15"));
            Assert.That(Convert.ToChar(strNumber[0]), Is.EqualTo('2'));
        }

        /// <summary>
        /// <a href="https://learn.microsoft.com/zh-cn/dotnet/fundamentals/runtime-libraries/system-convert">非十进制数</a>
        /// </summary>
        [Test]
        public void NonDecimalNumbers()
        {
            int[] baseValues = { 2, 8, 10, 16 };
            const short value = Int16.MaxValue;
            foreach (var baseValue in baseValues)
            {
                // 将 16 位有符号整数的值转换为其在指定基数中的等效字符串表示形式
                string s = Convert.ToString(value, baseValue);
                // 将指定基数中数字的字符串表示形式转换为等效的 16 位有符号整数
                short value2 = Convert.ToInt16(s, baseValue);

                Console.WriteLine("{0} --> {1} (base {2}) --> {3}", value, s, baseValue, value2);
            }
        }
    }
}
