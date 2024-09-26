using System.Reflection;
using System.Text;
using dotnet.L.Demo;

namespace dotnetTest.API.System.Reflection;

/// <summary>
/// <a href="https://learn.microsoft.com/zh-cn/dotnet/api/system.reflection.assembly">Assembly</a>
/// 表示一个程序集，它是一个可重用、无版本冲突并且可自我描述的公共语言运行时应用程序构建基块
/// </summary>
public class AssemblyTests : Demo
{
    [Test]
    public void Test()
    {
        // 获取在其中声明类型的 Assembly
        Assembly assembly = typeof(AssemblyTests).Assembly;
        // 获取包含当前正在执行的代码的程序集
        assembly = Assembly.GetExecutingAssembly();
        // 加载具有指定名称的程序集
        Assembly assembly2 = Assembly.Load(Dotnet);

        Assert.That(assembly.FullName, Is.EqualTo(assembly.GetName().ToString()));
        Assert.That(assembly.GetName().Name, Is.EqualTo("dotnetTest"));
        Assert.That(assembly.Location, Is.EqualTo(@"D:\Liang\git\dotnet\dotnet\dotnetTest\bin\Debug\net8.0\dotnetTest.dll"));


        // 获取程序集实例中具有指定名称的 Type 对象
        Type type = assembly.GetType(typeof(AssemblyTests).FullName!)!;
        Assert.That(type.GetMethod("Test")!.ReturnType.Name, Is.EqualTo("Void"));

        // 返回此程序集中所有资源的名称
        assembly2.GetManifestResourceNames().ToList().ForEach(Console.WriteLine);
    }

    /// <summary>
    /// <a href="https://khalidabuhakmeh.com/how-to-use-embedded-resources-in-dotnet">Accessing Embedded Resources from C#</a>
    /// </summary>
    [Test]
    public void AccessingEmbeddedResources()
    {
        var assembly = Assembly.Load(Dotnet);
        var assemblyName = assembly.GetName();
        using var stream =
            // 从此程序集加载指定的清单资源
            assembly.GetManifestResourceStream($"{assemblyName.Name}.{ResourcesDirName}.{DemoDirName}.{DemoFileName}")!;
        using var streamReader = new StreamReader(stream, Encoding.UTF8);
        Console.WriteLine(streamReader.ReadToEnd());
    }
}
