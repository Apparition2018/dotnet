using System.Diagnostics.CodeAnalysis;

namespace dotnetTest.API.System.Diagnostics.CodeAnalysis;

/// <summary>
/// <a href="https://learn.microsoft.com/zh-cn/dotnet/api/system.diagnostics.codeanalysis.notnullwhenattribute">NotNullWhenAttribute</a>
/// 指定在方法返回 ReturnValue 时，即使相应的类型允许，参数也不会为 null
/// </summary>
public class NotNullWhenAttributeTests
{
    private string? GetMessage([NotNullWhen(true)] string? input)
    {
        return (input != null) ? "You entered:" + input : null;
    }

    [Test]
    public void Test()
    {
        string? message = GetMessage("Hello");
        Assert.That(message, Is.EqualTo("You entered:Hello"));
    }
}
