using System.Text;
using dotnet.L.Demo;

namespace dotnetTest.API.System.IO;

/// <summary>
/// <a href="https://learn.microsoft.com/zh-cn/dotnet/api/system.io.stream">Stream</a>
/// </summary>
public class Stream : Demo
{
    /// <summary>
    /// <a href="https://learn.microsoft.com/zh-cn/dotnet/api/system.io.filestream">FileStream</a>
    /// 为文件提供 Stream，既支持同步读写操作，也支持异步读写操作
    /// </summary>
    [Test]
    public void FileStream()
    {
        // static FileStream    OpenWrite(string path)
        // 打开现有文件或创建新文件进行写入
        using (FileStream fileStream = File.OpenWrite(DesktopDemoFilePath))
        {
            Assert.That(fileStream.Name, Is.EqualTo(DesktopDemoFilePath));

            AddText(fileStream, "a");
            AddText(fileStream, "bc");
            AddText(fileStream, $"{Environment.NewLine}def");
            AddText(fileStream, $"{Environment.NewLine}ghi{Environment.NewLine}");
        }

        // static FileStream    OpenRead(string path)
        // 打开现有文件进行读取
        using (FileStream fileStream = File.OpenRead(DesktopDemoFilePath))
        {
            byte[] b = new byte[1024];
            UTF8Encoding temp = new UTF8Encoding(true);
            int readLen;
            // int              Read(byte[] buffer, int offset, int count)
            // 从流中读取字节块，并将数据写入给定的缓冲区中
            while ((readLen = fileStream.Read(b,0,b.Length)) > 0)
            {
                Console.WriteLine(temp.GetString(b,0,readLen));
            }
        }
    }

    private static void AddText(FileStream fs, string value)
    {
        byte[] info = new UTF8Encoding(true).GetBytes(value);
        // void                 Write(byte[] buffer, int offset, int count)
        // 将字节块写入文件流
        fs.Write(info, 0, info.Length);
    }

    [TearDown]
    public void TearDown()
    {
        File.Delete(DesktopDemoFilePath);
    }
}
