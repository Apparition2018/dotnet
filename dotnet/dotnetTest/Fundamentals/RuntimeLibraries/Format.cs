using System.Globalization;
using dotnetTest.Guide.LanguageReference;

namespace dotnetTest.Fundamentals.RuntimeLibraries;

/// <summary>
/// <a href="https://learn.microsoft.com/zh-cn/dotnet/standard/base-types/formatting-types">如何在 .NET 中设置数字、日期、枚举和其他类型的格式</a>
/// <para>
/// 格式设置的基本机制是 Object.ToString 方法的默认实现
/// <list type="bullet">
/// <item><a href="https://learn.microsoft.com/zh-cn/dotnet/standard/base-types/formatting-types#override-the-tostring-method">重写 Object.ToString 方法</a></item>
/// <item><see cref="FormatStrings">格式说明符（格式字符串）</see>：允许对象值的字符串采用多种形式表示</item>
/// <item><a href="https://learn.microsoft.com/zh-cn/dotnet/standard/base-types/formatting-types#culture-sensitive-formatting-with-format-providers">使用格式提供程序来实现特定区域性的格式设置约定</a></item>
/// <item>实现 <see cref="IFormattable">IFormattable</see> 接口可以支持使用 Convert 类的字符串转换以及复合格式设置</item>
/// <item>使用<see cref="CompositeFormatting">复合格式设置</see>来嵌入较大字符串中值的字符串表示形式</item>
/// <item>使用 <see cref="SpecialCharacters.StringInterpolation">字符串内插</see>（一种更易于理解的语法）将值的字符串表示形式嵌入更大的字符串中</item>
/// <item>实现 <see cref="ICustomFormatter">ICustomFormatter</see> 和 IFormatProvider 可以提供完全自定义的格式设置解决方案</item>
/// </list>
/// </para>
/// </summary>
public class Format
{
    private readonly DateTimeFormatInfo _formatInfo = DateTimeFormatInfo.InvariantInfo;

    /// <summary>
    /// <a href="https://learn.microsoft.com/zh-cn/dotnet/standard/base-types/formatting-types#the-tostring-method-and-format-strings">ToString 方法和格式字符串</a>
    /// <list type="bullet">
    /// <item>标准格式字符串：<see cref="StandardNumericFormatStrings"/> <see cref="StandardDateAndTimeFormatStrings"/> <see cref="EnumerationFormatStrings"/></item>
    /// <item>自定义格式字符串：<see cref="CustomNumericFormatStrings"/> <see cref="CustomDateAndTimeFormatStrings"/></item>
    /// </list>
    /// </summary>
    [Test]
    public void FormatStrings() { }

    /// <summary>
    /// <a href="https://learn.microsoft.com/zh-cn/dotnet/standard/base-types/formatting-types#the-iformattable-interface">IFormattable 接口</a>
    /// <list type="number">
    /// <item>支持使用 Convert 类进行字符串转换</item>
    /// <item>支持复合格式设置</item>
    /// </list>
    /// </summary>
    class IFormattable_
    {
        class Temperature(decimal temperature) : IFormattable
        {
            private decimal Celsius => temperature;

            private decimal Kelvin => temperature + 273.15m;

            private decimal Fahrenheit => Math.Round(temperature * 9 / 5 + 32, 2);

            public override string ToString()
            {
                return ToString("G", null);
            }

            public string ToString(string format)
            {
                return ToString(format, null);
            }

            public string ToString(string? format, IFormatProvider? provider)
            {
                // Handle null or empty arguments.
                if (string.IsNullOrEmpty(format))
                    format = "G";
                // Remove any white space and covert to uppercase.
                format = format.Trim().ToUpperInvariant();

                provider ??= NumberFormatInfo.CurrentInfo;

                switch (format)
                {
                    // Convert temperature to Fahrenheit and return string.
                    case "F":
                        return Fahrenheit.ToString("N2", provider) + "°F";
                    // Convert temperature to Kelvin and return string.
                    case "K":
                        return Kelvin.ToString("N2", provider) + "K";
                    // Return temperature in Celsius.
                    case "C":
                    case "G":
                        return Celsius.ToString("N2", provider) + "°C";
                    default:
                        throw new FormatException($"The '{format}' format string is not supported.");
                }
            }
        }

