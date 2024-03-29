namespace dotnetTest.API.System;

/// <summary>
/// <a href="https://learn.microsoft.com/zh-cn/dotnet/api/system.random">Random</a>
/// </summary>
public class RandomTests
{
    [Test]
    public void Test()
    {
        // static Random        Shared { get; } = (Random) new Random.ThreadSafeRandom()
        // 提供一个线程安全的 Random 实例
        // virtual int          Next(int minValue, int maxValue)
        // 返回指定范围内的随机整数
        Console.WriteLine(Random.Shared.Next(0, 2));
    }
}
