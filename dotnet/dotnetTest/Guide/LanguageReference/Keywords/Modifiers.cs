using System.Runtime.InteropServices;
using dotnetTest.Fundamentals.MemoryManagement;

namespace dotnetTest.Guide.LanguageReference.Keywords;

/// <summary>修饰符</summary>
public class Modifiers
{
    /// <summary>
    /// <a href="https://learn.microsoft.com/zh-cn/dotnet/csharp/language-reference/keywords/extern">extern</a>
    /// 用于声明在外部实现的方法。
    /// 常见用法：使用<see cref="ManagedCode.Interoperability">互操作</see>服务调用<see cref="ManagedCode">非托管代码</see>
    /// </summary>
    [Test]
    public void Extern()
    {
        Console.WriteLine(MessageBox(0, "abc", "My Message Box", 0));
        return;

        [DllImport("User32.dll", CharSet = CharSet.Unicode)]
        static extern int MessageBox(IntPtr h, string m, string c, int type);
    }

    /// <summary>
    /// <a href="https://learn.microsoft.com/zh-cn/dotnet/csharp/language-reference/keywords/override">override</a>
    /// 扩展或修改抽象或虚拟的方法、属性、索引器、事件
    /// <para>
    /// override 方法：
    /// <list type="bullet">
    /// <item>override 方法必须具有与重写基方法相同的签名</item>
    /// <item>override 方法支持协变返回类型。返回类型可从相应基方法的返回类型派生</item>
    /// <item>不能重写非虚方法或静态方法。重写基方法必须是 virtual、abstract 或 override</item>
    /// <item>override 方法和 virtual 方法必须具有相同级别访问修饰符</item>
    /// </list>
    /// </para>
    /// <para>
    /// 重写属性：
    /// <list type="bullet">
    /// <item>重写属性声明必须指定与继承的属性完全相同的访问修饰符、类型和名称</item>
    /// <item>只读重写属性支持协变返回类型</item>
    /// <item>重写属性必须为 virtual、abstract 或 override</item>
    /// </list>
    /// </para>
    /// </summary>
    /// <remarks>
    /// <a href="https://learn.microsoft.com/zh-cn/dotnet/csharp/programming-guide/classes-and-structs/knowing-when-to-use-override-and-new-keywords">了解何时使用 Override 和 New 关键字</a>
    /// </remarks>
    class Override;

    /// <summary>
    /// <a href="https://learn.microsoft.com/zh-cn/dotnet/csharp/language-reference/keywords/sealed">sealed</a>
    /// 修饰类时，阻止其他类继承自该类。
    /// 修饰（基类中 virtual 修饰的）方法和属性时，必须与 overrider 结合使用，防止派生类重写该方法。
    /// </summary>
    class Sealed;

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
        static unsafe void FastCopy(byte* ps, byte* pd, int count) { }

        [Test]
        public void UnsafeBlock()
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

    /// <summary>
    /// <a href="https://learn.microsoft.com/zh-cn/dotnet/csharp/language-reference/keywords/virtual">virtual</a>
    /// 用于修改方法、属性、索引器或事件声明，并使它们可以在派生类中被重写。
    /// 不能与 static、abstract private 或 override 修饰符一起使用。
    /// </summary>
    /// <remarks>
    /// <a href="https://learn.microsoft.com/zh-cn/dotnet/csharp/programming-guide/classes-and-structs/knowing-when-to-use-override-and-new-keywords">了解何时使用 Override 和 New 关键字</a>
    /// </remarks>
    class Virtual
    {
        class Shape
        {
            protected double _x, _y;

            public Shape() { }

            public Shape(double x, double y)
            {
                _x = x;
                _y = y;
            }

            public virtual double Area()
            {
                return _x * _y;
            }
        }

        /// <summary>球体</summary>
        class Sphere : Shape
        {
            public Sphere(double r) : base(r, 0) { }

            public override double Area()
            {
                return 4 * Math.PI * _x * _x;
            }
        }

        /// <summary>圆柱</summary>
        class Cylinder : Shape
        {
            public Cylinder(double r, double h) : base(r, h) { }

            public override double Area()
            {
                return 2 * Math.PI * _x * _x + 2 * Math.PI * _x * _y;
            }
        }

        [Test]
        public void Test()
        {
            double r = 3.0, h = 5.0;
            Assert.That(new Sphere(r).Area().ToString("F2"), Is.EqualTo("113.10"));
            Assert.That(new Cylinder(r, h).Area().ToString("F2"), Is.EqualTo("150.80"));
        }
    }
}
