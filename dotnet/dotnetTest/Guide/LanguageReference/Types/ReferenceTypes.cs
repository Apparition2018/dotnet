using dotnet.L.Demo;
using dotnetTest.Guide.LanguageReference.OperatorsAndExpressions;
using dotnetTest.Guide.LanguageReference.Statements;
using dotnetTest.Guide.ProgrammingGuide;
using dotnetTest.Guide.ProgrammingGuide.ClassesStructsRecords;

namespace dotnetTest.Guide.LanguageReference.Types;

/// <summary>
/// <a href="https://learn.microsoft.com/zh-cn/dotnet/csharp/language-reference/keywords/reference-types">引用类型</a>
/// <para>
/// 用于声明引用类型的关键字：class, interface, delegate, record<br/>
/// </para>
/// </summary>
public class ReferenceTypes
{
    /// <summary>
    /// <a href="https://learn.microsoft.com/zh-cn/dotnet/csharp/language-reference/builtin-types/reference-types">内置引用类型</a>
    /// <list type="number">
    /// <item>object</item>
    /// <item><see cref="StringType">string</see></item>
    /// <item><see cref="DelegateType">delegate</see></item>
    /// <item><see cref="DynamicType">dynamic</see></item>
    /// </list>
    /// </summary>
    class BuiltInReferenceTypes
    {
        /// <summary>
        /// <a href="https://learn.microsoft.com/zh-cn/dotnet/csharp/language-reference/builtin-types/reference-types#the-string-type">字符串类型</a>
        /// </summary>
        /// <remarks>
        /// <a href="https://learn.microsoft.com/zh-cn/dotnet/csharp/language-reference/builtin-types/reference-types#utf-8-string-literals">UTF-8 字符串字面量</a>
        /// </remarks>
        /// <seealso cref="MemberAccessOperatorsAndExpressions.RangeOperator">[] 运算符访问字符</seealso>
        class StringType
        {
            /// <summary>相等</summary>
            [Test]
            public void Equality()
            {
                string a = "hello";
                string b = "h";
                b += "ello";
                // 相等运算符，比较 string 对象的值，而不是引用的值
                // java a == b 为 false
                Assert.That(a == b, Is.EqualTo(true));
                Assert.That(a.Equals(b), Is.EqualTo(true));
                Assert.That(ReferenceEquals(a, b), Is.EqualTo(false));
            }

            /// <summary>
            /// <a href="https://learn.microsoft.com/zh-cn/dotnet/csharp/language-reference/builtin-types/reference-types#string-literals">字符串字面量</a>
            /// <list type="number">
            /// <item>原始 row：至少三个双引号 (""") 括起来，可以包含任意文本，而无需转义序列 ???</item>
            /// <item>引号 quoted</item>
            /// <item><see cref="SpecialCharacters.VerbatimStringLiteral">逐字 verbatim</see>：以 @ 开头，不处理转义序列</item>
            /// </list>
            /// </summary>
            [Test]
            public void StringLiterals()
            {
                var row = """"
                          """
                          This is a very important message.
                          """
                          """";
                Console.WriteLine(row);

                var verbatim = @"C:\Docs\Source\a.txt";
                Console.WriteLine(verbatim);
            }
        }

        /// <summary>
        /// <a href="https://learn.microsoft.com/zh-cn/dotnet/csharp/language-reference/builtin-types/reference-types#the-delegate-type">委托类型</a>
        /// <list type="bullet">
        /// <item>委托类型的声明与方法签名相似。它有一个返回值和任意数目任意类型的参数</item>
        /// <item>System.Action 和 System.Func 类型为许多常见委托提供泛型定义</item>
        /// <item>一种可用于封装命名方法或匿名方法的引用类型。类似 C++ 的函数指针，但是委托是类型安全和可靠的</item>
        /// </list>
        /// </summary>
        /// <seealso cref="Delegates"/>
        class DelegateType;

        /// <summary>
        /// <a href="https://learn.microsoft.com/zh-cn/dotnet/csharp/language-reference/builtin-types/reference-types#the-dynamic-type">动态类型</a>
        /// <list type="bullet">
        /// <item>表示变量的使用和对其成员的引用绕过编译时类型检查，改在运行时解析这些操作（运行时 dynamic → object）</item>
        /// <item>简化了对 COM API（例如 Office Automation API）、动态 API（例如 IronPython 库）和 HTML 文档对象模型 (DOM) 的访问</item>
        /// </list>
        /// </summary>
        [Test]
        public void DynamicType()
        {
            dynamic dyn = 1;
            object obj = 1;
            dyn = dyn + 3;
            // obj = obj + 3; // Cannot apply operator '+' to operands of type 'object' and 'int'
            Console.WriteLine(dyn.GetType());
            Console.WriteLine(obj.GetType());
        }
    }

