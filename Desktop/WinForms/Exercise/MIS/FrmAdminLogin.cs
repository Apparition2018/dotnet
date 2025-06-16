namespace WinForms.Exercise.MIS
{
    public partial class FrmAdminLogin : Form
    {
        public FrmAdminLogin()
        {
            InitializeComponent();
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        #region 窗体移动

        private Point _mousePoint;
        private bool _leftFlag;

        private void FrmAD_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left) return;
            _mousePoint = new Point(-e.X, -e.Y);
            _leftFlag = true;
        }

        private void FrmAD_MouseMove(object sender, MouseEventArgs e)
        {
            if (!_leftFlag) return;
            Point mousePoint = MousePosition;
            mousePoint.Offset(_mousePoint.X, _mousePoint.Y);
            Location = mousePoint;
        }

        private void FrmAD_MouseUp(object sender, MouseEventArgs e)
        {
            if (_leftFlag) _leftFlag = false;
        }

        #endregion
    }
}
