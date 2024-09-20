using System.Windows;

namespace WPF_Demo.Controls
{
    /// <summary>
    /// Interaction logic for ProgressBarDemo.xaml
    /// </summary>
    public partial class ProgressBarDemo : Window
    {
        public ProgressBarDemo()
        {
            InitializeComponent();
        }

        private void BtnValue_Click(object sender, RoutedEventArgs e)
        {
            ProgressBar.Value += 10;
        }

        private void BtnIsIndeterminate_Click(object sender, RoutedEventArgs e)
        {
            ProgressBar.IsIndeterminate = !ProgressBar.IsIndeterminate;
        }
    }
}