    /// <summary>
    /// <a href="https://learn.microsoft.com/zh-cn/dotnet/csharp/language-reference/builtin-types/record">记录</a>
    /// 定义一个引用类型，用来提供用于封装数据的内置功能。
    /// record class 引用类型，record <see cref="ValueTypes.StructureTypes">struct</see> 值类型。
    /// <para>
    /// 记录是可变的，但主要用于支持不可变的数据模型：
    /// <list type="bullet">
    /// <item><see cref="PositionalSyntaxForPropertyDefinition">用于创建具有不可变属性的引用类型的简明语法</see></item>
    /// <item>内置行为对于以数据为中心的引用类型非常有用：①<see cref="ValueEquality">值相等性</see> ②<see cref="NondestructiveMutation">非破坏性变化的简明语法</see>
    /// ③<a href="https://learn.microsoft.com/zh-cn/dotnet/csharp/language-reference/builtin-types/record#built-in-formatting-for-display">用于显示的内置格式设置</a></item>
    /// <item>支持继承层次结构</item>
    /// </list>
    /// </para>
    /// </summary>
    /// <remarks>
    /// <a href="https://learn.microsoft.com/zh-cn/dotnet/csharp/fundamentals/types/records">Records</a>
    /// </remarks>
    /// <seealso cref="Product"/>
    class Records
    {
        /// <summary>
        /// <a href="https://learn.microsoft.com/zh-cn/dotnet/csharp/language-reference/builtin-types/record#positional-syntax-for-property-definition">属性定义的位置语法</a>
        /// <para>
        /// 当为属性定义使用位置语法时，编译器将创建以下内容：
        /// <list type="bullet">
        /// <item>为每个位置参数提供一个公共的<a href="https://learn.microsoft.com/zh-cn/dotnet/csharp/programming-guide/classes-and-structs/auto-implemented-properties">自动实现的属性</a>：
        /// record/readonly record struct：init-only；record struct：read-write</item>
        /// <item>一个主构造函数</item>
        /// <item>对于 record struct，一个无参构造函数，将每个字段设置为默认值</item>
        /// <item>一个解构方法 ???</item>
        /// </list>
        /// </para>
        /// </summary>
        [Test]
        public void PositionalSyntaxForPropertyDefinition() { }

        private readonly Product _p = new Product(1, "toy");

        /// <summary>
        /// <a href="https://learn.microsoft.com/zh-cn/dotnet/csharp/language-reference/builtin-types/record#value-equality">值相等性</a>
        /// 声明的类型控制如何定义相等性：
        /// <list type="bullet">
        /// <item>class 类型：两个对象引用内存中的同一对象</item>
        /// <item>struct 类型：两个对象是相同的类型并且存储相同的值；由 ValueType.Equals(Object) 实现，并依赖反射</item>
        /// <item>record 修饰的类型：两个对象是相同的类型并且存储相同的值；由编译器合成，并使用声明的数据成员</item>
        /// </list>
        /// </summary>
        [Test]
        public void ValueEquality()
        {
            Product p2 = new Product(1, "toy");
            Assert.That(_p == p2, Is.EqualTo(true));
            Assert.That(ReferenceEquals(_p, p2), Is.EqualTo(false));
        }

        /// <summary>
        /// <a href="https://learn.microsoft.com/zh-cn/dotnet/csharp/language-reference/builtin-types/record#nondestructive-mutation">非破坏性变化</a>
        /// </summary>
        /// <seealso cref="OperatorsAndExpressions.WithExpression"/>
        [Test]
        public void NondestructiveMutation()
        {
            Product p2 = _p with { Color = "red" };
            Assert.That(_p == p2, Is.EqualTo(false));
            p2 = _p with { };
            Assert.That(_p == p2, Is.EqualTo(true));
        }

        /// <summary>
        /// <a href="https://learn.microsoft.com/zh-cn/dotnet/csharp/language-reference/builtin-types/record#inheritance">继承</a>
        /// 本部分仅适用于 record class 类型。
        /// record 可以继承 record。record 不能继承 class，class 也不能继承 record。
        /// </summary>
        [Test]
        public void Inheritance() { }
    }

