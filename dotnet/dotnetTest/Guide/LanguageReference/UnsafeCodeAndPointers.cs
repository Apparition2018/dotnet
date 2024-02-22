using dotnetTest.Guide.LanguageReference.OperatorsAndExpressions;
using dotnetTest.Guide.LanguageReference.Statements;

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
    /// 可对指针执行的运算符：<see cref="PointerRelatedOperators"/>
    /// <para>
    /// 可对指针执行的语句：
    /// <list type="bullet">
    /// <item>stackalloc：在堆栈上分配内存</item>
    /// <item><see cref="FixedStatement"/>：临时固定变量以便找到其地址</item>
    /// </list>
    /// </para>
    /// </summary>
    /// <remarks>
    /// <a href="https://learn.microsoft.com/zh-cn/dotnet/csharp/language-reference/unsafe-code#how-to-use-pointers-to-copy-an-array-of-bytes">使用指针来复制字节数组</a>
    /// <a href="https://learn.microsoft.com/zh-cn/dotnet/csharp/language-reference/unsafe-code#function-pointers">函数指针</a>
    /// </remarks>
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
            for (int i = 0; i < sizeof(int); ++i)
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

    /// <summary>
    /// <a href="https://learn.microsoft.com/zh-cn/dotnet/csharp/language-reference/unsafe-code#fixed-size-buffers">固定大小的缓冲区</a>
    /// 主要用于处理与硬件交互或者对性能要求非常高的场景，尤其是在需要直接操作内存和避免垃圾收集影响的场合。
    /// 固定大小的缓冲区允许开发者直接控制内存分配，避免动态内存分配和释放的开销，从而提高代码的性能。
    /// <para>
    /// 与常规数组的区别：
    /// <list type="bullet">
    /// <item>只能在 unsafe 上下文中使用</item>
    /// <item>只能是 structs 的实例字段</item>
    /// <item>只能是 vectors 或 一维数组</item>
    /// <item>声明应包括长度，如 fixed char id[8]</item>
    /// </list>
    /// </para>
    /// </summary>
    class FixedSizeBuffers;
}
