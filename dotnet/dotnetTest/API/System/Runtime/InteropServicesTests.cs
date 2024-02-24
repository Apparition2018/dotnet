using System.Runtime.InteropServices;
using dotnetTest.Guide.ProgrammingGuide.ClassesStructsRecords;

namespace dotnetTest.API.System.Runtime;

/// <summary>
/// <a href="https://learn.microsoft.com/zh-cn/dotnet/api/system.runtime.interopservices">InteropServices</a>
/// 提供各种支持 COM 互操作和平台调用服务的成员
/// </summary>
/// <remarks>
/// <a href="https://learn.microsoft.com/zh-cn/dotnet/framework/interop/">与非托管代码交互操作</a>
/// </remarks>
public class InteropServicesTests
{
    /// <summary>
    /// <a href="https://learn.microsoft.com/zh-cn/dotnet/api/system.runtime.interopservices.optionalattribute">OptionalAttribute</a>
    /// 指示参数是可选的
    /// <br/>
    /// <a href="https://learn.microsoft.com/zh-cn/dotnet/api/system.runtime.interopservices.defaultparametervalueattribute">DefaultParameterValueAttribute</a>
    /// 设置当从支持默认参数的语言中调用参数时参数的默认值
    /// </summary>
    class OptionalAttribute_DefaultParameterValueAttribute
    {
        [Test]
        public void Test()
        {
            Assert.That(Method(), Is.EqualTo("A"));
            Assert.That(Method("B"), Is.EqualTo("B"));
        }

        private static string Method([Optional, DefaultParameterValue("A")] string str)
        {
            return str;
        }

        /// <summary>与<see cref="Method.NamedAndOptionalArguments.OptionalArguments">可选参数</see> 的差异</summary>
        class VsOptionalArguments
        {
            public static void MethodWithObjectDefaultAttr1([Optional, DefaultParameterValue(123)] object obj) { }
            public static void MethodWithObjectDefaultAttr2([Optional, DefaultParameterValue("abc")] object obj) { }
            public static void MethodWithObjectDefaultAttr3([Optional, DefaultParameterValue(null)] object? obj) { }

            // 除字符串之外的引用类型的默认参数值只能使用 null 进行初始化
            // public static void MethodWithObjectDefaultParam1(object obj = 123) { }
            // public static void MethodWithObjectDefaultParam2(object obj = "abc") { }
            public static void MethodWithObjectDefaultParam3(object obj = null) { }
        }
    }
}
