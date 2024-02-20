using dotnet.L.Demo;

namespace dotnetTest.API.System.IO;

/// <summary>
/// <a href="https://learn.microsoft.com/zh-cn/dotnet/api/system.io.path">Path</a>
/// </summary>
public class PathTests : Demo
{
    [Test]
    public void Test()
    {
        // 目录分隔符字符
        Assert.That(Path.DirectorySeparatorChar, Is.EqualTo('\\'));
        // 将字符串组合成路径
        Assert.That(Path.Combine("D:", "Liang", "git"), Is.EqualTo(GitPath));
        // 返回指定路径字符串的扩展名（包括"."）+
        Assert.That(Path.GetExtension(DemoFilePath), Is.EqualTo(string.Empty));
        // 返回随机文件名称
        Console.WriteLine(Path.GetRandomFileName());
    }
}
