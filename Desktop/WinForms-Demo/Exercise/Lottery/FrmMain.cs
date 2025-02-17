using System.Drawing.Printing;
using WinForms_Demo.Exercise.Lottery.Util;

namespace WinForms_Demo.Exercise.Lottery;

public partial class FrmMain : Form
{
    private readonly Selector _selector = new();

    private readonly PrintDocument _printDocument = new();

    public FrmMain()
    {
        InitializeComponent();
        DisableBtn();
        _printDocument.PrintPage += LotteryPrintPage;
    }

    private void BtnMin_Click(object sender, EventArgs e)
    {
        WindowState = FormWindowState.Minimized;
    }

    private void BtnClose_Click(object sender, EventArgs e)
    {
        Close();
    }

    /// <summary>
    /// 启动选号
    /// </summary>
    private void BtnStart_Click(object sender, EventArgs e)
    {
        RandomTimer.Start();
        BtnStart.Enabled = false;
        BtnSelect.Enabled = true;
    }

    /// <summary>
    /// 开始选号
    /// </summary>
    private void BtnSelect_Click(object sender, EventArgs e)
    {
        RandomTimer.Stop();
        string[] selectedNum =
        {
            LbNum1.Text, LbNum2.Text, LbNum3.Text, LbNum4.Text,
            LbNum5.Text, LbNum6.Text, LbNum7.Text,
        };
        _selector.SelectedNums.Add(selectedNum);
        ShowSelectedNums();
    }

    /// <summary>
    /// 手写号码
    /// </summary>
    private void BtnWriteSelf_Click(object sender, EventArgs e)
    {
        string[] selectedNum =
        {
            TxtNum1.Text, TxtNum2.Text, TxtNum3.Text, TxtNum4.Text,
            TxtNum5.Text, TxtNum6.Text, TxtNum7.Text,
        };
        _selector.SelectedNums.Add(selectedNum);
        ShowSelectedNums();
    }

    /// <summary>
    /// 生成指定组的号码
    /// </summary>
    private void BtnGroupSelect_Click(object sender, EventArgs e)
    {
        RandomTimer.Stop();
        _selector.CreateGroupNums(Convert.ToInt16(TxtGroup.Text.Trim()));
        ShowSelectedNums();
    }

    /// <summary>
    /// 删除当前所选号码
    /// </summary>
    private void BtnDel_Click(object sender, EventArgs e)
    {
        if (LbNumList.Items.Count == 0 || LbNumList.SelectedItem == null) return;
        int index = LbNumList.SelectedIndex;
        _selector.SelectedNums.RemoveAt(index);
        ShowSelectedNums();
        if (_selector.SelectedNums.Count == 0)
        {
            BtnDel.Enabled = BtnClear.Enabled = BtnPrint.Enabled = false;
        }
    }

    /// <summary>
    /// 清空选号
    /// </summary>
    private void BtnClear_Click(object? sender, EventArgs? e)
    {
        LbNumList.Items.Clear();
        _selector.SelectedNums.Clear();
        LbNum1.Text = LbNum2.Text = LbNum3.Text = LbNum4.Text = LbNum5.Text = LbNum6.Text = LbNum7.Text = @"0";
        TxtNum1.Text = TxtNum2.Text = TxtNum3.Text = TxtNum4.Text = TxtNum5.Text = TxtNum6.Text = TxtNum7.Text = string.Empty;
        DisableBtn();
    }

    /// <summary>
    /// 打印彩票
    /// </summary>
    private void BtnPrint_Click(object sender, EventArgs e)
    {
        _printDocument.Print();
    }

    #region 拖动窗体的实现

    private Point _mouseOff;
    private bool _leftFlag;

    private void FrmMain_MouseDown(object sender, MouseEventArgs e)
    {
        if (e.Button != MouseButtons.Left) return;
        _mouseOff = new Point(-e.X, -e.Y);
        _leftFlag = true;
    }

    private void FrmMain_MouseMove(object sender, MouseEventArgs e)
    {
        if (!_leftFlag) return;
        Point mouseSet = Control.MousePosition;
        mouseSet.Offset(_mouseOff.X, _mouseOff.Y);
        Location = mouseSet;
    }

    private void FrmMain_MouseUp(object sender, MouseEventArgs e)
    {
        if (_leftFlag)
        {
            _leftFlag = false;
        }
    }

    #endregion

    /// <summary>
    /// 定时生成随机号码
    /// </summary>
    private void RandomTimer_Tick(object sender, EventArgs e)
    {
        string[] numList = _selector.CreateNum();
        LbNum1.Text = numList[0];
        LbNum2.Text = numList[1];
        LbNum3.Text = numList[2];
        LbNum4.Text = numList[3];
        LbNum5.Text = numList[4];
        LbNum6.Text = numList[5];
        LbNum7.Text = numList[6];
    }

    /// <summary>
    /// 显示选中的号码
    /// </summary>
    private void ShowSelectedNums()
    {
        LbNumList.Items.Clear();
        LbNumList.Items.AddRange(_selector.GetPrintedNums().ToArray());
        BtnStart.Enabled = BtnDel.Enabled = BtnClear.Enabled = BtnPrint.Enabled = true;
    }

    /// <summary>
    /// 禁用按钮
    /// </summary>
    private void DisableBtn()
    {
        BtnSelect.Enabled = false;
        BtnClear.Enabled = false;
        BtnDel.Enabled = false;
        BtnPrint.Enabled = false;
    }

    /// <summary>
    /// 具体打印实现过程
    /// </summary>
    private void LotteryPrintPage(object sender, PrintPageEventArgs e)
    {
        string serialNum = DateTime.Now.ToString("yyyyMMddHHmmssms");
        _selector.PrintLottery(e, serialNum, _selector.GetPrintedNums());
        _selector.Save(serialNum);
        BtnClear_Click(null, null);
    }
}
