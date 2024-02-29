using System.Globalization;
using dotnetTest.API.System.Globalization;
using dotnetTest.API.System.Text;

namespace dotnetTest.Fundamentals.RuntimeLibraries.WorkWithStrings;

/// <summary>
/// <a href="https://learn.microsoft.com/zh-cn/dotnet/standard/base-types/character-encoding-introduction">字符编码</a>
/// </summary>
public class CharacterEncoding
{
    /// <summary>
    /// <a href="https://learn.microsoft.com/zh-cn/dotnet/standard/base-types/character-encoding-introduction#the-string-and-char-types">string 和 char 类型</a>
    /// string 在逻辑上是一个 16-bit 值的序列，每个值都是 char struct 的实例。
    /// <para>
    /// 整个 code points 有两个子范围：
    /// <list type="number">
    /// <item>基本多语言平面（Basic Multilingual Plane，BMP）：U+0000..U+FFFF，16-bit 范围提供65536个 code points</item>
    /// <item>补充码位（Supplementary code points）：U+10000..U+10FFFF，21-bit 范围提供超过一百万个 code points</item>
    /// </list>
    /// </para>
    /// </summary>
    [Test]
    public void TheStringAndCharTypes()
    {
        // 大多数语言的每个 character 由一个 char 值表示
        Assert.That('你', Is.EqualTo('\u4f60'));
        // 对于某些语言或某些符号，需要两个 char 实例来表示一个 character
        Assert.That("𐓏".Length, Is.EqualTo(2));
        Assert.That("𐓏", Is.EqualTo("\ud801\udccf"));
        Assert.That("🐂".Length, Is.EqualTo(2));
        Assert.That("🐂", Is.EqualTo("\ud83d\udc02"));
    }

    /// <summary>
    /// <a href="https://learn.microsoft.com/zh-cn/dotnet/standard/base-types/character-encoding-introduction#unicode-code-points">Unicode Code Points</a>
    /// 一种国际编码标准，可用于各种平台、各种语言和脚本。
    /// 码位是一个整数值，范围从 0 ~ U+10FFFF（十进制 1114111）。
    /// </summary>
    class UniCodeCodePoints;

    /// <summary>
    /// <a href="https://learn.microsoft.com/zh-cn/dotnet/standard/base-types/character-encoding-introduction#utf-16-code-units">UTF-16 Code Units</a>
    /// UTF-16：16-bit Unicode 转换格式，一种使用 16-bit code units 来表示 Unicode Code Points 的字符编码系统。
    /// .NET 使用 UTF-16 将文本编码位字符串。
    /// char 实例表示 16-bit code unit。
    /// </summary>
    class Utf16CodeUnits;

    /// <summary>
    /// <a href="https://learn.microsoft.com/zh-cn/dotnet/standard/base-types/character-encoding-introduction#surrogate-pairs">代理 pairs</a>
    /// 一个称为 surrogate code points（代理码位）的特殊范围，从 U+D800 ~ U+DFFF，有助于将两个 16-bit 值转换为 21-bit 值
    /// </summary>
    class SurrogatePairs;

    /// <summary>
    /// <a href="https://learn.microsoft.com/zh-cn/dotnet/standard/base-types/character-encoding-introduction#unicode-scalar-values">Unicode 标量值</a>
    /// <see cref="SurrogatePairs">surrogate code points</see> 之外的所有 code points。
    /// 指被分配了字符串或将来可以被分配字符串的任何 code point
    /// </summary>
    /// <seealso cref="RuneTests"/>
    class UnicodeScalarValues;

    /// <summary>
    /// <a href="https://learn.microsoft.com/zh-cn/dotnet/standard/base-types/character-encoding-introduction#grapheme-clusters">字形群集</a>
    /// grapheme clusters，.NET 中使用<see cref="StringInfoTests.GetTextElementEnumerator">“文本元素”</see>术语表示相同的内容
    /// </summary>
    /// <remarks>
    /// <a href="https://learn.microsoft.com/zh-cn/dotnet/standard/base-types/character-encoding-introduction#example-splitting-string-instances">拆分 string 实例</a>
    /// </remarks>
    class GraphemeClusters
    {
        [Test]
        public void Test()
        {
            PrintTextElementCount("a");
            // Number of chars: 1
            // Number of runes: 1
            // Number of text elements: 1

            PrintTextElementCount("á");
            // Number of chars: 2
            // Number of runes: 2
            // Number of text elements: 1

            PrintTextElementCount("👩🏽‍🚒");
            // Number of chars: 7
            // Number of runes: 4
            // Number of text elements: 1
        }

        static void PrintTextElementCount(string s)
        {
            Console.WriteLine(s);
            Console.WriteLine($"Number of chars: {s.Length}");
            Console.WriteLine($"Number of runes: {s.EnumerateRunes().Count()}");

            TextElementEnumerator enumerator = StringInfo.GetTextElementEnumerator(s);

            int textElementCount = 0;
            while (enumerator.MoveNext())
            {
                textElementCount++;
            }

            Console.WriteLine($"Number of text elements: {textElementCount}");
        }
    }
}
