using System.Windows;
using Models;
using WPF.API.System_.Windows;
using WPF.Exercise.StudentManagement;

namespace WPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App
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

        public static Admin? CurrentAdmin = null;
    }
}
