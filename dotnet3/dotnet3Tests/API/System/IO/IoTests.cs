using System.Globalization;
using System.IO;
using dotnet3.L;
using NUnit.Framework;

namespace dotnet3Tests.API.System.IO
{
    public class IoTests : Demo
    {
        [Test]
        public void DirectoryInfo()
        {
            DirectoryInfo info = new DirectoryInfo(DotNet3Path);
            Assert.AreEqual(info.Name, "dotnet3");
            Assert.AreEqual(info.FullName, @"D:\Liang\git\dotnet\dotnet3\dotnet3");
            Assert.AreEqual(info.CreationTime.ToString(CultureInfo.CurrentCulture), "2022/3/13 19:41:05");
        }

        [Test]
        public void FileInfo()
        {
            FileInfo info = new FileInfo(StartUpPath);
            Assert.AreEqual(info.Name, "Startup.cs");
            Assert.AreEqual(info.FullName, @"D:\Liang\git\dotnet\dotnet3\dotnet3\Startup.cs");
            Assert.AreEqual(info.DirectoryName, @"D:\Liang\git\dotnet\dotnet3\dotnet3");
            Assert.AreEqual(info.Extension, ".cs");
            Assert.AreEqual(info.CreationTime.ToString(CultureInfo.CurrentCulture), "2022/3/13 19:41:05");
        }
    }
}