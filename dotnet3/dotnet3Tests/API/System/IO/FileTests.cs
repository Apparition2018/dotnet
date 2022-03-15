using System.IO;
using System.Text;
using dotnet3.L;
using NUnit.Framework;

namespace dotnet3Tests.API.System.IO
{
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
    }
}