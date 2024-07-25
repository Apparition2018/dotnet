using dotnet.L.Demo;

namespace dotnetTest.Guide.Fundamentals.TypeSystem;

/// <summary>
/// <a href="https://learn.microsoft.com/zh-cn/dotnet/csharp/fundamentals/types/anonymous-types">匿名类型</a>
/// </summary>
public class AnonymousTypes : Demo
{
    /// <summary>匿名类型通常用在查询表达式的 select 子句中</summary>
    [Test]
    public void LinQ()
    {
        var personQuery =
            from person in Persons
            select new { Id = person.ID, person.Name };

        personQuery.ToList().ForEach(Console.WriteLine);
    }
}
