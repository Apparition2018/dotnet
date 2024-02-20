namespace dotnetTest.Guide.ProgrammingGuide.ClassesStructsRecords;

/// <summary>
/// <a href="https://learn.microsoft.com/zh-cn/dotnet/csharp/programming-guide/classes-and-structs/constructors">构造函数</a>
/// </summary>
public class Constructors
{
    /// <summary>
    /// <a href="https://learn.microsoft.com/zh-cn/dotnet/csharp/programming-guide/classes-and-structs/how-to-write-a-copy-constructor">复制构造函数</a>
    /// 编译器会自动给 record 生成一个复制构造函数</summary>
    class CopyConstructor
    {
        sealed class Person
        {
            // copy constructor
            public Person(Person previousPerson) : this(previousPerson.Name, previousPerson.Age)
            {
            }

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
