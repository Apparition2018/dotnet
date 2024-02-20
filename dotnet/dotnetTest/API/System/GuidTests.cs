namespace dotnetTest.API.System;

/// <summary>
/// <a href="https://learn.microsoft.com/zh-cn/dotnet/api/system.guid">Guid</a>
/// </summary>
public class GuidTests
{
    [Test]
    public void Test()
    {
        // ToString
        Guid guid = Guid.NewGuid();
        Console.WriteLine(guid.ToString("N")); // f0bd4488b6de4066b076064da7e29fbd
        Console.WriteLine(guid.ToString("D")); // f0bd4488-b6de-4066-b076-064da7e29fbd
        Console.WriteLine(guid.ToString("P")); // (f0bd4488-b6de-4066-b076-064da7e29fbd)
        Console.WriteLine(guid.ToString("B")); // {f0bd4488-b6de-4066-b076-064da7e29fbd}
        Console.WriteLine(guid.ToString("X")); // {0xf0bd4488,0xb6de,0x4066,{0xb0,0x76,0x06,0x4d,0xa7,0xe2,0x9f,0xbd}}
    }
}
