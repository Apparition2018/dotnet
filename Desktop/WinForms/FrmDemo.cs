namespace WinForms
{
    public partial class FrmDemo : Form
    {
        public FrmDemo()
        {
            InitializeComponent();
            Andy.Click += Teacher_Click;
            Carry.Click += Teacher_Click;
            Coco.Click += Teacher_Click;
        }

        private void Btn_Click(object? sender, EventArgs e)
        {
            MessageBox.Show(@"你 好！");
        }

        private void BtnMinus_Click(object sender, EventArgs e)
        {
            btn.Click -= Btn_Click;
        }

        private void BtnPlus_Click(object sender, EventArgs e)
        {
            btn.Click += Btn_Click;
        }

        private void Teacher_Click(object? sender, EventArgs e)
        {
            MessageBox.Show(((Button)sender!).Text + @" 你好！");
        }

        private void MsgBoxShow_Click(object sender, EventArgs e)
        {
            DialogResult result =  MessageBox.Show(@"请输入学员姓名！", @"提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            MessageBox.Show(result == DialogResult.OK ? "用户继续操作！" : "用户取消操作！");
        }
    }
}
