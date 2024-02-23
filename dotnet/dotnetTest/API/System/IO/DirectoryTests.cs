using dotnet.L.Demo;

namespace dotnetTest.API.System.IO;

/// <summary>
/// <a href="https://learn.microsoft.com/zh-cn/dotnet/api/system.io.directory">Directory</a>
/// </summary>
public class DirectoryTests : Demo
{
    [Test]
    public void Test()
    {
        // static string        GetCurrentDirectory()           获取当前文件夹路径
        Assert.That(Directory.GetCurrentDirectory(), Is.EqualTo(@"D:\Liang\git\dotnet\dotnet\dotnetTest\bin\Debug\net8.0"));

        string dirPath = Path.Combine(Desktop, "a", "b", "c");
        // static DirectoryInfo CreateDirectory(string path)    创建指定路径中的所有目录
        Directory.CreateDirectory(dirPath);
        // static bool          Exists(string path)             判断目录是否存在
        Assert.That(Directory.Exists(dirPath));
        // static void          Delete(string path, bool recursive)
        // 删除指定目录以及目录中的任何子目录和文件
        Directory.Delete(Path.Combine(Desktop, "a"), true);
    }

    [Test]
    public void Enumerate()
    {
        // static IEnumerable<string>   EnumerateDirectories(string path, string searchPattern, SearchOption searchOption)
        // 返回与指定路径中的搜索模式匹配的目录全名的可枚举集合，并选择性地搜索子目录
        IEnumerable<string> enumerateDirectories =
            Directory.EnumerateDirectories(DotnetPath, "*", SearchOption.AllDirectories);
        enumerateDirectories.ToList().ForEach(Console.WriteLine);

        DividingLine();

        //static IEnumerable<string>    EnumerateFiles(string path)
        // 返回指定路径中完整文件名的可枚举集合
        IEnumerable<string> files = Directory.EnumerateFiles(DotnetPath);
        files.ToList().ForEach(Console.WriteLine);
    }
}
