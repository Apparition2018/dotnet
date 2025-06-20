namespace WinForms.Function.CustomizedControl;

public partial class FrmMain : Form
{
    public FrmMain()
    {
        InitializeComponent();
    }

    private async void btnAdd_Click(object sender, EventArgs e)
    {
        btnAdd.Enabled = false;
        try
        {
            bool checkName = txtName.CheckEmpty();
            bool checkAge = txtAge.CheckByRegex(@"^[1-9]\d*$", "年龄必须是正整数！");
            for (int i = 1; i <= 10; i++)
            {
                progressBar.Percent = i * 10;
                // 使用异步延迟，不阻塞UI线程
                await Task.Delay(300);
            }
            if (checkName && checkAge)
            {
                MessageBox.Show(@"提交成功！", @"提示");
            }
        }
        finally
        {
            btnAdd.Enabled = true;
        }
    }
}
