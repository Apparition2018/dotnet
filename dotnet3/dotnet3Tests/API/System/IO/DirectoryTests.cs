using System;
using System.Collections.Generic;
using System.IO;
using dotnet3.L;
using NUnit.Framework;

namespace dotnet3Tests.API.System.IO
{
    public class DirectoryTests : Demo
    {
        [Test]
        public void Test()
        {
            // static string        GetCurrentDirectory()           获取当前文件夹路径
            Assert.AreEqual(Directory.GetCurrentDirectory(),
                @"D:\Liang\git\dotnet\dotnet3\dotnet3Tests\bin\Debug\netcoreapp3.1");


            string dirPath = Path.Combine(MyDirPath, "a", "b", "c");
            // static DirectoryInfo CreateDirectory(string path)    创建指定路径中的所有目录
            Directory.CreateDirectory(dirPath);
            // static bool          Exists(string path)             判断目录是否存在
            Assert.AreEqual(Directory.Exists(dirPath), true);
            // static void          Delete(string path, bool recursive)
            // 删除指定目录以及目录中的任何子目录和文件
            Directory.Delete(Path.Combine(MyDirPath, "a"), true);
        }

        [Test]
        public void Enumerate()
        {
            // static IEnumerable<string>   EnumerateDirectories(string path, string searchPattern, SearchOption searchOption)
            IEnumerable<string> enumerateDirectories =
                Directory.EnumerateDirectories(DotNet3Path, "*", SearchOption.AllDirectories);
            foreach (var dir in enumerateDirectories)
            {
                Console.WriteLine(dir);
            }

            Console.WriteLine(DividingLine);

            IEnumerable<string> files = Directory.EnumerateFiles(DotNet3Path);
            foreach (var file in files)
            {
                Console.WriteLine(file);
            }
        }
    }
}