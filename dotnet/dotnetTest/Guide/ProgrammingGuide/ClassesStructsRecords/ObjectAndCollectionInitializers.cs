namespace dotnetTest.Guide.ProgrammingGuide.ClassesStructsRecords;

/// <summary>
/// <a href="https://learn.microsoft.com/zh-cn/dotnet/csharp/programming-guide/classes-and-structs/object-and-collection-initializers">对象和集合初始值设定项</a>
/// </summary>
public class ObjectAndCollectionInitializers
{
    class Product
    {
        /*
         * required 关键字 强制调用方使用对象初始值设定项设置属性或字段的值
         * https://learn.microsoft.com/zh-cn/dotnet/csharp/programming-guide/classes-and-structs/object-and-collection-initializers#object-initializers-with-the-required-modifier
         * https://learn.microsoft.com/zh-cn/dotnet/csharp/language-reference/keywords/required
         */
        /*
         * init 访问器 禁止修改
         * https://learn.microsoft.com/zh-cn/dotnet/csharp/programming-guide/classes-and-structs/object-and-collection-initializers#object-initializers-with-the-init-accessor
         * https://learn.microsoft.com/zh-cn/dotnet/csharp/language-reference/keywords/init
         */
        public required string Name { get; init; }
        public decimal Price { get; set; }
        public string? Color { get; set; }
    }

    [Test]
    public void Test()
    {
        var products = new List<Product>
        {
            // 集合初始值设定项
            // https://learn.microsoft.com/zh-cn/dotnet/csharp/programming-guide/classes-and-structs/object-and-collection-initializers#collection-initializers
            new() { Name = "toy1", Price = 1, Color = "red" },
            new() { Name = "toy2", Price = 1, Color = "blue" }
        };

        var productInfos = from p in products
            // 匿名类型
            // https://learn.microsoft.com/zh-cn/dotnet/csharp/programming-guide/classes-and-structs/object-and-collection-initializers#object-initializers-with-anonymous-types
            select new
            {
                p.Name,
                // 重命名字段
                NewPrice = p.Price
            };

        foreach (var p in productInfos)
        {
            // p.Name = Path.GetRandomFileName(); // property is immutable
            Console.WriteLine(p);
        }
    }
}
