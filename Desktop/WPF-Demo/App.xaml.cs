using System.Windows;
using Models;
using WPF_Demo.API.Microsoft.Win32_;
using WPF_Demo.API.System_.Windows;
using WPF_Demo.Exercise.StudentManagement;

namespace WPF_Demo
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            Window window = new UIElementDemo();
            window.Show();
            return;
            FrmMain mainForm = new FrmMain();
            FrmAdminLogin loginForm = new FrmAdminLogin();
            if (loginForm.ShowDialog() == true)
            {
                mainForm.Show();
            }
            else
            {
                mainForm.Close();
            }
        }

        public static Admin? currentAdmin = null;
    }
}
