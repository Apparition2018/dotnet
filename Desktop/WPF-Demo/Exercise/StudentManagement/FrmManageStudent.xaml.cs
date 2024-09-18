using System.Windows;
using System.Windows.Controls;
using DAL;
using Models.Ext;

namespace WPF_Demo.Exercise.StudentManagement
{
    /// <summary>
    /// Interaction logic for FrmManageStudent.xaml
    /// </summary>
    public partial class FrmManageStudent : UserControl
    {
        private StudentClassService classService = new StudentClassService();
        private StudentService studentService = new StudentService();
        private List<StudentExt>? studentList = null;

        public FrmManageStudent()
        {
            InitializeComponent();
            this.cboClass.ItemsSource = classService.GetAllClasses();
            this.cboClass.DisplayMemberPath = "ClassName";
            this.cboClass.SelectedValuePath = "ClassId";
            this.cboClass.SelectedIndex = -1;
        }

        private void btnQueryList_Click(object sender, RoutedEventArgs e)
        {
            if (this.cboClass.SelectedIndex == -1)
            {
                MessageBox.Show("请首先选择一个班级！", "查询提示");
                return;
            }
            studentList = studentService.GetStudentByClass(this.cboClass.Text);
            this.dgvStudentList.ItemsSource = studentList;
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
