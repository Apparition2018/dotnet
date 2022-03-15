using System.IO;

namespace dotnet3.L
{
    public class Demo
    {
        protected static int[] Ints = {1, 2, 3, 4, 5, 6, 7, 8, 9};
        protected const string HelloWorld = "Hello World!";
        protected const string DividingLine = "--------------------";

        protected static readonly string DotNet3Path =
            Path.Combine("D:", "Liang", "git", "dotnet", "dotnet3", "dotnet3");

        protected static readonly string StartUpPath = Path.Combine(DotNet3Path, "Startup.cs");
        protected static readonly string MyDirPath = Path.Combine(DotNet3Path, "L");
        protected static readonly string DemoPath = Path.Combine(MyDirPath, "demo");
    }
}