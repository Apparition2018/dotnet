using dotnet.L.Demo;
using dotnetTest.AdvancedProgramming.AsynchronousProgrammingPatterns;
using dotnetTest.Guide.LanguageReference.BuiltinTypes;
using dotnetTest.Guide.LanguageReference.OperatorsAndExpressions;

namespace dotnetTest.Guide.ProgrammingGuide;

/// <summary>
/// <a href="https://learn.microsoft.com/zh-cn/dotnet/csharp/programming-guide/delegates/">委托</a><br/>
/// <a href="https://learn.microsoft.com/zh-cn/dotnet/csharp/delegates-overview">委托简介</a><br/>
/// <a href="https://learn.microsoft.com/zh-cn/dotnet/standard/delegates-lambdas">委托和 lambda</a><br/>
/// <list type="bullet">
/// <item>委托是一种引用类型，表示对具有特定参数列表和返回类型的方法的引用</item>
/// <item>委托类似于 C++ 函数指针。不同的是，委托是面向对象的、类型安全的和可靠的</item>
/// <item>委托允许将方法作为参数进行传递 / 委托可用于定义回调方法</item>
/// <item><see cref="MulticastDelegates">委托可以链接在一起</see></item>
/// <item><a href="https://learn.microsoft.com/zh-cn/dotnet/csharp/programming-guide/concepts/covariance-contravariance/using-variance-in-delegates">方法不必与委托类型完全匹配</a></item>
/// </list>
/// </summary>
/// <seealso cref="Events"/>
/// <seealso cref="ReferenceTypes.BuiltInReferenceTypes.DelegateType">委托类型</seealso>
/// <seealso cref="AsynchronousProgrammingModel.UsingDelegates">使用委托进行异步编程</seealso>
public class Delegates : Demo
{
    delegate void NotifyCallback(string str);

    // 声明一个与委托具有相同签名的方法
    static void Notify(string name)
    {
        Console.WriteLine($"Notification received for: {name}");
    }

    /// <summary>
    /// <a href="https://learn.microsoft.com/zh-cn/dotnet/csharp/programming-guide/delegates/how-to-declare-instantiate-and-use-a-delegate">声明委托</a>
    /// </summary>
    /// <seealso cref="OperatorsAndExpressions.DelegateOperator"/>
    [Test]
    public void Declare()
    {
        NotifyCallback del1 = new NotifyCallback(Notify);
        NotifyCallback del2 = Notify;
        // 匿名方法
        NotifyCallback del3 = delegate(string name) { Console.WriteLine($"Notification received for: {name}"); };
        // lambda
        NotifyCallback del4 = name => { Console.WriteLine($"Notification received for: {name}"); };
    }

    /// <summary>
    /// <a href="https://learn.microsoft.com/zh-cn/dotnet/csharp/programming-guide/delegates/how-to-combine-delegates-multicast-delegates">多播委托</a>
    /// + 运算符可将多个对象分配到一个委托实例，- 运算符可从多播委托中删除组件委托
    /// </summary>
    [Test]
    public void MulticastDelegates()
    {
        NotifyCallback del1 = Notify;
        NotifyCallback del2 = delegate(string name) { Console.WriteLine($"Notification received for: {name}"); };

        NotifyCallback callback = new NotifyCallback(Notify);
        callback += del1;
        _ = (callback -= del1)! ?? throw new InvalidOperationException();
        callback += del2;
        callback("ljh");
    }

    /// <summary>
    /// <a href="https://learn.microsoft.com/zh-cn/dotnet/csharp/programming-guide/generics/generic-delegates">泛型委托</a><br/>
    /// </summary>
    class GenericDelegates
    {
        delegate T Operator<T>(T o1, T o2);

        static int Add(int a, int b)
        {
            return a + b;
        }

        static double Sub(double a, double b)
        {
            return a - b;
        }

        [Test]
        public void Test()
        {
            Operator<int> operator1 = Add;
            Operator<double> operator2 = Sub;
            Assert.That(operator1(1, 2), Is.EqualTo(3));
            Assert.That(operator2(2, 1), Is.EqualTo(1));
        }

        /// <summary>
        /// <a href="https://learn.microsoft.com/zh-cn/dotnet/csharp/delegates-strongly-typed">强类型委托</a>
        /// .NET Core 框架包含的，在需要委托类型时可重用的类型
        /// <list type="bullet">
        /// <item>Action：封装方法返回值为 void，用于使用委托参数执行操作的情况</item>
        /// <item>Func：封装的方法返回指定类型，用于将委托参数转换为其他结果的情况</item>
        /// <item>Predicate：封装的方法返回 bool，用于需要确定参数是否满足委托条件的情况</item>
        /// </list>
        /// </summary>
        [Test]
        public void StronglyTypedDelegates()
        {
            #region Action
            Action<string, int> printPersonInfo = (name, age) => { Console.WriteLine($"Name: {name}, Age: {age}"); };
            printPersonInfo("Alice", 30);
            #endregion

            #region Func
            Func<int, int, int> add = (x, y) => x + y;
            Assert.That(add(5, 3), Is.EqualTo(8));
            #endregion

            #region Predicate
            Predicate<int> isEven = x => x % 2 == 0;
            var evenNumbers = Ints.ToList().FindAll(isEven);
            evenNumbers.ForEach(Console.WriteLine);
            #endregion
        }
    }
}
