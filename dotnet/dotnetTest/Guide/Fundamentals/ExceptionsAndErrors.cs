using dotnetTest.Guide.LanguageReference.Statements;
using dotnetTest.Guide.ProgrammingGuide.ClassesStructsRecords;

namespace dotnetTest.Guide.Fundamentals;

/// <summary>
/// <a href="https://learn.microsoft.com/zh-cn/dotnet/csharp/fundamentals/exceptions/">异常和异常处理</a>
/// <list type="bullet">
/// <item>异常全都派生自 System.Exception</item>
/// <item>除非能够处理异常异常并使应用程序处于已知状态，否则不要捕获异常。如果捕获 System.Exception，在 catch 块的末尾使用 throw 重新抛出它</item>
/// <item>如果 catch 定义了一个异常变量，则可以使用它来获取发生异常的更多信息 ???</item>
/// </list>
/// <para>
/// 如果抛出异常后在调用堆栈上找不到兼容的 catch 块，则发生以下情况：
/// <list type="number">
/// <item>如果异常在<see cref="Finalizers">终结器</see>内，则终结器中止，并调用基终结器</item>
/// <item>如果调用堆栈包含静态构造函数或静态字段初始值设定项，则会引发 TypeInitializationException，并将原始异常分配给新异常的 InnerException 属性</item>
/// <item>如果达到线程的起始点，则终止线程</item>
/// </list>
/// </para>
/// </summary>
/// <remarks>
/// <a href="https://learn.microsoft.com/zh-cn/dotnet/standard/exceptions/">异常</a><br/>
/// <a href="https://learn.microsoft.com/zh-cn/training/modules/implement-exception-handling-c-sharp/">在 C# 控制台应用程序中实现异常处理</a><br/>
/// <a href="https://learn.microsoft.com/zh-cn/training/modules/create-throw-exceptions-c-sharp/">在 C# 控制台应用程序中创建和引发异常</a>
/// </remarks>
/// <seealso cref="ExceptionHandlingStatements">异常处理语句</seealso>
public class ExceptionsAndErrors
{
    /// <summary>
    /// <a href="https://learn.microsoft.com/zh-cn/dotnet/csharp/fundamentals/exceptions/exception-handling">异常处理</a>
    /// <list type="bullet">
    /// <item>catch 块可以指定要捕获的异常的类型，该类型规范成为异常筛选器</item>
    /// <item>一般不要将 Exception 指定为异常筛选器，除非知道如何处理 try 块可能抛出的所有异常，或者在 catch 块的末尾包含了 throw 语句</item>
    /// </list>
    /// </summary>
    class ExceptionHandling
    {
        /// <summary>
        /// catch 子句 + 布尔表达式
        ///
        /// </summary>
        class CatchClauseBooleanExpression
        {
            int? GetInt(int[] array, int index)
            {
                try
                {
                    return array[index];
                }
                catch (IndexOutOfRangeException e) when (index < 0)
                {
                    throw new ArgumentOutOfRangeException("Parameter index cannot be negative.", e);
                }
                catch (IndexOutOfRangeException e)
                {
                    throw new ArgumentOutOfRangeException("Parameter index cannot be greater than the array size.", e);
                }
                // 始终返回 false 的异常筛选器可用于检查所有异常，但不可用于处理异常，通常用于记录异常
                catch (Exception e) when (LogException(e))
                {
                    return null;
                }
            }
            private static bool LogException(Exception e)
            {
                Console.WriteLine($"\tIn the log routine. Caught {e.GetType()}");
                Console.WriteLine($"\tMessage: {e.Message}");
                return false;
            }
        }
    }

    /// <summary>
    /// <a href="https://learn.microsoft.com/zh-cn/dotnet/csharp/fundamentals/exceptions/creating-and-throwing-exceptions">创建和抛出异常</a>
    /// <para>
    /// <a href="https://learn.microsoft.com/en-us/training/modules/create-throw-exceptions-c-sharp/2-examine-create-exception-c-sharp#create-an-exception-object">创建异常时可能使用的一些常见异常类型</a>：
    /// <list type="bullet">
    /// <item>ArgumentException 或 ArgumentNullException：使用无效的参数值或 null 引用调用方法或构造函数时</item>
    /// <item>InvalidOperationException：当方法的操作条件不支持成功完成特定方法调用时。例如，试图写入只读文件</item>
    /// <item>NotSupportedException：当操作或功能不受支持时</item>
    /// <item>IOException：当输入/输出操作失败时</item>
    /// <item>FormatException：当字符串或数据的格式不正确时</item>
    /// </list>
    /// </para>
    /// <para>
    /// 异常的属性：
    /// <list type="bullet">
    /// <item>StackTrace：包含当前调用堆栈上的方法的名称，以及为每个方法引发异常的位置（文件名和行号）</item>
    /// <item>Message：应该设置此字符串来解释异常的原因</item>
    /// </list>
    /// </para>
    /// <para>
    /// <a href="https://learn.microsoft.com/zh-cn/dotnet/csharp/fundamentals/exceptions/creating-and-throwing-exceptions#exceptions-in-task-returning-methods">任务返回方法中的异常</a>：
    /// <list type="bullet">
    /// <item>异步方法中抛出的异常存储在返回的任务中，直到等待任务时才会出现</item>
    /// <item>建议在在输入方法的异步部分之前验证参数并抛出任何相应的异常</item>
    /// </list>
    /// </para>
    /// </summary>
    class CreateAndThrowExceptions
    {
        /// <summary>
        /// <a href="https://learn.microsoft.com/zh-cn/dotnet/csharp/fundamentals/exceptions/creating-and-throwing-exceptions#define-exception-classes">定义异常类</a>
        /// 程序可以抛出 System 命名空间下的预定义异常，或自己创建的从 Exception 派生出的异常。
        /// </summary>
        class DefineExceptionClasses
        {
            /// <summary>
            /// 至少定义三个构造函数：①无参数构造函数 ②设置 message 属性的构造函数 ③同时设置 message 和 InnerException 属性的构造函数
            /// </summary>
            [Serializable]
            class InvalidDepartmentException : Exception
            {
                public InvalidDepartmentException() : base() { }
                public InvalidDepartmentException(string message) : base(message) { }
                public InvalidDepartmentException(string message, Exception inner) : base(message, inner) { }
            }
        }

        /// <summary>
        /// <a href="https://learn.microsoft.com/zh-cn/dotnet/csharp/fundamentals/exceptions/compiler-generated-exceptions">编译器生成的异常</a>
        /// <list type="bullet">
        /// <item>ArithmeticException</item>
        /// <item>ArrayTypeMismatchException</item>
        /// <item>DivideByZeroException</item>
        /// <item>IndexOutOfRangeException</item>
        /// <item>InvalidCastException</item>
        /// <item>NullReferenceException</item>
        /// <item>OutOfMemoryException</item>
        /// <item>OverflowException</item>
        /// <item>StackOverflowException</item>
        /// <item>TypeInitializationException</item>
        /// </list>
        /// </summary>
        /// <remarks>
        /// <a href="https://learn.microsoft.com/zh-cn/training/modules/implement-exception-handling-c-sharp/3-examine-compiler-generated-exceptions">编译器生成的异常</a>
        /// </remarks>
        class CompilerGeneratedExceptions;
    }
}
