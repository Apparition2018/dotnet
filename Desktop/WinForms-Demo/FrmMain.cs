namespace WinForms_Demo
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
            Andy.Click += Teacher_Click;
            Carry.Click += Teacher_Click;
            Coco.Click += Teacher_Click;
        }

        private void btn_Click(object? sender, EventArgs e)
        {
            MessageBox.Show(@"你 好！");
        }

        private void btnMinus_Click(object sender, EventArgs e)
        {
            btn.Click -= btn_Click;
        }

        private void btnPlus_Click(object sender, EventArgs e)
        {
            btn.Click += btn_Click;
        }

        private void Teacher_Click(object? sender, EventArgs e)
        {
            MessageBox.Show(((Button)sender!).Text + @" 你好！");
        }

        private void MsgBoxShow_Click(object sender, EventArgs e)
        {
            DialogResult result =  MessageBox.Show("请输入学员姓名！", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            if (result == DialogResult.OK)
            {
                MessageBox.Show("用户继续操作！");
            }
            else
            {
                MessageBox.Show("用户取消操作！");
            }
        }
    }
}
