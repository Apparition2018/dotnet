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
        Array.Reverse(Ints);
        Assert.That(string.Join(" ", Ints), Is.EqualTo("9 8 7 6 5 4 3 2 1"));
        Array.Reverse(Ints);

        // static void      Clear(Array array, int index, int length)
        Array.Clear(Ints, 0, 2);
        Assert.That(string.Join(" ", Ints), Is.EqualTo("0 0 3 4 5 6 7 8 9"));

        // static void      Resize<T>([NotNull] ref T[]? array, int newSize)
        Array.Resize(ref Ints, 11);
        Assert.That(string.Join(" ", Ints), Is.EqualTo("0 0 3 4 5 6 7 8 9 0 0"));
    }
}
