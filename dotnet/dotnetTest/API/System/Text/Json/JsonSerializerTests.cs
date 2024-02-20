using System.Text.Json;
using dotnet.L.Demo;
using dotnetTest.API.System.Text.Json.Nodes;

namespace dotnetTest.API.System.Text.Json;

/// <summary>
/// <a href="https://learn.microsoft.com/zh-cn/dotnet/api/system.text.json.jsonserializer">JsonSerializer</a>
/// </summary>
public class JsonSerializerTests : Demo
{
    private string? _json;

    /// <summary>序列化和反序列化</summary>
    [SetUp]
    public void SerializeAndDeserialize()
    {
        // static string        Serialize<TValue>(TValue value, JsonSerializerOptions? options = null)
        // 将泛型类型参数指定的类型的值转换为 JSON 字符串
        _json = JsonSerializer.Serialize(PersonList[0], SerializerOptions);
        // static TValue?       Deserialize<TValue>([StringSyntax("Json")] string json, JsonSerializerOptions? options = null)
        // 将表示单个 JSON 值的文本分析为泛型类型参数指定的类型的实例
        JsonSerializer.Deserialize<Person>(_json);
    }

    /// <summary>转换为</summary>
    /// <seealso cref="JsonNodeTests"/>
    [Test]
    public void SerializeTo()
    {
    }

    /// <summary>将 JSON 写入 Writer</summary>
    [Test]
    public void WriteJsonToWriter()
    {
        using FileStream fileStream = File.OpenWrite(DesktopDemoFilePath);

        // static void          Serialize<TValue>(Utf8JsonWriter writer, TValue value, JsonSerializerOptions? options = null)
        // 将泛型类型参数指定的类型的 JSON 表示形式写入提供的 Writer
        JsonSerializer.Serialize(
            new Utf8JsonWriter(fileStream, new JsonWriterOptions
            {
                SkipValidation = true,
                Indented = true
            }),
            _json
        );
    }

    [TearDown]
    public void TearDown()
    {
        File.Delete(DesktopDemoFilePath);
    }
}
