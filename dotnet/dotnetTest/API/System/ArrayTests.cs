using dotnet.L.Demo;

namespace dotnetTest.API.System;

/// <summary>
/// <a href="https://learn.microsoft.com/zh-cn/dotnet/api/system.array">Array</a>
/// </summary>
public class ArrayTests : Demo
{
    [Test]
    public void Test()
    {
        // 反转
        Array.Reverse(Ints);
        Assert.That(string.Join(" ", Ints), Is.EqualTo("9 8 7 6 5 4 3 2 1"));

        // 排序
        Array.Sort(Ints);
        Assert.That(string.Join(" ", Ints), Is.EqualTo("1 2 3 4 5 6 7 8 9"));

        // 清除（设置为默认值）
        Array.Clear(Ints, 0, 2);
        Assert.That(string.Join(" ", Ints), Is.EqualTo("0 0 3 4 5 6 7 8 9"));

        // 重设数组大小
        Array.Resize(ref Ints, 11);
        Assert.That(string.Join(" ", Ints), Is.EqualTo("0 0 3 4 5 6 7 8 9 0 0"));
    }
}