    /// <summary>
    /// <a href="https://learn.microsoft.com/zh-cn/dotnet/csharp/language-reference/keywords/class">类</a>
    /// 单一继承：只能继承一个类，可以实现多个接口。
    /// 类默认 internal，类成员默认 private。
    /// <para>
    /// 可以包含以下成员的声明：
    /// <list type="bullet">
    /// <item><see cref="Constructors">构造函数</see></item>
    /// <item><a href="https://learn.microsoft.com/zh-cn/dotnet/csharp/programming-guide/classes-and-structs/constants">常量</a></item>
    /// <item><a href="https://learn.microsoft.com/zh-cn/dotnet/csharp/programming-guide/classes-and-structs/fields">字段</a></item>
    /// <item><see cref="Finalizers">终结器</see></item>
    /// <item><see cref="Method">方法</see></item>
    /// <item><a href="https://learn.microsoft.com/zh-cn/dotnet/csharp/programming-guide/classes-and-structs/properties">属性</a></item>
    /// <item><see cref="Indexers">索引器</see></item>
    /// <item><see cref="OperatorsAndExpressions">运算符</see></item>
    /// <item><see cref="Events">事件</see></item>
    /// <item><see cref="Delegates">委托</see></item>
    /// <item><a href="https://learn.microsoft.com/zh-cn/dotnet/csharp/fundamentals/types/classes">类</a></item>
    /// <item><a href="https://learn.microsoft.com/zh-cn/dotnet/csharp/fundamentals/types/interfaces">接口</a></item>
    /// <item><see cref="ValueTypes.StructureTypes">结构类型</see></item>
    /// <item><see cref="ValueTypes.EnumerationTypes">枚举类型</see></item>
    /// </list>
    /// </para>
    /// </summary>
    /// <remarks>
    /// <a href="https://learn.microsoft.com/zh-cn/dotnet/csharp/fundamentals/types/classes">类</a>
    /// </remarks>
    class Class;

    /// <summary>
    /// <a href="https://learn.microsoft.com/zh-cn/dotnet/csharp/language-reference/keywords/interface">接口</a>
    /// <list type="bullet">
    /// <item>实现 interface 的 class、record、struct 必须提供接口中定义的成员的实现</item>
    /// <item>可以为成员定义默认实现</item>
    /// <item>可以定义 static 成员，以便提供通用功能的单一实现</item>
    /// <item>可以定义 static abstract 或 static virtual 成员，以声明实现类型必须提供声明的成员。通常，static virtual 方法声明实现必须定义一组<see cref="OperatorsAndExpressions.OperatorOverloading">重载运算符</see></item>
    /// <item>可以是 namespace 或 class 的成员</item>
    /// </list>
    /// <para>
    /// 可以包含以下成员的声明（没有实现）：
    /// <list type="bullet">
    /// <item><see cref="Method">方法</see></item>
    /// <item><a href="https://learn.microsoft.com/zh-cn/dotnet/csharp/programming-guide/classes-and-structs/properties">属性</a></item>
    /// <item><see cref="Indexers">索引器</see></item>
    /// <item><see cref="Events">事件</see></item>
    /// </list>
    /// </para>
    /// <para>
    /// <a href="https://learn.microsoft.com/zh-cn/dotnet/csharp/language-reference/keywords/interface#default-interface-members">默认接口成员</a>：
    /// <list type="bullet">
    /// <item><a href="https://learn.microsoft.com/zh-cn/dotnet/csharp/programming-guide/classes-and-structs/constants">常量</a></item>
    /// <item><see cref="OperatorsAndExpressions">运算符</see></item>
    /// <item><see cref="Constructors.StaticConstructors">静态构造函数</see></item>
    /// <item><see cref="NestedTypes">嵌套类型</see></item>
    /// <item><a href="https://learn.microsoft.com/zh-cn/dotnet/csharp/language-reference/keywords/static">静态字段、方法、属性、索引和事件</a></item>
    /// <item><a href="https://learn.microsoft.com/zh-cn/dotnet/csharp/language-reference/proposals/csharp-8.0/default-interface-methods#explicit-implementation-in-interfaces">使用显式接口实现语法的成员声明</a></item>
    /// <item>显式访问修饰符</item>
    /// </list>
    /// </para>
    /// <para>
    /// 接口继承：
    /// <list type="bullet">
    /// <item>不允许使用实例字段</item>
    /// <item>不支持实例自动实现属性，因为会隐式声明字段</item>
    /// <item>可以继承一个或多个接口，重写基接口的方法时，必须使用<see cref="Interfaces.ExplicitInterfaceImplementation">显示接口实现</see>语法</item>
    /// <item>基类型列表包含基类和接口时，基类必须位于列表的第一位 ???</item>
    /// <item>实现接口的类可以显式实现该接口的成员。显式实现的成员不能通过类实例访问，只能通过接口实例访问</item>
    /// <item>只能通过接口实例访问默认接口成员</item>
    /// </list>
    /// </para>
    /// </summary>
    /// <remarks>
    /// <a href="https://learn.microsoft.com/zh-cn/dotnet/csharp/fundamentals/types/interfaces">接口</a><br/>
    /// <a href="https://learn.microsoft.com/zh-cn/dotnet/csharp/language-reference/keywords/interface#static-abstract-and-virtual-members">static abstract and virtual 成员 ???</a>
    /// </remarks>
    class Interface;

