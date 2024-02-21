using dotnetTest.Guide.LanguageReference.OperatorsAndExpressions;

namespace dotnetTest.Guide.LanguageReference;

/// <summary>
/// <a href="https://learn.microsoft.com/zh-cn/dotnet/csharp/language-reference/unsafe-code">不安全代码、指针类型和函数指针</a>
/// 不安全代码具有以下属性：
/// <list type="number">
/// <item>可将方法、类型和代码块定义为不安全</item>
/// <item>在某些情况下，通过移除数组绑定检查，不安全代码可提高应用程序的性能</item>
/// <item>调用需要指针的本机函数时，需使用不安全代码</item>
/// <item>使用不安全代码将引发安全风险和稳定性风险</item>
/// <item>必须使用 AllowUnsafeBlocks 编译器选项来编译包含不安全快的代码</item>
/// </list>
/// </summary>
public class UnsafeCodeAndPointers
{
    /// <summary>
    /// <a href="https://learn.microsoft.com/zh-cn/dotnet/csharp/language-reference/unsafe-code#pointer-types">指针类型</a>
    /// <list type="bullet">
    /// <item>指针类型不继承自 object，且与 object 之间不存在转换</item>
    /// <item>不同的指针类型之间、指针类型和整型之间 可以进行转换</item>
    /// <item>装箱和取消装箱不支持指针</item>
    /// </list>
    /// </summary>
    /// <seealso cref="PointerRelatedOperators"/>
    [Test]
    public void PointerTypes()
    {
        int number = 1024;

        unsafe
        {
            // Convert to byte:
            byte* p = (byte*)&number;

            Console.Write("The 4 bytes of the integer:");

            // Display the 4 bytes of the int variable:
            for (int i = 0 ; i < sizeof(int) ; ++i)
            {
                Console.Write(" {0:X2}", *p);
                // Increment the pointer:
                p++;
            }
            Console.WriteLine();
            Console.WriteLine("The value of the integer: {0}", number);

            /* Output:
                The 4 bytes of the integer: 00 04 00 00
                The value of the integer: 1024
            */
        }
    }
}
