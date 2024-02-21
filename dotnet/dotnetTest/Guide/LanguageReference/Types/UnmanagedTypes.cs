using dotnet.L.Demo;

namespace dotnetTest.Guide.LanguageReference.Types;

/// <summary>
/// <a href="https://learn.microsoft.com/zh-cn/dotnet/csharp/language-reference/builtin-types/unmanaged-types">非托管类型</a>
/// <list type="number">
/// <item>sbyte、byte、short、ushort、int、unit、long、ulong、nint、nuint、char、flat、double、decimal、bool</item>
/// <item>枚举类型</item>
/// <item>指针类型</item>
/// <item>仅包含非托管类型字段的用户定义的结构类型</item>
/// </list>
/// </summary>
public class UnmanagedTypes
{
    private static unsafe void DisplaySize<T>() where T : unmanaged
    {
        Console.WriteLine($"{typeof(T)} is unmanaged and its size is {sizeof(T)} bytes");
    }

    [Test]
    public void Test()
    {
        DisplaySize<Coords>();
    }
}
