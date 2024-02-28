namespace dotnetTest.Guide.LanguageReference.Statements;

/// <summary>
/// <a href="https://learn.microsoft.com/zh-cn/dotnet/csharp/language-reference/statements/fixed">fixed 语句</a>
/// 防止垃圾回收器重新定位可移动变量，并声明指向该变量的指针
/// <para>
/// 可以按如下方式初始化声明的指针：
/// <list type="bullet">
/// <item>数组</item>
/// <item>带有变量的地址</item>
/// <item>实现名为 GetPinnableReference 的方法的类型的实例</item>
/// <item>字符串</item>
/// <item><see cref="UnsafeCodeAndPointers.FixedSizeBuffers">固定大小的缓冲区</see></item>
/// </list>
/// </para>
/// </summary>
public class FixedStatement;
