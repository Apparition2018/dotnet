namespace dotnetTest.Guide.ProgrammingGuide.ClassesStructsRecords;

/// <summary>
/// <a href="https://learn.microsoft.com/zh-cn/dotnet/csharp/programming-guide/classes-and-structs/partial-classes-and-methods">分部类和方法par</a>
/// 可以将类、结构、接口或方法的定义拆分为两个或多个源文件，在编译应用程序时会组合所有部分
/// <para>
/// <a href="https://learn.microsoft.com/zh-cn/dotnet/csharp/programming-guide/classes-and-structs/partial-classes-and-methods#restrictions">分部类限制</a>：
/// <list type="bullet">
/// <item>partial 修饰符只能出现在 class、struct 或 interface 前面</item>
/// <item>分部定义不能跨越多个模块：各个部分的所有分部类型定义都必须在同一程序集和同一模块（.exe 或 .dll 文件）中进行定义</item>
/// <item>……</item>
/// </list>
/// </para>
/// </summary>
public class PartialClassesAndMethods
{
    partial class Coords
    {
        private int x;
        private int y;

        public Coords(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
    }

    partial class Coords
    {
        public void PrintCoords()
        {
            Console.WriteLine("Coords: {0},{1}", x, y);
        }
    }

    [Test]
    public void Test()
    {
        Coords myCoords = new Coords(10, 15);
        myCoords.PrintCoords();
    }
}
