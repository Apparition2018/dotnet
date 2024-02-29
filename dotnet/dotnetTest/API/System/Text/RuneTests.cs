using System.Text;
using dotnetTest.Fundamentals.RuntimeLibraries.WorkWithStrings;

namespace dotnetTest.API.System.Text;

/// <summary>
/// <a href="https://learn.microsoft.com/zh-cn/dotnet/api/system.text.rune">Rune 结构</a>
/// <see cref="CharacterEncoding.UnicodeScalarValues">Unicode 标量值</see>（[ U+0000..U+D7FF ]，[ U+E000..U+10FFFF ]）
/// </summary>
public class RuneTests
{
    [Test]
    public void Test()
    {
        Rune rune = new Rune('a');
        Assert.That(rune.Value, Is.EqualTo('a'));
        Assert.That(rune.IsAscii, Is.EqualTo(true));
        Assert.That(rune.IsBmp, Is.EqualTo(true));
        Assert.That(rune.Utf16SequenceLength, Is.EqualTo(1));
        Assert.That(Rune.IsLetter(rune), Is.EqualTo(true));
        Assert.That(Rune.IsLetterOrDigit(rune), Is.EqualTo(true));
        Assert.That(Rune.IsWhiteSpace(rune), Is.EqualTo(false));
        Assert.That(Rune.ToUpperInvariant(rune).Value, Is.EqualTo('A'));
        Assert.That(Rune.GetUnicodeCategory(rune).ToString(), Is.EqualTo("LowercaseLetter"));
        Assert.That(Rune.GetUnicodeCategory(new Rune('1')).ToString(), Is.EqualTo("DecimalDigitNumber"));

        Assert.Throws<ArgumentOutOfRangeException>(() =>
        {
            // \ud801 不是 Unicode 标量值
            rune = new Rune('\ud801');
        });

    }
}
