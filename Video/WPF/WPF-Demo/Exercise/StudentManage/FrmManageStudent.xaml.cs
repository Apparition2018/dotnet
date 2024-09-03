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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WPF_Demo.Exercise.StudentManage
{
    /// <summary>
    /// Interaction logic for FrmManageStudent.xaml
    /// </summary>
    public partial class FrmManageStudent : UserControl
    {
        public FrmManageStudent()
        {
            InitializeComponent();
        }

        private void btnQueryList_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnNameAsc_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnNameDesc_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnDel_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnExport_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnPrint_Click(object sender, RoutedEventArgs e)
        {

        }

        /// <summary>
        /// 关闭当前窗体
        /// </summary>
        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Visibility = Visibility.Hidden;
        }
    }
}
