namespace dotnetTest.Guide.LanguageReference.Statements;

/// <summary>
/// <a href="https://learn.microsoft.com/zh-cn/dotnet/csharp/language-reference/statements/exception-handling-statements">异常处理语句</a>
/// </summary>
public class ExceptionHandlingStatements
{
    /// <summary>将 throw 用作表达式</summary>
    [Test]
    public void ThrowExpression()
    {
        string[] args = ["a", "b"];

        // ①条件运算符
        string first = args.Length >= 1
            ? args[0]
            : throw new ArgumentException("Please supply at least one argument.");

        // ②null 合并操作符
        string[] second = args ?? throw new ArgumentNullException(paramName: nameof(args), message: "Name cannot be null");

        // ③表达式主体 lambda 或方法
        DateTime ToDateTime(IFormatProvider provider) =>
            throw new InvalidCastException("Conversion to a DateTime is not supported.");
    }

    /// <summary>try 语句</summary>
    class TryStatement()
    {
        /// <summary>
        /// <a href="https://learn.microsoft.com/zh-cn/dotnet/csharp/language-reference/statements/exception-handling-statements#a-when-exception-filter">when 异常筛选器</a>
        /// </summary>
        [Test]
        public void WhenExceptionFilter()
        {
            try
            {
                // some code
            }
            catch (Exception e) when (e is ArgumentException or DivideByZeroException)
            {
                Console.WriteLine($"Processing failed: {e.Message}");
            }
        }
    }
}
