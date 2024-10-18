using System.Drawing.Imaging;

namespace WinForms_Demo.Exercise.Lottery
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void BtnMin_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
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
    }
}
