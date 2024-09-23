using System.Windows;

namespace WPF_Demo.API.System_.Windows.Controls
{
    /// <summary>
    /// Interaction logic for MenuDemo.xaml
    /// </summary>
    public partial class MenuDemo : Window
    {
        public MenuDemo()
        {
            InitializeComponent();
        }

        private void MiOpen_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("打开");
        }
    }
}