        [Test]
        public void Test()
        {
            CultureInfo.CurrentCulture = CultureInfo.GetCultureInfo("en-US");
            Temperature temp = new Temperature(22m);
            Assert.That(Convert.ToString(temp, new CultureInfo("ja-JP")), Is.EqualTo("22.00°C"));
            Assert.That($"{temp:K}", Is.EqualTo("295.15K"));
            Assert.That($"{temp:F}", Is.EqualTo("71.60°F"));
            CultureInfo.CurrentCulture = CultureInfo.GetCultureInfo("fr-FR");
            Assert.That($"{temp:F}", Is.EqualTo("71,60°F"));
        }
    }

    /// <summary>
    /// <a href="https://learn.microsoft.com/zh-cn/dotnet/standard/base-types/formatting-types#custom-formatting-with-icustomformatter">使用 ICustomFormatter 进行自定义格式设置</a>
    /// </summary>
    class ICustomFormatter_;

    /// <summary>
    /// <a href="https://learn.microsoft.com/zh-cn/dotnet/standard/base-types/standard-numeric-format-strings">标准数字格式字符串</a>
    /// 格式化通用数值类型
    /// <para>
    /// 采用 [format specifier][precision specifier] 的形式，其中：
    /// <list type="bullet">
    /// <item><a href="https://learn.microsoft.com/zh-cn/dotnet/standard/base-types/standard-numeric-format-strings#standard-format-specifiers">格式说明符</a> (format specifier)：数字格式类型的单个字母字符，例如货币或百分比</item>
    /// <item>精度说明符 (precision specifier)：一个可选整数，影响生成的字符串中的位数</item>
    /// </list>
    /// </para>
    /// <para>
    /// <a href="https://learn.microsoft.com/zh-cn/dotnet/standard/base-types/standard-numeric-format-strings#use-standard-numeric-format-strings">使用标准数字格式字符串</a>：
    /// <list type="bulltet">
    /// <item>所有数字类型的一些 ToString 方法重载</item>
    /// <item>所有数值类型的 TryFormat 方法</item>
    /// <item>.NET <see cref="CompositeFormatting">复合格式功能</see></item>
    /// <item><see cref="SpecialCharacters.StringInterpolation">内插的字符串</see></item>
    /// </list>
    /// </para>
    /// </summary>
    [Test]
    public void StandardNumericFormatStrings()
    {
        CultureInfo ci = new CultureInfo("en-us");

        double f = 10761.937554;
        Assert.That($"C:货币 {f.ToString("C", ci)}", Is.EqualTo("C:货币 $10,761.94"));
        Assert.That($"E:指数 {f.ToString("E03", ci)}", Is.EqualTo("E:指数 1.076E+004"));
        Assert.That($"F:定点 {f.ToString("F04", ci)}", Is.EqualTo("F:定点 10761.9376"));
        Assert.That($"G:常规 {f.ToString("G", ci)}", Is.EqualTo("G:常规 10761.937554"));
        Assert.That($"N:数字 {f.ToString("N03", ci)}", Is.EqualTo("N:数字 10,761.938"));
        Assert.That($"P:百分比 {(f / 10000).ToString("P02", ci)}", Is.EqualTo("P:百分比 107.62%"));
        Assert.That($"R:往返过程 {f.ToString("R", ci)}", Is.EqualTo("R:往返过程 10761.937554"));

        int i = 8395;
        Assert.That($"C:货币 {i.ToString("C", ci)}", Is.EqualTo("C:货币 $8,395.00"));
        Assert.That($"D:十进制 {i.ToString("D6", ci)}", Is.EqualTo("D:十进制 008395"));
        Assert.That($"E:指数 {i.ToString("E03", ci)}", Is.EqualTo("E:指数 8.395E+003"));
        Assert.That($"F:定点 {i.ToString("F01", ci)}", Is.EqualTo("F:定点 8395.0"));
        Assert.That($"G:常规 {i.ToString("G", ci)}", Is.EqualTo("G:常规 8395"));
        Assert.That($"N:数字 {i.ToString("N01", ci)}", Is.EqualTo("N:数字 8,395.0"));
        Assert.That($"P:百分比 {(i / 10000.0).ToString("P02", ci)}", Is.EqualTo("P:百分比 83.95%"));
        Assert.That($"X:十六进制 0x{i.ToString("X", ci)}", Is.EqualTo("X:十六进制 0x20CB"));
    }

