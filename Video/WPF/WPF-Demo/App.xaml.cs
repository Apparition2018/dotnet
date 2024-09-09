using Models;
using System.Windows;
using WPF_Demo.Exercise.StudentManage;

namespace WPF_Demo
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            FrmMain mainForm = new FrmMain();
            FrmAdminLogin loginForm = new FrmAdminLogin();
            if (loginForm.ShowDialog() == true)
            {
                mainForm.Show();
            } else
            {
                mainForm.Close();
            }
        }

        public static Admin? currentAdmin = null;
    }
}
