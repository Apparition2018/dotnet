using System.Drawing.Printing;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using Fath;

namespace WinForms.Exercise.Lottery.Util;

/// <summary>
/// 选号器
/// </summary>
public class Selector
{
    private readonly Random _rnd = new();

    private readonly BarcodeX _barcodeX = new();

    /// <summary>
    /// 选择的号码
    /// </summary>
    public List<string[]> SelectedNums { get; set; } = [];

    /// <summary>
    /// 生成7个随机号码
    /// </summary>
    public string[] CreateNum()
    {
        string[] numList = new string[7];
        for (int i = 0; i < numList.Length; i++)
        {
            numList[i] = _rnd.Next(10).ToString();
        }

        return numList;
    }

    /// <summary>
    /// 生成指定组数的随机号码
    /// </summary>
    /// <param name="count"></param>
    public void CreateGroupNums(int count)
    {
        SelectedNums.Clear();
        for (int i = 0; i < count; i++)
        {
            SelectedNums.Add(CreateNum());
        }
    }

    /// <summary>
    /// 获取打印格式的号码列表
    /// </summary>
    public List<string> GetPrintedNums()
    {
        List<string> numList = [];
        for (int i = 0; i < SelectedNums.Count; i++)
        {
            StringBuilder printedNum = new StringBuilder();
            printedNum.Append($"第{(i < 9 ? "0" : string.Empty)}{i + 1}组：");
            for (int j = 0; j < SelectedNums[i].Length; j++)
            {
                printedNum.Append(SelectedNums[i][j]);
                printedNum.Append(j == 5 ? "   " : " ");
            }

            numList.Add(printedNum.ToString());
        }

        return numList;
    }

    /// <summary>
    /// 打印彩票
    /// </summary>
    public void PrintLottery(PrintPageEventArgs e, string serialNum, List<string> numList)
    {
        // 生成条形码
        _barcodeX.Text = serialNum;
        _barcodeX.Symbology = bcType.Code128;
        _barcodeX.ShowText = true;
        e.Graphics!.DrawImage(_barcodeX.Image(240, 50), new Point(20, 5));

        // 生成彩票信息
        float left = 2;
        float top = 70;
        Font titleFont = new Font("仿宋", 10);
        Font font = new Font("仿宋", 8);
        e.Graphics.DrawString("天津百万奖彩票中心", titleFont, Brushes.Blue, left + 20, top, new StringFormat());

        // 画一条分界线
        Pen pen = new Pen(Color.Green, 1);
        e.Graphics.DrawLine(pen, new Point((int)left - 2, (int)top + 20),
            new Point((int)left + 180, (int)top + 20));

        // 循环打印选号
        for (int i = 0; i < numList.Count; i++)
        {
            e.Graphics.DrawString(numList[i], font, Brushes.Blue, left,
                top + titleFont.GetHeight(e.Graphics) + font.GetHeight(e.Graphics) * i + 12, new StringFormat());
        }

        // 画一条分界线
        float topPoint = titleFont.GetHeight(e.Graphics) + font.GetHeight(e.Graphics) * (numList.Count) + 22;
        e.Graphics.DrawLine(pen, new Point((int)left - 2, (int)top + (int)topPoint),
            new Point((int)left + 180, (int)top + (int)topPoint));

        // 打印时间
        string time = "购买时间：" + DateTime.Now.ToString("yyy-MM-dd  HH:mm:ss");
        e.Graphics.DrawString(time, font, Brushes.Blue, left,
            top + titleFont.GetHeight(e.Graphics) + font.GetHeight(e.Graphics) * (numList.Count + 1) + 12, new StringFormat());

        // 生成二维码图片
        int qrcodeTop = (int)(top + titleFont.GetHeight(e.Graphics) + font.GetHeight(e.Graphics) * (numList.Count + 3) + 12);
        int qrcodeLeft = (int)left + 32;
        // Image bmp = QRcodeCreator.GetQRCodeBmp("http://www.xiketang.com/duijiang/query?id=" + serialNum);
        Image bmp = QRCodeCreator.GetQRCodeBmp("http://www.xiketang.com");
        e.Graphics.DrawImage(bmp, new Point(qrcodeLeft, qrcodeTop));

        e.Graphics.DrawString("扫描二维码可直接查询兑奖结果", font, Brushes.Blue, left, qrcodeTop + bmp.Height + 10, new StringFormat());
    }

    /// <summary>
    /// 保存用户所选彩票信息（实际开发中，应保存到数据库）
    /// </summary>
    [Obsolete("Obsolete")]
    public void Save(string serialNum)
    {
        DirectoryInfo dir = new DirectoryInfo("numList");
        if (!dir.Exists)
        {
            dir.Create();
        }
        string path = @"numList\" + serialNum + ".num";
        using FileStream fs = new FileStream(path, FileMode.Create);
        BinaryFormatter bf = new BinaryFormatter();
        bf.Serialize(fs, SelectedNums);
    }
}
