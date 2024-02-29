namespace dotnetTest.Guide;

/// <summary>接口</summary>
public class Interfaces
{
    /// <summary>
    /// <a href="https://learn.microsoft.com/zh-cn/dotnet/csharp/programming-guide/interfaces/explicit-interface-implementation">显示接口实现</a>
    /// </summary>
    class ExplicitInterfaceImplementation()
    {
        interface IControl
        {
            string Paint();


            string Paint2()
            {
                return "IControl.Defa   ultPaint";
            }
        }

        interface ISurface
        {
            string Paint();
        }

        class SampleClass : IControl, ISurface
        {
            // 显式接口实现没有访问修饰符，因为它不能作为其定义类型的成员进行访问。而只能在通过接口实例调用时访问。
            string IControl.Paint()
            {
                return "IControl.Paint";
            }

            string ISurface.Paint()
            {
                return "ISurface.Paint";
            }
        }

        [Test]
        public void Test()
        {
            SampleClass sample = new SampleClass();
            IControl control = sample;
            ISurface surface = sample;
            Assert.That(control.Paint(), Is.EqualTo("IControl.Paint"));
            Assert.That(surface.Paint(), Is.EqualTo("ISurface.Paint"));
            // 可以为在接口中声明的成员定义一个实现。如果类从接口继承方法实现，则只能通过接口类型的引用访问该方法。
            // sample.Paint2(); // "Paint2" isn't accessible.
            Assert.That(control.Paint2(), Is.EqualTo("IControl.DefaultPaint"));
        }
    }
}
