using System.Diagnostics;

namespace dotnetTest.Guide.ProgrammingGuide.ClassesStructsRecords;

/// <summary>
/// <a href="https://learn.microsoft.com/zh-cn/dotnet/csharp/programming-guide/classes-and-structs/finalizers">终结器</a>
/// 用于在垃圾回收器收集类实例时执行任何必要的最终清理操作。
/// 在大多数情况下，通过使用 System.Runtime.InteropServices.SafeHandle 或派生类包装任何非托管句柄，可以免去编写终结器的过程
/// </summary>
public class Finalizers
{
    class First
    {
        ~First()
        {
            Trace.WriteLine("First's finalizer is called.");
        }
    }

    class Second : First
    {
        ~Second()
        {
            Trace.WriteLine("Second's finalizer is called.");
        }
    }

    class Third : Second
    {
        ~Third()
        {
            Trace.WriteLine("Third's finalizer is called.");
        }
    }

    [Test]
    public void Test()
    {
        var third = new Third();
        third = null;
        // 没有输出，因为在应用程序终止时，.NET 5（包括 .NET Core）或更高版本不调用终结器
    }
}
