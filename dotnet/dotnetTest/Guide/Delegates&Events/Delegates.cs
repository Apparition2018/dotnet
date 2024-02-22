namespace dotnetTest.Guide.Delegates_Events;

/// <summary>
/// <a href="https://learn.microsoft.com/zh-cn/dotnet/csharp/delegates-overview">委托</a>
/// 提供后期绑定机制
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