    /// <summary>
    /// <a href="https://learn.microsoft.com/zh-cn/dotnet/standard/base-types/custom-numeric-format-strings">自定义数字格式字符串</a>
    /// </summary>
    [Test]
    public void CustomNumericFormatStrings()
    {
        // 0    零占位符
        // .    小数点
        // ,    组分隔符
        Assert.That(1.2.ToString("00.00"), Is.EqualTo("01.20"));
        Assert.That(1234.5678.ToString("0,0.00"), Is.EqualTo("1,234.57"));
        // #    数字占位符
        Assert.That(123456.ToString("#"), Is.EqualTo("123456"));
        Assert.That(123456.ToString("[##-##-##]"), Is.EqualTo("[12-34-56]"));
        // ,    数字比例换算
        Assert.That(1234567890.ToString("#,,,"), Is.EqualTo("1"));
        Assert.That(1234567890.ToString("#,,"), Is.EqualTo("1235"));
        // %    百分比占位符
        Assert.That(.086.ToString("#0.##%"), Is.EqualTo("8.6%"));
        // ‰    千分比占位符
        Assert.That(.086.ToString("#0.##‰"), Is.EqualTo("86‰"));
        // E    指数
        Assert.That(86000.ToString("0.###E+000"), Is.EqualTo("8.6E+004"));
        // ;    部分分隔符
        string fmt = "+;-;0";
        Assert.That(1.ToString(fmt), Is.EqualTo("+"));
        Assert.That((-1).ToString(fmt), Is.EqualTo("-"));
        Assert.That(0.ToString(fmt), Is.EqualTo("0"));
    }

    /// <summary>
    /// <a href="https://learn.microsoft.com/zh-cn/dotnet/standard/base-types/standard-date-and-time-format-strings">标准日期和时间格式字符串</a>
    /// 使用单个字符作为格式说明符来定义 DateTime 或 DateTimeOffset 值的文本表示形式。
    /// </summary>
    [Test]
    public void StandardDateAndTimeFormatStrings()
    {
        DateTime d = new DateTime(2008, 8, 8);

        Assert.That($"d:短日期 {d.ToString("d", _formatInfo)}", Is.EqualTo("d:短日期 08/08/2008"));
        Assert.That($"D:长日期 {d.ToString("D", _formatInfo)}", Is.EqualTo("D:长日期 Friday, 08 August 2008"));
        // f = D + t
        Assert.That($"f:完整日期短时间 {d.ToString("f", _formatInfo)}", Is.EqualTo("f:完整日期短时间 Friday, 08 August 2008 00:00"));
        Assert.That($"F:完整日期长时间 {d.ToString("F", _formatInfo)}", Is.EqualTo("F:完整日期长时间 Friday, 08 August 2008 00:00:00"));
        Assert.That($"g:常规日期短时间 {d.ToString("g", _formatInfo)}", Is.EqualTo("g:常规日期短时间 08/08/2008 00:00"));
        Assert.That($"G:常规日期长时间 {d.ToString("G", _formatInfo)}", Is.EqualTo("G:常规日期长时间 08/08/2008 00:00:00"));
        Assert.That($"s:可排序(ISO 8601) {d.ToString("s", _formatInfo)}", Is.EqualTo("s:可排序(ISO 8601) 2008-08-08T00:00:00"));
        Assert.That($"u:通用可排序 {d.ToString("u", _formatInfo)}", Is.EqualTo("u:通用可排序 2008-08-08 00:00:00Z"));
        Assert.That($"U:通用完整(UTC) {d.ToString("U", _formatInfo)}", Is.EqualTo("U:通用完整(UTC) Thursday, 07 August 2008 16:00:00"));
        Assert.That($"t:短时间 {d.ToString("t", _formatInfo)}", Is.EqualTo("t:短时间 00:00"));
        Assert.That($"T:长时间 {d.ToString("T", _formatInfo)}", Is.EqualTo("T:长时间 00:00:00"));
        Assert.That($"M/m:月日 {d.ToString("M", _formatInfo)}", Is.EqualTo("M/m:月日 August 08"));
        Assert.That($"Y/y:年月 {d.ToString("Y", _formatInfo)}", Is.EqualTo("Y/y:年月 2008 August"));
        Assert.That($"O/o:往返 {d.ToString("O", _formatInfo)}", Is.EqualTo("O/o:往返 2008-08-08T00:00:00.0000000"));
        Assert.That($"R/r:RFC1123 {d.ToString("R", _formatInfo)}", Is.EqualTo("R/r:RFC1123 Fri, 08 Aug 2008 00:00:00 GMT"));
    }

