namespace dotnetTest.Guide.ProgrammingGuide;

/// <summary>
/// <a href="https://learn.microsoft.com/zh-cn/dotnet/csharp/programming-guide/indexers/">索引器</a><br/>
/// <a href="https://learn.microsoft.com/zh-cn/dotnet/csharp/indexers">索引器</a>
/// <list type="number">
/// <item>用类似于数组的方式为对象建立索引</item>
/// <item>get 取值函数返回值；set 取值函数分配值</item>
/// <item>this 关键字用于定义索引器</item>
/// <item>value 关键字用于定义由 set 访问器分配的值</item>
/// <item>不必根据整数值进行索引；由你决定如何定义特定的查找机制</item>
/// <item>可被重载</item>
/// <item>可以有多个形参，例如当访问二维数组时</item>
/// </list>
/// </summary>
public class Indexers
{
    class SampleCollection<T>
    {
        private T[] _arr = new T[100];

        // this 关键字用于定义索引器
        public T this[int i]
        // 表达式主题定义：https://learn.microsoft.com/zh-cn/dotnet/csharp/programming-guide/indexers/#expression-body-definitions
        {
            get => _arr[i];
            set => _arr[i] = value;
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
