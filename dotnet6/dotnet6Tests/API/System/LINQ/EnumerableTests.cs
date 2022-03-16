using System;
using System.Linq;
using NUnit.Framework;

namespace dotnet6Tests.API.System.LINQ;

public class EnumerableTests
{
    [Test]
    public void Test()
    {
        // static IEnumerable<int>          Range(int start, int count)
        // 生成指定范围内的整数序列
        // static IEnumerable<TSource>      Where<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate)
        // 根据 predicate 过滤值
        Enumerable.Range(1, 10).Where(e => e > 5).ToList().ForEach(Console.WriteLine);
    }
}