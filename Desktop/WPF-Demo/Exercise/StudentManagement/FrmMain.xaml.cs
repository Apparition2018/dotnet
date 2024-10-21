using System.ComponentModel;
using System.Windows;
using System.Windows.Input;

namespace WPF_Demo.Exercise.StudentManagement
{
    /// <summary>
    /// Interaction logic for FrmMain.xaml
    /// </summary>
    public partial class FrmMain
    {
        public FrmMain()
        {
            InitializeComponent();
        }

        #region 无边框窗体拖动
        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Point point = e.GetPosition(this);
            if (point.X >= 0 && point.X <= ActualWidth && point.Y >= 0 && point.Y <= ActualHeight)
            {
                DragMove();
            }
        }
        #endregion

        private void Window_Closing(object sender, CancelEventArgs e)
        {
            if (App.CurrentAdmin == null) return;
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
        private void BtnStudentManage_Click(object sender, RoutedEventArgs e)
        {
            GridContent.Children.Clear();
            FrmManageStudent manageStudent = new FrmManageStudent();
            GridContent.Children.Add(manageStudent);
        }
    }
}
