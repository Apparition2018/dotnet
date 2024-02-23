using System.Diagnostics.CodeAnalysis;

namespace dotnetTest.API.System.Diagnostics.CodeAnalysis;

/// <summary>
/// <a href="https://learn.microsoft.com/zh-cn/dotnet/api/system.diagnostics.codeanalysis.notnullwhenattribute?view=net-8.0">NotNullWhenAttribute</a>
/// 指定在方法返回 ReturnValue 时，即使相应的类型允许，参数也不会为 null
/// </summary>
public class NotNullWhenAttributeTests
{
    public string? GetMessage([NotNullWhenAttribute(true)] string? input)
    {
        return (input != null) ? "You entered:" + input : null;
    }

    [Test]
    public void Test()
    {
        string? input = "Hello";
        string? message = GetMessage(input);
        Assert.That(message, Is.EqualTo("You entered:Hello"));
    }
}
