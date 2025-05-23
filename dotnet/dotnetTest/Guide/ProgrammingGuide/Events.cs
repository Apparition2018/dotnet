using dotnetTest.Fundamentals.FundamentalCodingComponents.Events;
using dotnetTest.Guide.LanguageReference.Keywords;

namespace dotnetTest.Guide.ProgrammingGuide;

/// <summary>
/// <a href="https://learn.microsoft.com/zh-cn/dotnet/standard/events/">事件</a><br/>
/// <a href="https://learn.microsoft.com/zh-cn/dotnet/csharp/programming-guide/events/">事件</a><br/>
/// <a href="https://learn.microsoft.com/zh-cn/dotnet/csharp/events-overview">事件简介</a><br/>
/// <list type="bullet">
/// <item><see cref="Counter.ThresholdReached">定义事件</see>：在事件类签名中使用 <see cref="Modifiers.Event">event</see> 关键字，并指定事件的<see cref="Delegates">委托</see>类型</item>
/// <item><see cref="Counter.OnThresholdReached">引发事件</see></item>
/// <item><see cref="Program.c_ThresholdReached">响应事件</see>：在事件接收器中定义一个事件处理程序方法，此方法必须与您正处理的事件的委托签名匹配</item>
/// </list>
/// <para>
/// .NET 提供了委托来支持大部分事件场景：
/// <list type="number">
/// <item>使用 EventHandler 委托处理不包含事件数据的事件</item>
/// <item>使用 <see cref="EventHandler{TEventArgs}"/> 委托处理包含事件相关数据的事件</item>
/// </list>
/// </para>
/// <para>
/// 扩展：
/// <list type="bullet">
/// <item><a href="https://learn.microsoft.com/zh-cn/dotnet/standard/events/how-to-handle-multiple-events-using-event-properties">使用事件属性处理多个事件</a></item>
/// <item><a href="https://learn.microsoft.com/zh-cn/dotnet/csharp/programming-guide/events/how-to-raise-base-class-events-in-derived-classes">在派生类中引发基类事件</a></item>
/// <item><a href="https://learn.microsoft.com/zh-cn/dotnet/csharp/programming-guide/events/how-to-implement-interface-events">实现接口事件</a></item>
/// <item><a href="https://learn.microsoft.com/zh-cn/dotnet/csharp/distinguish-delegates-events">委托 vs 事件</a></item>
/// </list>
/// </para>
/// </summary>
/// <seealso cref="ObserverDesignPattern"/>
public abstract class Events
{

    /// <summary>
    /// <a href="https://learn.microsoft.com/zh-cn/dotnet/standard/events/how-to-raise-and-consume-events#example-2">示例</a>
    /// </summary>
    class Counter(int threshold)
    {
        private int _total;

        public void Add(int x)
        {
            _total += x;
            if (_total < threshold) return;
            ThresholdReachedEventArgs args = new ThresholdReachedEventArgs
            {
                Threshold = threshold,
                TimeReached = DateTime.Now
            };
            OnThresholdReached(args);
        }

        // 标记为 protected virtual，命名为 onEventName，接收 EventArgs 或其派生类的参数
        protected virtual void OnThresholdReached(ThresholdReachedEventArgs e)
        {
            EventHandler<ThresholdReachedEventArgs>? handler = ThresholdReached;
            handler?.Invoke(this, e);
        }

        public event EventHandler<ThresholdReachedEventArgs>? ThresholdReached;
    }

    // 事件参数不再要求必须派生自 System.EventArgs
    // https://learn.microsoft.com/zh-cn/dotnet/csharp/modern-events#events-with-async-subscribers
    class ThresholdReachedEventArgs : EventArgs
    {
        public int Threshold { get; set; }
        public DateTime TimeReached { get; init; }
    }

    class Program
    {
        [Test]
        public void Test()
        {
            var c = new Counter(5);
            // += 订阅事件，-= 取消订阅
            c.ThresholdReached += c_ThresholdReached;
            foreach (var i in Enumerable.Range(0, 5))
            {
                c.Add(1);
            }
        }

        static void c_ThresholdReached(object? sender, ThresholdReachedEventArgs e)
        {
            Console.WriteLine($"{e.TimeReached}: The threshold was reached.");
        }
    }
}
