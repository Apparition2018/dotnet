using dotnetTest.AdvancedProgramming.Threading.ManagedThreadingBasics;

namespace dotnetTest.API.System.Runtime;

/// <summary>
/// <a href="https://learn.microsoft.com/zh-cn/dotnet/api/system.runtime.compilerservices">CompilerServices</a>
/// 为使用托管代码的编译器开发人员提供相关功能，使其能够在元数据中指定特性，这些特性将影响公共语言运行时（CLR）的运行时行为
/// </summary>
public class CompilerServicesTests
{
    /// <summary>
    /// <a href="https://learn.microsoft.com/zh-cn/dotnet/api/system.runtime.compilerservices.methodimplattribute">MethodImplAttribute</a>
    /// 指定如何实现方法
    /// </summary>
    private class MethodImplAttribute
    {
        /// <summary>该方法一次只能由一个线程执行</summary>
        /// <seealso cref="SynchronizeDataForMultithreading.SynchronizationCodeRegions.BankAccount.MethodImplSyncDeposit"/>
        [Test]
        public void SynchronizedOption() { }
    }
}
