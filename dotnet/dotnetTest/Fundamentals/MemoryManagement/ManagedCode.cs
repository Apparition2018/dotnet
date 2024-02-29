using System.Runtime.InteropServices;
using dotnetTest.Guide.LanguageReference.Keywords;

namespace dotnetTest.Fundamentals.MemoryManagement;

/// <summary>
/// <a href="https://learn.microsoft.com/zh-cn/dotnet/standard/managed-code">托管代码</a>
/// 由公共语言运行时（Common Language Runtime，CLR）管理执行的代码（如 C#、VB.NET 等）
/// <list type="bullet">
/// <item>编译器将托管代码编译为中间语言（Intermediate Language，IL）代码</item>
/// <item>CLR 启动实时编译（Just-In-Time，JIT）将 IL 代码编译为 CPU 可运行的机器代码，并执行</item>
/// </list>
/// </summary>
public class ManagedCode
{
    /// <summary>
    /// <a href="https://learn.microsoft.com/zh-cn/dotnet/standard/managed-code#unmanaged-code-interoperability">互操作性</a>
    /// CLR 允许越过托管与非托管环境之间的边界，简称 interop。
    /// 允许您封装非托管库并调用它。
    /// </summary>
    /// <remarks>
    /// <see cref="Modifiers.Unsafe">不安全上下文</see>（执行一段不由 CLR 管理的代码）：在代码中直接使用非托管构造，如：指针
    /// </remarks>
    class Interoperability
    {
        [DllImport("avifil32.dll")]
        private static extern void AVIFileInit();
    }
}
