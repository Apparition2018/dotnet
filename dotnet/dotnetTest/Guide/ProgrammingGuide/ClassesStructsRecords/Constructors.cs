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
}
