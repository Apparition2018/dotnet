using System.Text.Json;
using System.Text.Json.Serialization;

namespace dotnet.L.Demo;

/// <summary>样例</summary>
public class Demo
{
    protected static int[] Ints = [1, 2, 3, 4, 5, 6, 7, 8, 9];
    protected const string HelloWorld = "Hello World!";
    protected static readonly string Desktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

    protected const string Dotnet = "dotnet";
    protected static readonly string GitPath = Path.Combine("D:", "Liang", "git");
    protected static readonly string DotnetPath = Path.Combine(GitPath, Dotnet, Dotnet, Dotnet);

    protected const string DemoDirName = "demo";
    protected const string DemoFileName = "demo";
    private static readonly string ResourcesPath = Path.Combine(DotnetPath, "Resources");
    protected static readonly string DemoDirPath = Path.Combine(ResourcesPath, DemoDirName);
    protected static readonly string DemoFilePath = Path.Combine(DemoDirPath, DemoFileName);
    protected static readonly string DesktopDemoFilePath = Path.Combine(Desktop, DemoFileName);

    protected static readonly List<Person> PersonList =
        [new Person { Id = 1, Name = "张三" }, new Person { Id = 2, Name = "李四" }, new Person { Id = 3, Name = "王五" }];

    protected static readonly JsonSerializerOptions SerializerOptions = new()
    {
        DefaultIgnoreCondition =
            // 如果属性的值为 null，则忽略该属性
            JsonIgnoreCondition.WhenWritingNull
    };

    /// <summary>分割线</summary>
    protected static void DividingLine()
    {
        Console.WriteLine("--------------------");
    }
}
