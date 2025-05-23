namespace dotnetTest.API.System;

/// <summary>
/// <a href="https://learn.microsoft.com/zh-cn/dotnet/api/system.nullable-1"><see cref="Nullable{T}"/> Struct</a>
/// 表示一个可以赋值为 null 的值类型
/// </summary>
public class NullableStructTests
{
    [Test]
    public void Test()
    {
        int? c = 1;
        // 检索当前 Nullable<T> 对象的值，或基础类型的默认值
        Assert.That(c.GetValueOrDefault(), Is.EqualTo(1));
        c = null;
        Assert.That(c.GetValueOrDefault(), Is.EqualTo(0));
    }
}
