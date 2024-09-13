using System.Text.Json.Serialization;

namespace dotnet.L.Demo;

// SerializableAttribute：指示可以使用二进制或 XML 序列化对类进行序列化
// https://learn.microsoft.com/zh-cn/dotnet/api/system.serializableattribute
[Serializable]
public class Person : ICloneable
{
    public int ID
        // 自动实现的属性 (Auto-Implemented Properties)
        // https://learn.microsoft.com/zh-cn/dotnet/csharp/programming-guide/classes-and-structs/auto-implemented-properties
    {
        get;
        set;
    }

    public string Name { get; set; } = null!;
    public int? Age { get; set; }

    // JsonPropertyNameAttribute：指定序列化和反序列化时 JSON 中存在的属性名称
    // https://learn.microsoft.com/zh-cn/dotnet/api/system.text.json.serialization.jsonpropertynameattribute
    [JsonPropertyName("sex")]
    public string? Gender { get; set; }
    public IEnumerable<string>? OtherInfo { get; set; }
    public Home? Home { get; set; }

    public void Deconstruct(out int id, out string name, out int? age)
    {
        id = ID;
        name = Name;
        age = Age;
    }

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
