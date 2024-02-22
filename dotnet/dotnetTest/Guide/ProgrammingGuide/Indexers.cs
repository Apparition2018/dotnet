namespace dotnetTest.Guide.ProgrammingGuide;

/// <summary>
/// <a href="https://learn.microsoft.com/zh-cn/dotnet/csharp/programming-guide/indexers/">索引器</a>
/// 允许类或结构的实例就像数组一样进行索引。
/// 无需显式指定类型或实例成员，即可设置或检索索引值。
/// </summary>
public class Indexers
{
    class SampleCollection<T>
    {
        private T[] arr = new T[100];

        // this 关键字用于定义索引器
        public T this[int i]
        // 表达式主题定义：https://learn.microsoft.com/zh-cn/dotnet/csharp/programming-guide/indexers/#expression-body-definitions
        {
            get => arr[i];
            set => arr[i] = value;
        }
    }

    [Test]
    public void Test()
    {
        var stringCollection = new SampleCollection<string>();
        stringCollection[0] = "Hello, World";
        Console.WriteLine(stringCollection[0]);
    }
}
