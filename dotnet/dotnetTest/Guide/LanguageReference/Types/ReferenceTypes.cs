using dotnet.L.Demo;
using dotnetTest.Guide.LanguageReference.OperatorsAndExpressions;
using dotnetTest.Guide.ProgrammingGuide;

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
    /// <list type="number">
    /// <item>object</item>
    /// <item><see cref="StringType">string</see></item>
    /// <item><see cref="DelegateType">delegate</see></item>
    /// <item><see cref="DynamicType">dynamic</see></item>
    /// </list>
    /// </summary>
    class BuiltInReferenceTypes
    {
        /// <summary>
        /// <a href="https://learn.microsoft.com/zh-cn/dotnet/csharp/language-reference/builtin-types/reference-types#the-string-type">字符串类型</a>
        /// </summary>
        /// <seealso cref="MemberAccessOperatorsAndExpressions.RangeOperator">[] 运算符访问字符</seealso>
        /// <remarks>
        /// <a href="https://learn.microsoft.com/zh-cn/dotnet/csharp/language-reference/builtin-types/reference-types#utf-8-string-literals">UTF-8 字符串字面量</a>
        /// </remarks>
        class StringType
        {
            /// <summary>相等</summary>
            [Test]
            public void Equality()
            {
                string a = "hello";
                string b = "h";
                b += "ello";
                // 相等运算符，比较 string 对象的值，而不是引用的值
                // java a == b 为 false
                Assert.That(a == b, Is.EqualTo(true));
                Assert.That(a.Equals(b), Is.EqualTo(true));
                Assert.That(ReferenceEquals(a, b), Is.EqualTo(false));

                string s = """
                           123
                                    345
                           """;
            }

            /// <summary>
            /// <a href="https://learn.microsoft.com/zh-cn/dotnet/csharp/language-reference/builtin-types/reference-types#string-literals">字符串字面量</a>
            /// <list type="number">
            /// <item>原始 row：至少三个双引号 (""") 括起来，可以包含任意文本，而无需转义序列 ???</item>
            /// <item>引号 quoted</item>
            /// <item><see cref="SpecialCharacters.VerbatimStringLiteral">逐字 verbatim</see>：以 @ 开头，不处理转义序列</item>
            /// </list>
            /// </summary>
            [Test]
            public void StringLiterals()
            {
                var row = """"
                          """
                          This is a very important message.
                          """
                          """";
                Console.WriteLine(row);

                var verbatim = @"C:\Docs\Source\a.txt";
                Console.WriteLine(verbatim);
            }
        }

        /// <summary>
        /// <a href="https://learn.microsoft.com/zh-cn/dotnet/csharp/language-reference/builtin-types/reference-types#the-delegate-type">委托类型</a>
        /// <list type="bullet">
        /// <item>委托类型的声明与方法签名相似。它有一个返回值和任意数目任意类型的参数</item>
        /// <item>System.Action 和 System.Func 类型为许多常见委托提供泛型定义</item>
        /// <item>一种可用于封装命名方法或匿名方法的引用类型。类似 C++ 的函数指针，但是委托是类型安全和可靠的</item>
        /// </list>
        /// </summary>
        /// <seealso cref="Delegates"/>
        class DelegateType;

        /// <summary>
        /// <a href="https://learn.microsoft.com/zh-cn/dotnet/csharp/language-reference/builtin-types/reference-types#the-dynamic-type">动态类型</a>
        /// <list type="bullet">
        /// <item>表示变量的使用和对其成员的引用绕过编译时类型检查，改在运行时解析这些操作（运行时 dynamic → object）</item>
        /// <item>简化了对 COM API（例如 Office Automation API）、动态 API（例如 IronPython 库）和 HTML 文档对象模型 (DOM) 的访问</item>
        /// </list>
        /// </summary>
        class DynamicType
        {
            [Test]
            public void Test()
            {
                dynamic dyn = 1;
                object obj = 1;
                dyn = dyn + 3;
                // obj = obj + 3; // Cannot apply operator '+' to operands of type 'object' and 'int'
                Console.WriteLine(dyn.GetType());
                Console.WriteLine(obj.GetType());
            }
        }
    }

    /// <summary>
    /// <a href="https://learn.microsoft.com/zh-cn/dotnet/csharp/language-reference/builtin-types/record">记录</a>
    /// 定义一个引用类型，用来提供用于封装数据的内置功能
    /// </summary>
    /// <seealso cref="Product"/>
    class Records;
}
