namespace dotnetTest.Guide.LanguageReference.Statements;

/// <summary>
/// <a href="https://learn.microsoft.com/zh-cn/dotnet/csharp/language-reference/statements/using">using 语句</a>
/// 确保正确使用可释放对象
/// </summary>
public class UsingStatement
{
    [Test]
    public void Test()
    {
        var numbers = new List<int>();
        using StreamReader reader = File.OpenText("numbers.txt");
        while (reader.ReadLine() is { } line)
        {
            if (int.TryParse(line, out int number))
            {
                numbers.Add(number);
            }
        }
    }
}
