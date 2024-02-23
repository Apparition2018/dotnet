using dotnetTest.Guide.LanguageReference.OperatorsAndExpressions;

namespace dotnetTest.Guide.LanguageReference.Types;

/// <summary>
/// <a href="https://learn.microsoft.com/zh-cn/dotnet/csharp/language-reference/keywords/reference-types">引用类型</a>
/// <para>
/// 用于声明引用类型的关键字：class, interface, delegate, record<br/>
/// </para>
/// </summary>
public class ReferenceTypes
{
    /// <summary>
    /// <a href="https://learn.microsoft.com/zh-cn/dotnet/csharp/language-reference/builtin-types/reference-types">内置引用类型</a>
    /// dynamic, object, <see cref="String">string</see>
    /// </summary>
    class BuiltInReferenceTypes
    {
        /// <summary>
        /// <a href="https://learn.microsoft.com/zh-cn/dotnet/csharp/language-reference/builtin-types/reference-types#the-string-type">字符串类型</a>
        /// </summary>
        /// <seealso cref="MemberAccessOperatorsAndExpressions.RangeOperator">[] 运算符访问字符</seealso>
        class String
        {
            [Test]
            public void Test()
            {
                string a = "hello";
                string b = "h";
                b += "ello";
                // 相等运算符，比较 string 对象的值，而不是引用的值
                // java a == b 为 false
                Assert.That(a == b, Is.EqualTo(true));
                Assert.That(a.Equals(b), Is.EqualTo(true));
                Assert.That(ReferenceEquals(a, b), Is.EqualTo(false));
            }
        }
    }
}