    /// <summary>
    /// <a href="https://learn.microsoft.com/zh-cn/dotnet/standard/base-types/custom-date-and-time-format-strings">自定义日期和时间格式字符串</a>
    /// 如果格式字符串仅包含一个自定义格式说明符，则此格式说明符前面应带有百分比 (%) 符号，或之后添加一个空格
    /// </summary>
    [Test]
    public void CustomDateAndTimeFormatStrings()
    {
        DateTime d = new DateTime(2024, 2, 28, 09, 21, 15);
        // 年
        Assert.That(d.ToString("%y", _formatInfo), Is.EqualTo("24"));
        Assert.That(d.ToString("yy", _formatInfo), Is.EqualTo("24"));
        Assert.That(d.ToString("yyy", _formatInfo), Is.EqualTo("2024"));
        Assert.That(d.ToString("yyyy", _formatInfo), Is.EqualTo("2024"));
        // 月
        Assert.That(d.ToString("%M", _formatInfo), Is.EqualTo("2"));
        Assert.That(d.ToString("MM", _formatInfo), Is.EqualTo("02"));
        Assert.That(d.ToString("MMM", _formatInfo), Is.EqualTo("Feb"));
        Assert.That(d.ToString("MMMM", _formatInfo), Is.EqualTo("February"));
        // 日
        Assert.That(d.ToString("%d", _formatInfo), Is.EqualTo("28"));
        Assert.That(d.ToString("dd", _formatInfo), Is.EqualTo("28"));
        Assert.That(d.ToString("ddd", _formatInfo), Is.EqualTo("Wed"));
        Assert.That(d.ToString("dddd", _formatInfo), Is.EqualTo("Wednesday"));
        // AM/PM
        Assert.That(d.ToString("%t", _formatInfo), Is.EqualTo("A"));
        Assert.That(d.ToString("tt", _formatInfo), Is.EqualTo("AM"));
        // 时
        Assert.That(d.ToString("%h", _formatInfo), Is.EqualTo("9"));
        Assert.That(d.ToString("hh", _formatInfo), Is.EqualTo("09"));
        Assert.That(d.ToString("%H", _formatInfo), Is.EqualTo("9"));
        Assert.That(d.ToString("HH", _formatInfo), Is.EqualTo("09"));
        // 分
        Assert.That(d.ToString("%m", _formatInfo), Is.EqualTo("21"));
        Assert.That(d.ToString("mm", _formatInfo), Is.EqualTo("21"));
        // 秒
        Assert.That(d.ToString("%s", _formatInfo), Is.EqualTo("15"));
        Assert.That(d.ToString("ss", _formatInfo), Is.EqualTo("15"));
        // 纪元
        Assert.That(d.ToString("gg", _formatInfo), Is.EqualTo("A.D."));

        DateTime n = DateTime.Now;
        // 偏移量
        Assert.That(d.ToString("%z", _formatInfo), Is.EqualTo("+8"));
        Assert.That(d.ToString("zz", _formatInfo), Is.EqualTo("+08"));
        Assert.That(d.ToString("zzz", _formatInfo), Is.EqualTo("+08:00"));
        // 时区
        Assert.That(n.ToString("%K", _formatInfo), Is.EqualTo("+08:00"));
    }

