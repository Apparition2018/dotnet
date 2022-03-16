using System;
using NUnit.Framework;

namespace dotnet6Tests.API.System;

public class RandomTests
{
    [Test]
    public void Test()
    {
        // static Random        Shared { get; } = (Random) new Random.ThreadSafeRandom()
        // 提供一个线程安全的 Random 实例
        Console.WriteLine(Random.Shared.Next(0, 2));
    }
}