using dotnet.L.Demo;
using dotnetTest.Guide.LanguageReference.OperatorsAndExpressions;

namespace dotnetTest.Guide.LanguageReference.Keywords;

/// <summary>
/// <a href="https://learn.microsoft.com/zh-cn/dotnet/csharp/language-reference/keywords/">关键字</a>
/// </summary>
public class Keywords
{
    /// <summary>命名空间关键字</summary>
    class NamespaceKeywords
    {
        /// <summary>
        /// <a href="https://learn.microsoft.com/zh-cn/dotnet/csharp/language-reference/keywords/using-directive#using-alias">using 指令</a>
        /// 允许使用在命名空间中定义的类型，而无需指定该类型的完全限定命名空间
        /// <list type="bullet">
        /// <item>global using：应用于编译中的所有文件</item>
        /// <item>using static：无需指定类型名称即可访问其静态成员和嵌套类型</item>
        /// <item>using 别名：以便更易于将标识符限定为命名空间或类型</item>
        /// </list>
        /// </summary>
        class UsingDirective;

        /// <summary>
        /// <a href="https://learn.microsoft.com/zh-cn/dotnet/csharp/language-reference/keywords/extern-alias">外部别名</a>
        /// 引用具有相同的完全限定类型名称的程序集的两个版本。
        /// <list type="bullet">
        /// <item>在命令提示符下指定别名，如：<c>/r:GridV1=grid.dll</c>，<c>/r:GridV2=grid20.dll</c>。将创建外部别名 GridV1 和 GridV2</item>
        /// <item>使用 <see cref="Modifiers.Extern">extern</see> 关键字引用别名：<c>extern alias GridV1</c>，<c>extern alias GridV2</c></item>
        /// </list>
        /// </summary>
        class ExternAlias;
    }

    /// <summary>泛型类型约束关键字</summary>
    class GenericTypeConstraintKeywords
    {
        class ItemFactory<T> where T : IComparable, new()
        {
            public T GetNewItem()
            {
                return new T();
            }
        }

        /// <summary>
        /// <a href="https://learn.microsoft.com/zh-cn/dotnet/csharp/language-reference/keywords/where-generic-type-constraint">where（泛型类型约束）</a>
        /// 泛型定义中的 where 子句指定对用作泛型类型、方法、委托或本地函数中类型参数的参数类型的约束
        /// </summary>
        [Test]
        public void Where()
        {
            var cage = new Cage<Pet>(2);
            cage.PutIn(new Dog("A"));
            cage.PutIn(new Cat("B"));
        }

        /// <summary>
        /// <a href="https://learn.microsoft.com/zh-cn/dotnet/csharp/language-reference/keywords/new-constraint">new 约束</a>
        /// 指定泛型类或方法声明中的类型参数必须具有公共的无参数构造函数。若要使用 new 约束，不能是 abstract 类型。
        /// 与其他约束一起使用时，new() 约束必须最后指定。
        /// </summary>
        /// <seealso cref="OperatorsAndExpressions.NewOperator">创建类型的实例</seealso>
        /// <seealso cref="Modifiers.NewModifier">成员声明修饰符</seealso>
        [Test]
        public void NewConstraint()
        {
            ItemFactory<int> itemFactory = new ItemFactory<int>();
            int item = itemFactory.GetNewItem();
            Assert.That(item, Is.EqualTo(0));
        }
    }

    /// <summary>访问关键字</summary>
    class AccessKeywords
    {
        /// <summary>
        /// <a href="https://learn.microsoft.com/zh-cn/dotnet/csharp/language-reference/keywords/this">this</a>
        /// ① 指代类的当前实例 ②用作扩展方法的第一个参数的修饰符 ③声明索引器
        /// </summary>
        class This;
    }

    /// <summary>上下文关键字</summary>
    class ContextualKeywords
    {
        /// <summary>
        /// <a href="https://learn.microsoft.com/zh-cn/dotnet/csharp/language-reference/keywords/init">init</a>
        /// 在属性或索引器中定义访问器方法。
        /// init-only setter 仅允许在对象构造期间为属性或索引器元素赋值。
        /// </summary>
        [Test]
        public void Init()
        {
            var c = new Coords
            {
                X = 1,
                Y = 1
            };
            // c.X = 2; // Not allowed
        }

        /// <summary>
        /// <a href="https://learn.microsoft.com/zh-cn/dotnet/csharp/language-reference/keywords/value">value</a>
        /// 在属性和索引器声明的 set 访问器中使用。
        /// 类似于方法的输入参数，引用客户端代码尝试分配给属性或索引器的值。
        /// </summary>
        class Value;
    }
}
