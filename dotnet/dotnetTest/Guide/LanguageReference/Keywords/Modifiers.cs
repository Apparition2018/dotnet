namespace dotnetTest.Guide.LanguageReference.Keywords;

/// <summary>修饰符</summary>
public class Modifiers
{
    /// <summary>
    /// <a href="https://learn.microsoft.com/zh-cn/dotnet/csharp/language-reference/keywords/unsafe">unsafe</a>
    /// 表示不安全上下文，该上下文是任何涉及指针的操作所必需的。
    /// 还可以使用不安全块从而能够使用该块内的不安全代码。
    /// </summary>
    class Unsafe
    {
        // 可在类型或成员的声明中使用 unsafe 修饰符
        static unsafe void FastCopy(byte[] src, byte[] dst, int count)
        {
            // Unsafe context: can use pointers here.
        }

        // 不安全上下文的范围从参数列表扩展到方法的结尾，因此也可在以下参数列表中使用指针
        static unsafe void FastCopy(byte* ps, byte* pd, int count)
        {
        }

        [Test]
        public void  UnsafeBlock()
        {
            // 不安全块
            unsafe
            {
                // Unsafe context: can use pointers here.
            }
        }

        // 将指针指向 int
        static unsafe void SquarePtrParam(int* p)
        {
            *p *= *p;
        }

        [Test]
        public unsafe void Test()
        {
            int i = 5;
            // 一元 address-of 运算符 (&)：返回其操作数的地址（即指针）
            SquarePtrParam(&i);
            Console.WriteLine(i);
        }
    }
}
