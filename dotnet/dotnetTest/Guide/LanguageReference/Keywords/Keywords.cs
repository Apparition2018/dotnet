using dotnet.L.Demo;

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
        /// </summary>
        class UsingDirective
        {
            /// <summary>
            /// <a href="https://learn.microsoft.com/zh-cn/dotnet/csharp/language-reference/keywords/using-directive#using-alias">using 别名</a>
            /// 以便更易于将标识符限定为命名空间或类型
            /// </summary>
            /// <remarks>
            /// <a href="https://learn.microsoft.com/zh-cn/dotnet/csharp/language-reference/proposals/csharp-12.0/using-alias-types">Allow using alias directive to reference any kind of Type</a>
            /// </remarks>
            class UsingAlias;
        }
    }

    /// <summary>泛型类型约束关键字</summary>
    class GenericTypeConstraintKeywords
    {
        /// <summary>
        /// <a href="https://learn.microsoft.com/zh-cn/dotnet/csharp/language-reference/keywords/where-generic-type-constraint">where（泛型类型约束）</a>
        /// 泛型定义中的 where 子句指定对用作泛型类型、方法、委托或本地函数中类型参数的参数类型的约束
        /// </summary>
        /// <seealso cref="Cage{T}"/>
        [Test]
        public void Where()
        {
            var cage = new Cage<Pet>(2);
            cage.PutIn(new Dog("A"));
            cage.PutIn(new Cat("B"));
        }
    }

    /// <summary>访问关键字</summary>
    class AccessKeywords
    {
        /// <summary>
        /// <a href="https://learn.microsoft.com/zh-cn/dotnet/csharp/language-reference/keywords/this">this</a>
        /// ① 指代类的当前实例 ②用作扩展方法的第一个参数的修饰符 ③声明索引器
        /// </summary>
        [Test]
        public void This()
        {
        }
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
        [Test]
        public void Value()
        {
        }
    }
}