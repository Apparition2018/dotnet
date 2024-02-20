using dotnet.L.Demo;

namespace dotnetTest.API.System.LINQ;

/// <summary>
/// <a href="https://learn.microsoft.com/zh-cn/dotnet/api/system.linq.enumerable">Enumerable</a>
/// </summary>
public class EnumerableTests : Demo
{
    [Test]
    public void Test()
    {
        // static IEnumerable<int>          Range(int start, int count)
        // 生成指定范围内的整数序列
        // static IEnumerable<TSource>      Where<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate)
        // 根据 predicate 过滤值
        // static List<TSource>             ToList<TSource>(this IEnumerable<TSource> source)
        // 从 IEnumerable 创建 List
        Enumerable.Range(1, 10).Where(e => e > 5).ToList().ForEach(Console.WriteLine);

        // static TSource                   First<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate)
        // 返回序列中满足指定条件的第一个元素
        Assert.That(PersonList.First(x => x.Id == 1).Name, Is.EqualTo("张三"));
    }
}
