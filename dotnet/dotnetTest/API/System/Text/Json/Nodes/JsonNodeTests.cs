using System.Text.Json;
using System.Text.Json.Nodes;
using dotnet.L.Demo;

namespace dotnetTest.API.System.Text.Json.Nodes;

/// <summary>
/// <a href="https://learn.microsoft.com/zh-cn/dotnet/api/system.text.json.nodes.jsonnode">JsonNode</a>
/// </summary>
public class JsonNodeTests : Demo
{
    [Test]
    public void Test()
    {
        // static JsonNode?     SerializeToNode<TValue>(TValue value, JsonSerializerOptions? options = null)
        // 将提供的值转换为 JsonNode
        JsonNode jsonNode = JsonSerializer.SerializeToNode(Persons[0], SerializerOptions)!;
    }
}
