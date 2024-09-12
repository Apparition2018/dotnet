using dotnetTest.Guide.LanguageReference.OperatorsAndExpressions;

namespace dotnetTest.Guide.Fundamentals.FunctionalTechniques;

/// <summary>
/// <a href="https://learn.microsoft.com/zh-cn/dotnet/csharp/fundamentals/functional/discards">弃元</a>
/// 一种在应用程序代码中人为取消使用的占位符变量。
/// 通过将下划线 _ 赋给一个变量作为其变量名，指示该变量为一个占位符变量
/// </summary>
/// <seealso cref="PatternMatching.DiscardPattern">弃元模式</seealso>
/// <seealso cref="Deconstructing.DeconstructingUserDefinedType">使用弃元析构</seealso>
public class Discards
{
    /// <summary>
    /// <a href="https://learn.microsoft.com/zh-cn/dotnet/csharp/fundamentals/functional/discards#a-standalone-discard">独立弃元</a>
    /// 指示要忽略的任何变量
    /// </summary>
    [Test]
    public async Task StandaloneDiscard()
    {
        Console.WriteLine("About to launch a task...");
        _ = Task.Run(() =>
        {
            var iterations = 0;
            for (int ctr = 0; ctr < int.MaxValue; ctr++)
                iterations++;
            Console.WriteLine("Completed looping operation...");
            throw new InvalidOperationException();
        });
        await Task.Delay(5000);
        Console.WriteLine("Exiting after 5 second delay");
    }
}
