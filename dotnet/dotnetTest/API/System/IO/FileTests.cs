using System.Text;
using dotnet.L.Demo;

namespace dotnetTest.API.System.IO;

/// <summary>
/// <a href="https://learn.microsoft.com/zh-cn/dotnet/api/system.io.file">File</a>
/// </summary>
public class FileTests : Demo
{
    /// <summary>写入</summary>
    [Test]
    public void Write()
    {
        // static void          WriteAllText(string path, string contents, Encoding encoding)
        // 创建一个新文件，使用指定的编码将指定的字符串写入文件，然后关闭该文件。如果目标文件已存在，则将其覆盖
        File.WriteAllText(DemoFilePath, "demo", Encoding.UTF8);
        // static void          WriteAllLines(string path, string[] contents, Encoding encoding)
        // 创建一个新文件，使用指定的编码将指定的字符串数组写入该文件，然后关闭该文件
        File.WriteAllLines(DemoFilePath, ["静夜思", "床前明月光，"], Encoding.UTF8);

        // static void          AppendAllText(string path, string? contents, Encoding encoding)
        // 使用指定的编码将指定的字符串追加到文件中，如果文件尚不存在，则创建该文件
        File.AppendAllText(DemoFilePath, "疑是地上霜。\n", Encoding.UTF8);
        // static void          AppendAllLines(string path, IEnumerable<string> contents, Encoding encoding)
        // 使用指定的编码将行追加到文件中，然后关闭该文件。如果指定的文件不存在，此方法将创建一个文件，将指定的行写入该文件，然后关闭该文件
        File.AppendAllLines(DemoFilePath, ["举头望明月，", "低头思故乡。"], Encoding.UTF8);
    }

    /// <summary>读取</summary>
    [Test]
    public void Read()
    {
        Console.WriteLine(File.ReadAllText(DemoFilePath));
        File.ReadAllLines(DemoFilePath).ToList().ForEach(Console.WriteLine);
    }

    [Test]
    public void Test()
    {
        // 如果存在则删除
        if (File.Exists(DesktopDemoFilePath)) File.Delete(DesktopDemoFilePath);
        // 复制
        File.Copy(DemoFilePath, DesktopDemoFilePath);
        // 移动
        File.Move(DesktopDemoFilePath, DesktopDemoFilePath);
        // 删除
        File.Delete(DesktopDemoFilePath);
    }
}
