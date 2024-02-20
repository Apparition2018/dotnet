using System.Runtime.InteropServices;
using Microsoft.Win32.SafeHandles;

namespace dotnetTest.AdvancedProgramming.MemoryManagement;

/// <summary>
/// <a href="https://learn.microsoft.com/zh-cn/dotnet/standard/garbage-collection/unmanaged">清理未托管资源</a>
/// 如文件、窗口、网络连接、数据库链接
/// </summary>
public class CleaningUpUnmanagedResources
{
    /// <summary>
    /// <a href="https://learn.microsoft.com/zh-cn/dotnet/standard/garbage-collection/implementing-dispose#implement-the-dispose-pattern">实现释放模式</a>
    ///     <list type="number">
    ///     <item>调用 Dispose 方法的 Dispose(bool) 实现</item>
    ///     <item>执行实际清理的 Dispose(bool) 方法</item>
    ///     <item>从包装非托管资源的 SafeHandle 派生的类（推荐），或对 Object.Finalize 方法的重写</item>
    ///     </list>
    /// </summary>
    class BaseClassWithSafeHandle : IDisposable
    {
        // To detect redundant calls
        private bool _disposedValue;

        // Instantiate a SafeHandle instance.
        private SafeHandle? _safeHandle = new SafeFileHandle(IntPtr.Zero, true);

        // Public implementation of Dispose pattern callable by consumers.
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        // Protected implementation of Dispose pattern.
        protected virtual void Dispose(bool disposing)
        {
            if (!_disposedValue)
            {
                if (disposing)
                {
                    _safeHandle?.Dispose();
                    _safeHandle = null;
                }

                _disposedValue = true;
            }
        }
    }

    /// <summary>
    /// <a href="https://learn.microsoft.com/zh-cn/dotnet/standard/garbage-collection/implementing-dispose#implement-the-dispose-pattern-for-a-derived-class">实现派生类的释放模式</a>
    ///     <list type="number">
    ///     <item>protected override void Dispose(bool) 方法，用于替代基类方法并执行派生类的实际清理。 此方法还必须调用 base.Dispose(bool) 方法，并将释放状态（bool disposing 参数）作为参数传递给它。</item>
    ///     <item>从包装非托管资源的 SafeHandle 派生的类（推荐），或对 Object.Finalize 方法的重写。</item>
    ///     </list>
    /// </summary>
    class DerivedClassWithSafeHandle : BaseClassWithSafeHandle
    {
        // To detect redundant calls
        private bool _disposedValue;

        // Instantiate a SafeHandle instance.
        private SafeHandle? _safeHandle = new SafeFileHandle(IntPtr.Zero, true);

        // Protected implementation of Dispose pattern.
        protected override void Dispose(bool disposing)
        {
            if (!_disposedValue)
            {
                if (disposing)
                {
                    _safeHandle?.Dispose();
                    _safeHandle = null;
                }

                _disposedValue = true;
            }

            // Call base class implementation.
            base.Dispose(disposing);
        }
    }

    /// <summary>
    /// <a href="https://learn.microsoft.com/zh-cn/dotnet/standard/garbage-collection/using-objects">使用实现 IDisposable 的对象</a>
    /// </summary>
    class UseObjectsThatImplementIDisposable
    {
        /// <summary>
        /// <a href="https://learn.microsoft.com/zh-cn/dotnet/standard/garbage-collection/using-objects#tryfinally-block">try/finally</a>
        /// </summary>
        [Test]
        public void TryFinally()
        {
            var buffer = new char[50];
            StreamReader?
                reader1 = null,
                reader2 = null;
            try
            {
                reader1 = new("file1.txt");
                reader2 = new("file2.txt");
                int charsRead1, charsRead2 = 0;
                while (reader1.Peek() != -1 && reader2.Peek() != -1)
                {
                    charsRead1 = reader1.Read(buffer, 0, buffer.Length);
                    charsRead2 = reader2.Read(buffer, 0, buffer.Length);
                    //
                    // Process characters read.
                    //
                }
            }
            finally
            {
                // If non-null, call the object's Dispose method.
                reader1?.Dispose();
                reader2?.Dispose();
            }
        }

        /// <summary>
        /// <a href="https://learn.microsoft.com/zh-cn/dotnet/standard/garbage-collection/using-objects#the-using-statement">using 语句</a>
        /// 清理对象的简化代码
        /// </summary>
        [Test]
        public void TheUsingStatement()
        {
            var buffer = new char[50];
            // 允许在单个语句中获取多个资源，它们将按声明的相反顺序释放
            using StreamReader
                reader1 = new("file1.txt"),
                reader2 = new("file2.txt");
            int charsRead1, charsRead2 = 0;
            while (reader1.Peek() != -1 && reader2.Peek() != -1)
            {
                charsRead1 = reader1.Read(buffer, 0, buffer.Length);
                charsRead2 = reader2.Read(buffer, 0, buffer.Length);
                //
                // Process characters read.
                //
            }
        }
    }
}
