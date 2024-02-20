namespace dotnet.L.Demo;

/// <summary>Days</summary>
/// <remarks>
/// <a href="https://learn.microsoft.com/zh-cn/dotnet/csharp/language-reference/builtin-types/enum#enumeration-types-as-bit-flags">作为位标志的枚举类型</a>
/// </remarks>
[Flags]
public enum Days
{

    /// <summary>无</summary>
    None      = 0b_0000_0000,
    /// <summary>周一</summary>
    Monday    = 0b_0000_0001,
    /// <summary>周二</summary>
    Tuesday   = 0b_0000_0010,
    /// <summary>周三</summary>
    Wednesday = 0b_0000_0100,
    /// <summary>周四</summary>
    Thursday  = 0b_0000_1000,
    /// <summary>周五</summary>
    Friday    = 0b_0001_0000,
    /// <summary>周六</summary>
    Saturday  = 0b_0010_0000,
    /// <summary>周日</summary>
    Sunday    = 0b_0100_0000,
    /// <summary>周末</summary>
    Weekend   = Saturday | Sunday
}
