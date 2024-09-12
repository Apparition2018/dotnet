using dotnet.L.Demo;
using dotnetTest.Guide.LanguageReference.Types;

namespace dotnetTest.Guide.Fundamentals.FunctionalTechniques;

/// <summary>
/// <a href="https://learn.microsoft.com/zh-cn/dotnet/csharp/fundamentals/functional/deconstruct">析构元组和其他类型</a>
/// </summary>
/// <seealso cref="ValueTypes.TupleTypes">元组类型</seealso>
public class Deconstructing : Demo
{
    /// <summary>
    /// <a href="https://learn.microsoft.com/zh-cn/dotnet/csharp/fundamentals/functional/deconstruct#user-defined-types">析构用户定义类</a><br/>
    /// <a href="https://learn.microsoft.com/zh-cn/dotnet/csharp/fundamentals/functional/deconstruct#user-defined-type-with-discards">使用弃元的用户定义类型</a>
    /// <list type="bullet">
    /// <item>除了 record 和 DictionaryEntry 类型，C# 不提供析构非元组类型的内置支持</item>
    /// <item>可通过实现一个或多个 Deconstruct 方法来析构自定义类型的实例</item>
    /// <item>Deconstruct 方法返回 void，且要析构的每个值由方法签名中的 out 参数指示</item>
    /// </list>
    /// </summary>
    [Test]
    public void DeconstructingUserDefinedType()
    {
        (_, string name, int? age) = Persons[0];
        Console.WriteLine($"{name} is {age} years old!");
    }
}
