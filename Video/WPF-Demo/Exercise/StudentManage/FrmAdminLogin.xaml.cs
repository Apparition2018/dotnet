using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WPF_Demo.Exercise.StudentManage
{
    /// <summary>
    /// Interaction logic for FrmAdminLogin.xaml
    /// </summary>
    public partial class FrmAdminLogin : Window
    {
        public FrmAdminLogin()
        {
            InitializeComponent();
            this.txtLoginId.Focus();
        }

        #region 无边框窗体拖动
        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Point point =  e.GetPosition(this);
            if (point.X >= 0 && point.X <= this.ActualWidth && point.Y >= 0 && point.Y <= this.ActualHeight)
            {
                this.DragMove();
            }
        }
        #endregion
        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            // 调用登录逻辑
            // this.DialogResult = true;
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            // this.DialogResult = false;
            this.Close();
        }
    }
}
