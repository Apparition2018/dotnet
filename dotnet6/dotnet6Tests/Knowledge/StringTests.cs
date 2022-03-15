using System;
using NUnit.Framework;

namespace dotnet6Tests.Knowledge;

public class String
{
    /// <summary>逐字字符串字面量</summary>
    [Test]
    public void VerbatimStringLiteral()
    {
        Console.WriteLine(@"    C:\source\repos
                    (this is where your code goes)");
    }

    /// <summary>字符串内插</summary>
    [Test]
    public void StringInterpolation()
    {
        string firstName = "Bob";
        string greeting = "Hello";
        Console.WriteLine($"{greeting} {firstName}!");
    }

    [Test]
    public void Test()
    {
        string projectName = "First-Project";
        Console.WriteLine($@"C:\Output\{projectName}\Data");
    }
}