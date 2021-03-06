namespace dotnet6.L;

// 基本序列化
// https://docs.microsoft.com/zh-cn/dotnet/standard/serialization/basic-serialization
[Serializable]
public class Person : ICloneable
{
    public int Id
        // 自动实现的属性 (Auto-Implemented Properties)
        // https://docs.microsoft.com/zh-cn/dotnet/csharp/programming-guide/classes-and-structs/auto-implemented-properties
    {
        get;
        set;
    }

    // null 包容运算符 (null-forgiving operator)
    // https://docs.microsoft.com/zh-cn/dotnet/csharp/language-reference/operators/null-forgiving
    public string Name { get; set; } = null!;
    public int? Age { get; set; }
    public string? Gender { get; set; }
    public IEnumerable<string>? OtherInfo { get; set; }
    public Home? Home { get; set; }

    public object Clone()
    {
        return MemberwiseClone();
    }

    // Generate Formatting Members
    // https://www.jetbrains.com/help/rider/Code_Generation__Formatting_Members.html
    public override string ToString()
    {
        return $"{nameof(Id)}: {Id}, {nameof(Name)}: {Name}, {nameof(Age)}: {Age}, {nameof(Gender)}: {Gender}, {nameof(OtherInfo)}: {OtherInfo}, {nameof(Home)}: {Home}";
    }
}

[Serializable]
public class Home
{
    public string Address { get; set; } = null!;
    public string Tel { get; set; } = null!;

    public override string ToString()
    {
        return $"{nameof(Address)}: {Address}, {nameof(Tel)}: {Tel}";
    }
}