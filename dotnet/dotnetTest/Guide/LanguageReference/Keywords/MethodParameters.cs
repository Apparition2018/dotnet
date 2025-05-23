using dotnet.L.Demo;

namespace dotnetTest.Guide.LanguageReference.Keywords;

/// <summary>
/// <a href="https://learn.microsoft.com/zh-cn/dotnet/csharp/language-reference/keywords/method-parameters">方法参数</a>
/// C# 中的参数默认按值传递给函数，参数修饰符可改按引用传递给参数
/// </summary>
public class MethodParameters
{
    /// <summary>
    /// <a href="https://learn.microsoft.com/zh-cn/dotnet/csharp/language-reference/keywords/method-parameters#reference-parameters">引用参数</a>
    /// <para>
    /// 将以下修饰符之一应用于参数声明，以按引用而不是按值传递参数：
    /// <list type="number">
    /// <item>ref：在调用方法之前必须初始化参数。该方法可以将新值赋给参数。</item>
    /// <item>readonly ref：在调用方法之前必须初始化参数。该方法无法向参数赋新值。</item>
    /// <item>out：在调用方法之前不需要初始化参数。该方法必须向参数赋值。</item>
    /// <item>in：在调用方法之前必须初始化参数。该方法无法向参数赋新值。编译器可能会创建一个临时变量来保存 in 参数的自变量副本。</item>
    /// </list>
    /// </para>
    /// </summary>
    [Test]
    public void ReferenceParameters()
    {
    }

    /// <summary>按值传递值类型</summary>
    private static void ValChangeByVal(int i)
    {
        i = 2;
    }

    /// <summary>按引用传递值类型时</summary>
    private static void ValChangeByRef(ref int i)
    {
        i = 2;
    }

    /// <summary>按值传递引用类型</summary>
    private static void RefChangeByVal(Product product)
    {
        product = new Product(2, "toy2");
    }

    /// <summary>按引用传递引用类型</summary>
    private static void RefChangeByRef(ref Product product)
    {
        product = new Product(2, "toy2");
    }

    [Test]
    public void PassValue()
    {
        var i = 1;
        ValChangeByVal(i);
        Assert.That(i, Is.EqualTo(1));
        ValChangeByRef(ref i);
        Assert.That(i, Is.EqualTo(2));

        var product = new Product(1, "toy1");
        RefChangeByVal(product);
        Assert.That(product.Id, Is.EqualTo(1));
        RefChangeByRef(ref product);
        Assert.That(product.Id, Is.EqualTo(2));
    }

    /// <summary>
    /// <a href="https://learn.microsoft.com/zh-cn/dotnet/csharp/language-reference/keywords/method-parameters#params-modifier">params 修饰符</a>
    /// <list type="bullet">
    /// <item>params 关键字修饰的参数称为 params 参数</item>
    /// <item>params 参数之后不允许有其他参数</item>
    /// <item>只允许有一个 params 参数</item>
    /// <item>params 参数的声明类型只能是一维数组，否者发生编译器错误 CS0225</item>
    /// <item>params 参数可以传入：①逗号分隔列表 ②数组 ③无参数</item>
    /// </list>
    /// </summary>
    [Test]
    public void Params()
    {
        UseParams(1, 2, 3);
    }

    private static void UseParams(params int[] list)
    {
    }
}
