using System.Runtime.Serialization;
using System.Text;

namespace dotnetTest.API.System.Runtime.Serialization;

/// <summary>
/// <a href="https://learn.microsoft.com/zh-cn/dotnet/api/system.runtime.serialization.datacontractserializer">DataContractSerializer</a>
/// 使用提供的数据协定，将类型实例序列化和反序列化为 XML 流或文档
/// </summary>
public class DataContractSerializerTests
{
    [Test]
    public void Test()
    {
        Person person = new Person("John Doe", 30);

        // 序列化到内存流
        using MemoryStream stream = new MemoryStream();
        DataContractSerializer serializer = new DataContractSerializer(typeof(Person));
        serializer.WriteObject(stream, person);

        // 将内存流的内容转换为字符串（可选，仅用于演示）
        stream.Position = 0;
        using StreamReader reader = new StreamReader(stream);
        string xmlString = reader.ReadToEnd();
        Console.WriteLine(xmlString);

        // 反序列化
        using MemoryStream stream2 = new MemoryStream(Encoding.UTF8.GetBytes(xmlString));
        person = (Person)serializer.ReadObject(stream2)!;
        Console.WriteLine($"Deserialized Name: {person.Name}, Age: {person.Age}");
    }

    [DataContract(Namespace = "http://example.com/contracts")]
    private class Person(string name, int age)
    {
        [DataMember] public string Name { get; set; } = name;

        [DataMember] public int Age { get; set; } = age;
    }
}
