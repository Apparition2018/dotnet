namespace dotnetTest.Guide.ProgrammingGuide;

/// <summary>
/// <a href="https://learn.microsoft.com/zh-cn/dotnet/csharp/programming-guide/events/">事件</a><br/>
/// <a href="https://learn.microsoft.com/zh-cn/dotnet/csharp/events-overview">事件简介</a><br/>
/// 委托是事件的基础
/// </summary>
/// <seealso cref="Delegates"/>
public class Events
{
    [Test]
    public void Test()
    {
        var c1 = new Client();
        var c2 = new Client();
        Dog.NewDog += c1.WantDog;
        Dog.NewDog += c2.WantDog;

        var dog = new Dog("Q");
    }
}
