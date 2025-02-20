using System.Text;

namespace dotnetTest.Guide.AsynchronousPrograming;

/// <summary>
/// <a href="https://learn.microsoft.com/zh-cn/dotnet/csharp/asynchronous-programming/using-async-for-file-access">异步文件访问</a>
/// </summary>
public abstract class AsynchronousFileAccess
{
    private const string FilePath = "simple.txt";
    private const string TempFolderPath = "simple.txt";

    /// <summary>写入文本</summary>
    class WriteText
    {
        /// <summary>简单示例</summary>
        [Test]
        public async Task SimpleWriteAsync()
        {
            string text = "Hello World";
            await File.WriteAllTextAsync(FilePath, text);
        }

        /// <summary>有限控制示例</summary>
        [Test]
        public async Task ProcessWriteAsync()
        {
            string text = $"Hello World{Environment.NewLine}";
            await WriteTextAsync(FilePath, text);
        }

        async Task WriteTextAsync(string filePath, string text)
        {
            byte[] encodedText = Encoding.Unicode.GetBytes(text);

            await using var sourceStream =
                new FileStream(
                    filePath,
                    FileMode.Create, FileAccess.Write, FileShare.None,
                    bufferSize: 4096, useAsync: true);

            await sourceStream.WriteAsync(encodedText, 0, encodedText.Length);
        }
    }

    /// <summary>读取文本</summary>
    class ReadText
    {
        /// <summary>简单示例</summary>
        [Test]
        public async Task SimpleReadAsync()
        {
            string text = await File.ReadAllTextAsync(FilePath);
            Console.WriteLine(text);
        }

        /// <summary>有限控制示例</summary>
        [Test]
        public async Task ProcessReadAsync()
        {
            try
            {
                if (File.Exists(FilePath))
                {
                    string text = await ReadTextAsync(FilePath);
                    Console.WriteLine(text);
                }
                else
                {
                    Console.WriteLine($"file not found: {FilePath}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        async Task<string> ReadTextAsync(string filePath)
        {
            await using var sourceStream =
                new FileStream(
                    filePath,
                    FileMode.Open, FileAccess.Read, FileShare.Read,
                    bufferSize: 4096, useAsync: true);

            var sb = new StringBuilder();

            byte[] buffer = new byte[0x1000];
            int numRead;
            while ((numRead = await sourceStream.ReadAsync(buffer, 0, buffer.Length)) != 0)
            {
                string text = Encoding.Unicode.GetString(buffer, 0, numRead);
                sb.Append(text);
            }

            return sb.ToString();
        }
    }

    /// <summary>并行 I/O</summary>
    class ParallelAsynchronousIo
    {
        /// <summary>简单示例</summary>
        [Test]
        public async Task SimpleParallelWriteAsync()
        {
            string folder = Directory.CreateDirectory(TempFolderPath).Name;
            IList<Task> writeTaskList = new List<Task>();

            for (int index = 11; index <= 20; ++index)
            {
                string fileName = $"file-{index:00}.txt";
                string filePath = $"{folder}/{fileName}";
                string text = $"In file {index}{Environment.NewLine}";

                writeTaskList.Add(File.WriteAllTextAsync(filePath, text));
            }

            await Task.WhenAll(writeTaskList);
        }

        /// <summary>有限控制示例</summary>
        [Test]
        public async Task ProcessMultipleWritesAsync()
        {
            string folder = Directory.CreateDirectory(TempFolderPath).Name;
            IList<Task> writeTaskList = new List<Task>();

            for (int index = 1; index <= 10; ++index)
            {
                string fileName = $"file-{index:00}.txt";
                string filePath = $"{folder}/{fileName}";
                string text = $"In file {index}{Environment.NewLine}";
                byte[] encodedText = Encoding.Unicode.GetBytes(text);

                writeTaskList.Add(WriteToFileAsync(filePath, encodedText));
            }

            await Task.WhenAll(writeTaskList);
        }

        private async Task WriteToFileAsync(string filePath, byte[] data)
        {
            await using FileStream sourceStream = new FileStream(
                filePath,
                FileMode.Create, FileAccess.Write, FileShare.None,
                bufferSize: 4096, useAsync: true);
            await sourceStream.WriteAsync(data, 0, data.Length);
        }
    }
}
