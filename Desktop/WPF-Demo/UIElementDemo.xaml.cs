using System.Windows;
using System.Windows.Media;

namespace WPF_Demo
{
    /// <summary>
    /// Interaction logic for UIElementDemo.xaml
    /// </summary>
    public partial class UIElementDemo : Window
    {
        public UIElementDemo()
        {
            InitializeComponent();
        }

        private void BtnVisibility_Click(object sender, RoutedEventArgs e)
        {
            ljh.Visibility = ljh.Visibility == Visibility.Visible ? Visibility.Collapsed : Visibility.Visible;
        }

        private void BtnIsEnabled_Click(object sender, RoutedEventArgs e)
        {
            ljh.IsEnabled = ljh.IsEnabled != true;
        }

        private void BtnBackgroud_Click(object sender, RoutedEventArgs e)
        {
            ljh.Background = ljh.Background == Brushes.Transparent ? Brushes.Red : Brushes.Transparent;
        }

        private void BtnFontSize_Click(object sender, RoutedEventArgs e)
        {
            ljh.FontSize = Math.Abs(ljh.FontSize - 12d) < 1e-9 ? 14d : 12d;
        }
    }
}
