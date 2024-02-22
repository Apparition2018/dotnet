using dotnet.L.Demo;

namespace dotnetTest.Guide.LanguageReference.Keywords;

/// <summary>命名空间关键字</summary>
public class NamespaceKeywords : Demo
{
    /// <summary>
    /// <a href="https://learn.microsoft.com/zh-cn/dotnet/csharp/language-reference/keywords/using-directive#using-alias">using 指令</a>
    /// 允许使用在命名空间中定义的类型，而无需指定该类型的完全限定命名空间
    /// </summary>
    class UsingDirective
    {
        /// <summary>
        /// <a href="https://learn.microsoft.com/zh-cn/dotnet/csharp/language-reference/keywords/using-directive#using-alias">using 别名</a>
        /// 以便更易于将标识符限定为命名空间或类型
        /// </summary>
        /// <remarks>
        /// <a href="https://learn.microsoft.com/zh-cn/dotnet/csharp/language-reference/proposals/csharp-12.0/using-alias-types">Allow using alias directive to reference any kind of Type</a>
        /// </remarks>
        class UsingAlias;
    }
}
