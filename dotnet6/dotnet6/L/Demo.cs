namespace dotnet6.L;

public class Demo
{
    protected static int[] Ints = {1, 2, 3, 4, 5, 6, 7, 8, 9};
    protected const string HelloWorld = "Hello World!";
    protected const string DividingLine = "--------------------";

    protected static readonly string DotNet6Path =
        Path.Combine("D:", "Liang", "git", "dotnet", "dotnet6", "dotnet6");

    protected static readonly string StartUpPath = Path.Combine(DotNet6Path, "Startup.cs");
    protected static readonly string MyDirPath = Path.Combine(DotNet6Path, "L");
    protected static readonly string DemoPath = Path.Combine(MyDirPath, "demo");

    protected static readonly List<Person> PersonList = new(3)
    {
        // 对象初始值设定项
        // https://docs.microsoft.com/zh-cn/dotnet/csharp/programming-guide/classes-and-structs/object-and-collection-initializers#object-initializers
        new Person {Id = 1, Name = "张三"}, new Person {Id = 2, Name = "李四"}, new Person {Id = 3, Name = "王五"}
    };
}