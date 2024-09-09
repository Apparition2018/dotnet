using System.ComponentModel;
using System.Windows;
using System.Windows.Input;

namespace WPF_Demo.Exercise.StudentManage
{
    /// <summary>
    /// Interaction logic for FrmMain.xaml
    /// </summary>
    public partial class FrmMain : Window
    {
        public FrmMain()
        {
            InitializeComponent();
        }

        #region 无边框窗体拖动
        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Point point = e.GetPosition(this);
            if (point.X >= 0 && point.X <= this.ActualWidth && point.Y >= 0 && point.Y <= this.ActualHeight)
            {
                this.DragMove();
            }
        }
        #endregion

        private void Window_Closing(object sender, CancelEventArgs e)
        {
            if (App.currentAdmin == null) return;
            MessageBoxResult result = MessageBox.Show("确认推出系统吗？", "退出询问", MessageBoxButton.OKCancel, MessageBoxImage.Question);
            if (result != MessageBoxResult.OK)
            {
                e.Cancel = true;
            }
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// 学员管理
        /// </summary>
        private void btnStudentManage_Click(object sender, RoutedEventArgs e)
        {
            gridContent.Children.Clear();
            FrmManageStudent manageStudent = new FrmManageStudent();
            gridContent.Children.Add(manageStudent);
        }
    }
}
