using dotnet.L.Demo;
using dotnetTest.Guide.LanguageReference.Keywords;

namespace dotnetTest.Guide.ProgrammingGuide.ClassesStructsRecords;

/// <summary>
/// <a href="https://learn.microsoft.com/zh-cn/dotnet/csharp/programming-guide/classes-and-structs/methods">方法</a>
/// </summary>
public class Method
{
    /// <summary>
    /// <a href="https://learn.microsoft.com/zh-cn/dotnet/csharp/programming-guide/classes-and-structs/local-functions">局部函数</a>
    /// <list type="bullet">
    /// <item>一种嵌套在另一成员中的一种类型的方法：方法、构造函数、属性访问器、事件访问器、匿名方法、Lambda 表达式、终结器、其他局部函数</item>
    /// <item>语法：<c>&lt;modifiers> &lt;return-type> &lt;method-name> &lt;parameter-list></c></item>
    /// <item>modifiers：async、<see cref="Modifiers.Unsafe">unsafe</see>、static、<see cref="Modifiers.Extern">extern</see>（外部局部函数必须为 static）</item>
    /// <item><a href="https://learn.microsoft.com/zh-cn/dotnet/csharp/programming-guide/classes-and-structs/local-functions#local-functions-and-exceptions">可以使异常立即出现</a></item>
    /// </list>
    /// </summary>
    class LocalFunctions
    {
        public static int LocalFunctionFactorial(int n)
        {
            return NthFactorial(n);

            int NthFactorial(int number) => number < 2 ? 1 : number * NthFactorial(number - 1);
        }
    }

    /// <summary>
    /// <a href="https://learn.microsoft.com/zh-cn/dotnet/csharp/programming-guide/classes-and-structs/implicitly-typed-local-variables">隐式类型局部变量</a>
    /// <list type="bullet">
    /// <item>var 必须在声明时同时初始化，且不能为 null、方法组、匿名函数</item>
    /// <item>var 不能用作类范围内的字段</item>
    /// <item>var 声明不能使用初始化表达式，如：var i = (i = 20) 会产生编译时错误</item>
    /// <item>不能在同一语句中初始化多个隐式类型变量</item>
    /// </list>
    /// </summary>
    /// <remarks>
    /// <a href="https://learn.microsoft.com/zh-cn/dotnet/csharp/fundamentals/coding-style/coding-conventions#implicitly-typed-local-variables">隐式类型局部变量</a>
    /// </remarks>
    class ImplicitlyTypedLocalVariables;

    /// <summary>
    /// <a href="https://learn.microsoft.com/zh-cn/dotnet/csharp/programming-guide/classes-and-structs/extension-methods">扩展方法</a>
    /// 使你能够向现有类型“添加”方法，而无需创建新的派生类型、重新编译或以其他方式修改原始类型
    /// <para>
    /// <a href="https://learn.microsoft.com/zh-cn/dotnet/csharp/programming-guide/classes-and-structs/how-to-implement-and-call-a-custom-extension-method#to-define-and-call-the-extension-method">定义和调用扩展方法</a>：
    /// <list type="number">
    /// <item>非嵌套、非泛型静态类，对客户端代码可见</item>
    /// <item>静态方法，可见性至少与所在类的可见性相同</item>
    /// <item>第一个参数指定方法所操作的类型，参数前面必须加上 this 修饰符</item>
    /// <item>添加 using 指令，用于指定包含扩展方法类的命名空间</item>
    /// <item>添加 using 指令，用于指定包含扩展方法类的命名空间</item>
    /// <item>使用实例方法语法调用</item>
    /// </list>
    /// </para>
    /// </summary>
    [Test]
    public void ExtensionMethods()
    {
        {
            var dog = new Dog("A");
            dog.Feed();
        }
    }

    /// <summary>
    /// <a href="https://learn.microsoft.com/zh-cn/dotnet/csharp/programming-guide/classes-and-structs/named-and-optional-arguments">命名实参和可选参数</a>
    /// </summary>
    class NamedAndOptionalArguments
    {
        static void PrintOrderDetails(string productName, int orderNum = 0, string sellerName = Demo.MyName)
        {
            Console.WriteLine($"Product: {productName}, Seller: {sellerName}, Order #: {orderNum}");
        }

        /// <summary>
        /// <a href="https://learn.microsoft.com/zh-cn/dotnet/csharp/programming-guide/classes-and-structs/named-and-optional-arguments#named-arguments">命名实参</a>
        /// </summary>
        [Test]
        public void NamedArguments()
        {
            // 位置实参
            PrintOrderDetails("Red Mug", 31, "Gift Shop");

            // 命名参数：可以按任意顺序提供参数
            PrintOrderDetails(orderNum: 31, productName: "Red Mug", sellerName: "Gift Shop");

            // 位置实参+命名参数：需要正确顺序
            PrintOrderDetails(productName: "Red Mug", 31, sellerName: "Gift Shop");
        }

        /// <summary>
        /// <a href="https://learn.microsoft.com/zh-cn/dotnet/csharp/programming-guide/classes-and-structs/named-and-optional-arguments#optional-arguments">可选参数</a>
        /// 可选参数定义于参数列表的末尾和必需参数之后
        /// <para>
        /// 可选参数必须要有一个默认值，可以是以下表达式之一：
        /// <list type="number">
        /// <item>常量表达式</item>
        /// <item>new ValType() 形式的表达式，ValType 是值类型</item>
        /// <item>default(ValType) 形式的表达式，ValType 是值类型</item>
        /// </list>
        /// </para>
        /// </summary>
        [Test]
        public void OptionalArguments()
        {
            // 传递所有参数
            PrintOrderDetails("Red Mug", 31, "Gift Shop");
            // 传递部分可选参数
            PrintOrderDetails("Red Mug", 31);
            // 不传递可选参数
            PrintOrderDetails("Red Mug");
            // 要传递后面的可选参数，必须先传递排在前面的可选参数，除非使用命名参数
            PrintOrderDetails("Red Mug", sellerName: "Gift Shop");
        }
    }
}
