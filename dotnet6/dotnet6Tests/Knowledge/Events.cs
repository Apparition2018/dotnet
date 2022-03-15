using NUnit.Framework;

namespace dotnet6Tests.Knowledge;

/// <summary>事件</summary>
/// <remarks>https://docs.microsoft.com/zh-cn/dotnet/csharp/events-overview</remarks>
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