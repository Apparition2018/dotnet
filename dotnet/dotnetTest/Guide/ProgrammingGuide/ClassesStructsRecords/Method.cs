namespace dotnetTest.Guide.ProgrammingGuide.ClassesStructsRecords;

/// <summary>
/// <a href="https://learn.microsoft.com/zh-cn/dotnet/csharp/programming-guide/classes-and-structs/methods">方法</a>
/// </summary>
public class Method
{
    /// <summary>
    /// <a href="https://learn.microsoft.com/zh-cn/dotnet/csharp/programming-guide/classes-and-structs/extension-methods">扩展方法</a>
    /// 使你能够向现有类型“添加”方法，而无需创建新的派生类型、重新编译或以其他方式修改原始类型
    /// <para>
    /// <a href="https://learn.microsoft.com/zh-cn/dotnet/csharp/programming-guide/classes-and-structs/how-to-implement-and-call-a-custom-extension-method#to-define-and-call-the-extension-method">定义和调用扩展方法</a>：
    /// <list type="number">
    /// <item>非嵌套、非泛型静态类，对客户端代码可见</item>
    /// <item>静态方法，可见性至少与所在类的可见性相同</item>
    /// <item>第一个参数指定方法所操作的类型，参数前面必须加上 this 修饰符</item>
    /// <item>添加 using 指令，用于指定包含扩展方法类的命名空间</item>
    /// <item>添加 using 指令，用于指定包含扩展方法类的命名空间</item>
    /// <item>使用实例方法语法调用</item>
    /// </list>
    /// </para>
    /// </summary>
    [Test]
    public void ExtensionMethods()
    {
        {
            var dog = new Dog("A");
            dog.Feed();
        }
    }
}
