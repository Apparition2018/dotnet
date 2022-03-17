using System.Text;
using System.Text.Json;
using dotnet6.L;
using NUnit.Framework;

namespace dotnet6Tests.API.System.IO;

public class FileTests : Demo
{
    [Test]
    public void Test()
    {
        // static void          WriteAllText(string path, string contents, Encoding encoding)
        // 创建一个文件并使用指定的编码写入内容，然后关闭文件。如果文件已存在，则将其覆盖
        File.WriteAllText(DemoPath, "demo", Encoding.UTF8);
        // static string        ReadAllText(string path, Encoding encoding)
        // 使用指定的编码读取文本，然后关闭文件
        Assert.AreEqual(File.ReadAllText(DemoPath, Encoding.UTF8), "demo");
        // static void          AppendAllText(string path, string contents, Encoding encoding)
        // 使用指定的编码将指定的字符串附加到文件中，如果文件不存在则创建该文件
        File.AppendAllText(DemoPath, "demo", Encoding.UTF8);
        // static void          Delete(string path)             删除指定文件
        File.Delete(DemoPath);
    }

    [Test]
    public void Test2()
    {
        // static FileStream    OpenWrite(string path)
        // 打开现有文件或创建新文件以进行写入
        FileStream fileStream = File.OpenWrite(DemoPath);
        // 将由泛型类型参数指定的类型的 JSON 表示形式写入提供的 Writer
        JsonSerializer.Serialize(new Utf8JsonWriter(fileStream,
                new JsonWriterOptions
                {
                    SkipValidation = true,
                    Indented = true
                }),
            "demo"
        );
        fileStream.Close();

        // static StreamReader  OpenText(string path)
        // 打开现有的 UTF-8 编译文本文件进行读取
        StreamReader streamReader = File.OpenText(DemoPath);
        // string               ReadToEnd()
        // 读取从当前位置到流末尾的所有字符
        Console.WriteLine(streamReader.ReadToEnd());
    }
}