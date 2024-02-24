using System.Reflection;
using dotnet.L.Demo;

namespace dotnetTest.Fundamentals.FundamentalCodingComponents;

/// <summary>
/// <a href="https://learn.microsoft.com/zh-cn/dotnet/standard/attributes/">特性</a><br/>
/// <a href="https://learn.microsoft.com/zh-cn/dotnet/csharp/advanced-topics/reflection-and-attributes/">反射和特性</a>
/// 编译代码时，特性将被发到元数据中，并且通过运行时反射服务可用于公共语言运行时和任何自定义工具或应用程序
/// </summary>
public class Attributes
{
    /// <summary>
    /// <a href="https://learn.microsoft.com/zh-cn/dotnet/standard/attributes/writing-custom-attributes">编写自定义特性</a>
    /// <list type="number">
    /// <item>应用 AttributeUsageAttribute</item>
    /// <item>声明特性类：公共类，直接或间接继承 System.Attribute</item>
    /// <item>声明构造函数</item>
    /// <item>声明属性</item>
    /// </list>
    /// </summary>
    class DeveloperAttribute : Attribute
    {
        private string _name;
        private string _level;
        private bool _reviewed;

        public DeveloperAttribute(string name, string level)
        {
            _name = name;
            _level = level;
            _reviewed = false;
        }

        public virtual string Name => _name;

        public virtual string Level => _level;

        public virtual bool Reviewed
        {
            get => _reviewed;
            set => _reviewed = value;
        }
    }


    /// <summary>
    /// 应用特性：
    /// <list type="number">
    /// <item>通过将特性置于紧邻元素之前，将该特性应用于代码元素</item>
    /// <item>指定特性的位置参数和命名参数</item>
    /// </list>
    /// </summary>
    [Developer(Demo.MyName, "1", Reviewed = true)]
    private static int Add(int a, int b)
    {
        return a + b;
    }

    /// <summary>
    /// <a href="https://learn.microsoft.com/zh-cn/dotnet/standard/attributes/retrieving-information-stored-in-attributes">检索存储在特性中的信息</a>
    /// </summary>
    [Test]
    public void RetrievingInformationStoredInAttributes()
    {
        Type type = typeof(Attributes);
        MethodInfo methodInfo = type.GetMethod(nameof(Add), BindingFlags.NonPublic | BindingFlags.Static)!;
        DeveloperAttribute myAttribute =
            (DeveloperAttribute)Attribute.GetCustomAttribute(methodInfo, typeof(DeveloperAttribute))!;
        Assert.That(myAttribute.Name, Is.EqualTo(Demo.MyName));
    }
}
