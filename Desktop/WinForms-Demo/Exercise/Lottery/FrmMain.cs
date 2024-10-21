using WinForms_Demo.Exercise.Lottery.Models;

namespace WinForms_Demo.Exercise.Lottery;

public partial class FrmMain : Form
{
    private readonly Selector _selector = new();

    public FrmMain()
    {
        InitializeComponent();

        BtnPrint.Enabled = false;
        BtnClear.Enabled = false;
        BtnDel.Enabled = false;
    }

    private void BtnClose_Click(object sender, EventArgs e)
    {
        Close();
    }

    private void BtnMin_Click(object sender, EventArgs e)
    {
        WindowState = FormWindowState.Minimized;
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
}
