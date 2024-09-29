namespace WinForms_Demo.Exercise.MIS
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
        }

        private void OpenNewForm(Form newForm)
        {
            // 1 关闭嵌入的其它窗体
            foreach (Control control in splitContainer.Panel2.Controls)
            {
                if (control is Form form)
                {
                    form.Close();
                }
            }
            // 2 打开新的窗体
            newForm.TopLevel = false;
            // newForm.FormBorderStyle = FormBorderStyle.None;
            newForm.Parent = splitContainer.Panel2;
            newForm.Dock = DockStyle.Fill;
            newForm.Show();
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void BtnProductManagement_Click(object sender, EventArgs e)
        {
            OpenNewForm(new FrmAddProduct());
        }
    }
}
