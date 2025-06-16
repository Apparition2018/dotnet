using System.Windows;
using DAL;
using Models.Ext;

namespace WPF.Exercise.StudentManagement
{
    /// <summary>
    /// Interaction logic for FrmManageStudent.xaml
    /// </summary>
    public partial class FrmManageStudent
    {
        private readonly StudentClassService _classService = new();
        private readonly StudentService _studentService = new();
        private List<StudentExt>? _studentList;

        public FrmManageStudent()
        {
            InitializeComponent();
            CbbClass.ItemsSource = _classService.GetAllClasses();
            CbbClass.DisplayMemberPath = "ClassName";
            CbbClass.SelectedValuePath = "ClassId";
            CbbClass.SelectedIndex = -1;
        }

        private void BtnQueryList_Click(object sender, RoutedEventArgs e)
        {
            if (CbbClass.SelectedIndex == -1)
            {
                MessageBox.Show("请首先选择一个班级！", "查询提示");
                return;
            }
            _studentList = _studentService.GetStudentByClass(this.CbbClass.Text);
            DgStudentList.ItemsSource = _studentList;
        }

        private void BtnNameAsc_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnNameDesc_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnDel_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnExport_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnPrint_Click(object sender, RoutedEventArgs e)
        {

        }

        /// <summary>
        /// 关闭当前窗体
        /// </summary>
        private void BtnClose_Click(object sender, RoutedEventArgs e)
        {
            Visibility = Visibility.Hidden;
        }
    }
}
