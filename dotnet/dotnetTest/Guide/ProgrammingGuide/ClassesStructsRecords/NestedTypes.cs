namespace dotnetTest.Guide.ProgrammingGuide.ClassesStructsRecords;

/// <summary>
/// <a href="https://learn.microsoft.com/zh-cn/dotnet/csharp/programming-guide/classes-and-structs/nested-types">嵌套类型</a>
/// 在 class、struct、interface 中定义的类型称为嵌套类型，默认为 private。
/// </summary>
public class NestedTypes
{
    /// <summary>outer type</summary>
    public class Container
    {
        /// <summary>inner type</summary>
        public class Nested
        {
            private Container? _parent;

            public Nested() { }

            /// 要访问 outer type，将其作为参数传递给 inner type 的构造函数
            public Nested(Container parent)
            {
                this._parent = parent;
            }
        }
    }

    [Test]
    public void Test()
    {
        // 类 Nested 的完整名称为 Container.Nested
        Container.Nested nest = new Container.Nested();
    }
}
