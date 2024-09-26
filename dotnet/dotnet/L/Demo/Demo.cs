using System.Text.Json;
using System.Text.Json.Serialization;

namespace dotnet.L.Demo;

/// <summary>样例</summary>
public class Demo
{
    protected static int[] Ints = [1, 2, 3, 4, 5, 6, 7, 8, 9];
    protected const string HelloWorld = "Hello World!";
    public const string MyName = "ljh";
    protected static readonly string Desktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

    protected const string Dotnet = "dotnet";
    protected static readonly string GitPath = Path.Combine("D:", "Liang", "git");
    protected static readonly string DotnetPath = Path.Combine(GitPath, Dotnet, Dotnet, Dotnet);
    protected const string ResourcesDirName = "Resources";
    protected const string DemoDirName = "demo";
    protected const string DemoFileName = "demo";
    private static readonly string ResourcesPath = Path.Combine(DotnetPath, ResourcesDirName);
    protected static readonly string DemoDirPath = Path.Combine(ResourcesPath, DemoDirName);
    protected static readonly string DemoDirAssemblyPath = $"{Dotnet}.{ResourcesDirName}.{DemoDirName}";
    protected static readonly string DemoFilePath = Path.Combine(DemoDirPath, DemoFileName);
    protected static readonly string DesktopDemoFilePath = Path.Combine(Desktop, DemoFileName);

    protected static readonly List<Person> Persons =
    [
        new Person { ID = 1, Name = "张三", Age = 18 },
        new Person { ID = 2, Name = "李四", Age = 20 },
        new Person { ID = 3, Name = "王五", Age = 18 }
    ];

    protected static readonly List<Student> Students =
    [
        new Student { ID = 1, FirstName = "Michael", LastName = "Johnson", Year = GradeLevel.FirstYear, DepartmentID = 1, Scores = [71, 86, 77, 97] },
        new Student { ID = 2, FirstName = "Elizabeth", LastName = "Smith", Year = GradeLevel.SecondYear, DepartmentID = 2, Scores = [75, 73, 78, 83] },
        new Student { ID = 3, FirstName = "William", LastName = "Davis", Year = GradeLevel.FirstYear, DepartmentID = 1, Scores = [84, 82, 96, 80] },
    ];

    protected static readonly List<Teacher> Teachers =
    [
        new Teacher { ID = 1, First = "Jessica", Last = "Thompson", City = "New York" },
        new Teacher { ID = 2, First = "Christopher", Last = "Brown", City = "Los Angeles" },
        new Teacher { ID = 3, First = "Michael", Last = "Johnson", City = "Chicago"}
    ];

    protected static readonly List<Department> Departments =
    [
        new Department { ID = 1, Name = "Apple", TeacherID = 1 },
        new Department { ID = 2, Name = "Banana", TeacherID = 2 },
    ];

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