    /// <summary>
    /// <a href="https://learn.microsoft.com/zh-cn/dotnet/csharp/language-reference/builtin-types/nullable-reference-types">可为 null 的引用类型</a>
    /// <para>
    /// 可为 null 的上下文中：
    /// <list type="bullet">
    /// <item>引用类型 T 的变量必须用非 null 值进行初始化，并且不能分配可能为 null 的值</item>
    /// <item>引用类型 T? 的变量可以用 null 机型初始化，也可分配 null，但在取消引用之前必须检查是否为 null</item>
    /// <item>类型为 T? 的变量 m 在应用 null 包容运算符时（如：m!），被认为时非 null 的</item>
    /// </list>
    /// </para>
    /// <para>
    /// 设置可为 null 的上下文：
    /// <list type="number">
    /// <item>项目级别：<c>&lt;Nullable>enable&lt;/Nullable></c></item>
    /// <item>单个源文件：#nullable enable</item>
    /// </list>
    /// </para>
    /// </summary>
    /// <remarks>
    /// <a href="https://learn.microsoft.com/zh-cn/ef/core/miscellaneous/nullable-reference-types">使用可为 null 引用类型</a>
    /// </remarks>
    class NullableReferenceTypes;

    /// <summary>
    /// <a href="https://learn.microsoft.com/zh-cn/dotnet/csharp/language-reference/builtin-types/collections">集合</a>
    /// <para>
    /// 分类：
    /// <list type="bullet">
    /// <item>可索引集合：可以使用其索引访问每个元素的集合，如 List</item>
    /// <item>键值对集合：可通过使用每个元素的键访问集合中的元素，如 Dictionary</item>
    /// <item>迭代器：使用 <see cref="YieldStatement">yield</see> return 语句返回集合的每一个元素</item>
    /// </list>
    /// </para>
    /// <para>
    /// 按特征分类：
    /// <list type="bullet">
    /// <item>元素访问：System.Collections.Generic.List、System.Collections.Generic.Dictionary</item>
    /// <item>性能概况</item>
    /// <item>动态增长和收缩：Array、System.Span、System.Memory 不支持动态添加或删除元素</item>
    /// </list>
    /// </para>
    /// </summary>
    /// <remarks>
    /// <a href="https://learn.microsoft.com/zh-cn/dotnet/standard/collections/commonly-used-collection-types">常用的集合类型</a><br/>
    /// <a href="https://learn.microsoft.com/zh-cn/dotnet/standard/collections/selecting-a-collection-class">选择集合类</a>
    /// </remarks>
    class Collections;

    /// <summary>
    /// <a href="https://learn.microsoft.com/zh-cn/dotnet/csharp/language-reference/builtin-types/arrays">数组</a>
    /// <list type="bullet">
    /// <item>数组可以是一维、多维、交错</item>
    /// <item>声明数组变量时设置维度数。每个维度的长度都是在创建实例时确定的，在实例的生存期内无法改变</item>
    /// <item>交错数组每个成员数组的默认值为 null</item>
    /// <item>从 Array 派生的，所有数组都实现 IList 和 IEnumerable。一维数组还实现了 IList&lt;T> 和 IEnumerable&lt;T></item>
    /// </list>
    /// </summary>
    [Test]
    public void Arrays()
    {
        // 多维数组
        int[,] twoDimensionalArray1 = new int[2, 3];
        Assert.That(twoDimensionalArray1[0, 0], Is.EqualTo(0));
        int[,] twoDimensionalArray2 = { { 1, 2 }, { 3, 4 }, { 5, 6 }, { 7, 8 } };
        Assert.That(twoDimensionalArray2[1, 1], Is.EqualTo(4));
        int[,,] threeDimensionalArray = { { { 1, 2, 3 }, { 4, 5, 6 } }, { { 7, 8, 9 }, { 10, 11, 12 } } };
        Assert.That(threeDimensionalArray[1, 1, 1], Is.EqualTo(11));
        Assert.That(threeDimensionalArray.Length, Is.EqualTo(12));
        foreach (var i in threeDimensionalArray)
        {
            // 1 2 3 4 5 6 7 8 9 10 11 12
            Console.Write($"{i} ");
        }

        // 交错数组
        int[][] jaggedArray = new int[3][];
        jaggedArray[0] = [1, 3, 5, 7, 9];
        jaggedArray[1] = [0, 2, 4, 6];
        jaggedArray[2] = [11, 22];
        int[][] jaggedArray2 =
        [
            [1, 3, 5, 7, 9],
            [0, 2, 4, 6],
            [11, 22]
        ];
        Assert.That(jaggedArray[0][1], Is.EqualTo(jaggedArray2[0][1]));
    }
}
