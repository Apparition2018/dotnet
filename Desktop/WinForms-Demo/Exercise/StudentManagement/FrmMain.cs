namespace WinForms_Demo.Exercise.StudentManagement
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
        }

        private void TsmiPwdModify_Click(object sender, EventArgs e) { }

        #region 关闭已存在窗体，嵌入新窗体

        private void CloseExistedForm()
        {
            foreach (Control control in mainContainer.Panel2.Controls)
            {
                if (control is Form from)
                {
                    from.Close();
                }
            }
        }

        private void OpenForm(Form form)
        {
            form.TopLevel = false;
            form.WindowState = FormWindowState.Maximized;
            form.FormBorderStyle = FormBorderStyle.None;
            form.Parent = mainContainer.Panel2;
            form.Show();
        }

        #endregion

        private void BtnAddStudent_Click(object sender, EventArgs e)
        {
            CloseExistedForm();
            OpenForm(new FrmAddStudent());
        }

        private void BtnStuManagement_Click(object sender, EventArgs e)
        {
            CloseExistedForm();
            OpenForm(new FrmStudentManagement());
        }
    }
}
