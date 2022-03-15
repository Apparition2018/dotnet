using System.IO;
using NUnit.Framework;

namespace dotnet6Tests.API.System.IO;

public class PathTests
{
    [Test]
    public void Test()
    {
        // 目录分隔符字符
        Assert.AreEqual(Path.DirectorySeparatorChar, '\\');
        // 将字符串组合成路径
        Assert.AreEqual(Path.Combine("D:", "Liang", "git"), @"D:\Liang\git");
        // 返回指定路径字符串的扩展名（包括"."）+
        Assert.AreEqual(Path.GetExtension("bird.jpg"), ".jpg");
    }
}