    /// <summary>
    /// <a href="https://learn.microsoft.com/zh-cn/dotnet/standard/base-types/enumeration-format-strings">枚举格式字符串</a>
    /// </summary>
    [Test]
    public void EnumerationFormatStrings()
    {
        var attributes = FileAttributes.Hidden | FileAttributes.Archive;
        // G        显示为字符串值，否则显示当前实例的整数值
        //          如果枚举使用 FlagsAttribute 集进行定义，则每个有效项的字符串值会连接在一起
        //          如果未设置 Flags 属性，则无效值显示为数字项
        Assert.That(((DayOfWeek)7).ToString("G"), Is.EqualTo("7"));
        Assert.That(ConsoleColor.Red.ToString("G"), Is.EqualTo("Red"));
        Assert.That(attributes.ToString("G"), Is.EqualTo("Hidden, Archive"));
        // F        显示为字符串值
        //          如果值可以显示为枚举中的项的合计（即使 Flags 属性不存在），则每个有效项的字符串值会连接在一起
        //          如果值不能由枚举项确定，则值会格式化为整数值
        Assert.That(((DayOfWeek)7).ToString("F"), Is.EqualTo("Monday, Saturday"));
        Assert.That(ConsoleColor.Red.ToString("F"), Is.EqualTo("Red"));
        Assert.That(attributes.ToString("F"), Is.EqualTo("Hidden, Archive"));
        // D        显示为整数值
        Assert.That(((DayOfWeek)7).ToString("D"), Is.EqualTo("7"));
        Assert.That(ConsoleColor.Red.ToString("D"), Is.EqualTo("12"));
        Assert.That(attributes.ToString("D"), Is.EqualTo("34"));
        // X        显示为十六进制值
        Assert.That(((DayOfWeek)7).ToString("X"), Is.EqualTo("00000007"));
        Assert.That(ConsoleColor.Red.ToString("X"), Is.EqualTo("0000000C"));
        Assert.That(attributes.ToString("X"), Is.EqualTo("00000022"));
    }

    /// <summary>
    /// <a href="https://learn.microsoft.com/zh-cn/dotnet/standard/base-types/composite-formatting">复合格式设置</a>
    /// 使用对象列表和复合格式字符串作为输入。
    /// 由固定文本和索引占位符混合组成，其中索引占位符称为格式项，格式项对应于列表中的对象。<br/>
    /// <para>
    /// 支持的方法：
    /// <list type="bullet">
    /// <item>String.Format</item>
    /// <item>StringBuild.AppendFormat</item>
    /// <item>Console.WriteLine</item>
    /// <item>TextWriter.WriteLine</item>
    /// <item>Debug.WriteLine(String, Object[])</item>
    /// <item>Trace.Trace…（String, Object[])</item>
    /// <item>TraceSource.TraceInformation(String, Object[])</item>
    /// </list>
    /// </para>
    /// </summary>
    class CompositeFormatting
    {
        /// <summary>
        /// <a href="https://learn.microsoft.com/zh-cn/dotnet/standard/base-types/composite-formatting#format-item-syntax">格式项语法</a>：<c>{index[,alignment][:formatString]}</c>
        /// <list type="bullet">
        /// <item>index 索引</item>
        /// <item>alignment 对齐：正数-右对齐，负数-左对齐</item>
        /// <item><see cref="FormatStrings">formatString</see> <a href="https://learn.microsoft.com/zh-cn/dotnet/standard/base-types/composite-formatting#format-string-component">格式字符串</a></item>
        /// </list>
        /// </summary>
        [Test]
        public void FormatItemSyntax()
        {
            string[] days = ["yesterday", "today", "tomorrow"];
            DateTime[] dates = [DateTime.Now.AddDays(-1), DateTime.Now, DateTime.Now.AddDays(1)];

            Console.WriteLine("{0,-20}{1,5}{2,5}", "Day", "Month", "Day");
            for (int i = 0; i < days.Length; i++)
                Console.WriteLine("{0,-20}{1,5:MM}{2,5:dd}", days[i], dates[i], dates[i]);
        }
    }
}
