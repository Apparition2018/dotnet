using dotnet.L.Demo;
using dotnetTest.Fundamentals.MemoryManagement;

namespace dotnetTest.Guide.ProgrammingGuide.ClassesStructsRecords;

/// <summary>
/// <a href="https://learn.microsoft.com/zh-cn/dotnet/csharp/programming-guide/classes-and-structs/constructors">构造函数</a>
/// </summary>
public class Constructors
{
    /// <summary>
    /// <a href="https://learn.microsoft.com/zh-cn/dotnet/csharp/programming-guide/classes-and-structs/instance-constructors">实例构造函数</a>
    /// <list type="buller">
    /// <item>调用本类其它构造函数用 this</item>
    /// <item>调用基类构造函数用 base</item>
    /// </list>
    /// </summary>
    class InstanceConstructors
    {
        /// <summary>
        /// <a href="https://learn.microsoft.com/zh-cn/dotnet/csharp/programming-guide/classes-and-structs/instance-constructors#primary-constructors">主构造函数</a>
        /// <list type="buller">
        /// <item>将任何参数放在类型名称后面的括号中</item>
        /// <item>任何显式编写的构造函数都必须使用 this(...) 初始化表达式语法来调用主构造函数</item>
        /// </list>
        /// </summary>
        /// <seealso cref="Product"/>
        class PrimaryConstructors;
    }

    /// <summary>
    /// <a href="https://learn.microsoft.com/zh-cn/dotnet/csharp/programming-guide/classes-and-structs/how-to-write-a-copy-constructor">复制构造函数</a>
    /// </summary>
    /// <remarks>编译器会自动给 record 生成一个复制构造函数</remarks>
    class CopyConstructor
    {
        sealed class Person
        {
            // copy constructor：使用自身实作为参数
            public Person(Person previousPerson) : this(previousPerson.Name, previousPerson.Age) { }

            // instance constructor
            public Person(string name, int age)
            {
                Name = name;
                Age = age;
            }

            public int Age { get; set; }
            public string Name { get; set; }

            public string Details()
            {
                return Name + " is " + Age;
            }
        }
    }

    /// <summary>
    /// <a href="https://learn.microsoft.com/zh-cn/dotnet/csharp/programming-guide/classes-and-structs/static-constructors">静态构造函数</a>
    /// 用于初始化任何静态数据，或执行仅需执行一次的特定操作。
    /// 创建第一个实例或引用任何静态成员之前自动调用，且最多调用一次。
    /// <para>
    /// 用法：
    /// <list type="bullet">
    /// <item>当类使用日志文件时，向该文件写入条目</item>
    /// <item>当可以调用 LoadLibrary 方法时，为非<see cref="ManagedCode">托管代码</see>创建包装类时很有用</item>
    /// <item>对无法在编译时通过类型参数约束进行检查的类型参数执行运行时检查</item>
    /// </list>
    /// </para>
    /// </summary>
    class StaticConstructors;
}
