using System.Globalization;
using System.Text;

namespace dotnetTest.API.System.Globalization;

/// <summary>
/// <a href="https://learn.microsoft.com/zh-cn/dotnet/api/system.globalization.stringinfo">StringInfo 类</a>
/// 提供将字符串拆分为文本元素和循环访问这些文本元素的功能
/// </summary>
public class StringInfoTests
{
    private const string S = "a\u0304\u0308bc\u0327";

    /// <summary>返回一个遍历字符串的文本元素（text elements）的枚举器</summary>
    [Test]
    public void GetTextElementEnumerator()
    {
        EnumTextElements(S);
        // output:
        // Character at index 0 is 'ā̈'
        // Character at index 3 is 'b'
        // Character at index 4 is 'ç'

        static void EnumTextElements(String s)
        {
            StringBuilder sb = new StringBuilder();

            // Use the enumerator returned from GetTextElementEnumerator method to examine each real character.
            TextElementEnumerator charEnum = StringInfo.GetTextElementEnumerator(s);
            while (charEnum.MoveNext())
            {
                sb.AppendFormat(
                    "Character at index {0} is '{1}'{2}",
                    charEnum.ElementIndex, charEnum.GetTextElement(), Environment.NewLine);
            }

            Console.WriteLine("Result of GetTextElementEnumerator:");
            Console.WriteLine(sb);
        }
    }

    /// <summary>返回指定字符串的每个 base character、high surrogate、control character</summary>
    [Test]
    public void ParseCombiningCharacters()
    {
        EnumTextElementIndexes(S);
        // output:
        // Character 0 starts at index 0
        // Character 1 starts at index 3
        // Character 2 starts at index 4

        static void EnumTextElementIndexes(String s)
        {
            StringBuilder sb = new StringBuilder();

            // Use the ParseCombiningCharacters method to get the index of each real character in the string.
            Int32[] textElemIndex = StringInfo.ParseCombiningCharacters(s);

            // Iterate through each real character showing the character and the index where it was found.
            for (Int32 i = 0; i < textElemIndex.Length; i++)
            {
                sb.AppendFormat(
                    "Character {0} starts at index {1}{2}",
                    i, textElemIndex[i], Environment.NewLine);
            }

            Console.WriteLine("Result of ParseCombiningCharacters:");
            Console.WriteLine(sb);
        }
    }
}
