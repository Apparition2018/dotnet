using System.Windows;
using System.Windows.Input;
using Models;

namespace WPF_Demo.Exercise.StudentManagement
{
    /// <summary>
    /// Interaction logic for FrmAdminLogin.xaml
    /// </summary>
    public partial class FrmAdminLogin
    {
        public FrmAdminLogin()
        {
            InitializeComponent();
            TxtLoginId.Focus();
        }

        #region 无边框窗体拖动
        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Point point =  e.GetPosition(this);
            if (point.X >= 0 && point.X <= ActualWidth && point.Y >= 0 && point.Y <= ActualHeight)
            {
                DragMove();
            }
        }
        #endregion
        private void BtnLogin_Click(object sender, RoutedEventArgs e)
        {
            // 调用登录逻辑…
            // 保存登录对象
            App.CurrentAdmin = new Admin();
            DialogResult = true;
        }

        private void BtnExit_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }
    }
}
