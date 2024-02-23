namespace dotnetTest.Guide.ProgrammingGuide;

/// <summary>
/// <a href="https://learn.microsoft.com/zh-cn/dotnet/csharp/programming-guide/delegates/">委托</a><br/>
/// <a href="https://learn.microsoft.com/zh-cn/dotnet/csharp/delegates-overview">委托</a>
/// </summary>
public class Delegates
{
    private delegate void Action();

    [Test]
    public void Test()
    {
        var dog = new Dog("A");
        var cat = new Cat("B");
        Action action = dog.WagTail;
        action += cat.CatchMice;
        action += () => { Console.WriteLine("do nothing"); };
        action();
    }
}
