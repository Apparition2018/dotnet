using System.Text.Json.Serialization;

namespace dotnet.L.Demo;

// 基本序列化 (Basic serialization)
// https://learn.microsoft.com/zh-cn/dotnet/standard/serialization/basic-serialization
[Serializable]
public class Person : ICloneable
{
    public int ID
        // 自动实现属性 (Auto-Implemented Properties)
        // https://learn.microsoft.com/zh-cn/dotnet/csharp/programming-guide/classes-and-structs/auto-implemented-properties
    {
        get;
        set;
    }

    public string Name { get; set; } = null!;
    public int? Age { get; set; }
    [JsonPropertyName("sex")] public string? Gender { get; set; }
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
        return
            $"{nameof(ID)}: {ID}, {nameof(Name)}: {Name}, {nameof(Age)}: {Age}, {nameof(Gender)}: {Gender}, {nameof(OtherInfo)}: {OtherInfo}, {nameof(Home)}: {Home}";
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
