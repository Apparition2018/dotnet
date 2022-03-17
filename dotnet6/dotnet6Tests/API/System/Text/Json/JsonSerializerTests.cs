using System.Text.Json;
using System.Text.Json.Serialization;
using dotnet6.L;
using NUnit.Framework;

namespace dotnet6Tests.API.System.Text.Json;

public class JsonSerializerTests : Demo
{
    [Test]
    public void Test()
    {
        JsonSerializerOptions options = new JsonSerializerOptions
            {DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull};

        string serialize = JsonSerializer.Serialize(PersonList[0], options);
        Console.WriteLine(serialize);
        Console.WriteLine(JsonSerializer.Deserialize<Person>(serialize));

        Console.WriteLine(JsonSerializer.SerializeToNode(PersonList[0], options));
    }

    [Test]
    public void Test2()
    {

    }
}