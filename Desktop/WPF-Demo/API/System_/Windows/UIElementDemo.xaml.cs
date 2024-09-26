using System.Windows;
using System.Windows.Media;

namespace WPF_Demo.API.System_.Windows
{
    /// <summary>
    /// Interaction logic for UIElementDemo.xaml
    /// </summary>
    public partial class UIElementDemo
    {
        public UIElementDemo()
        {
            InitializeComponent();
        }

        private void BtnVisibility_Click(object sender, RoutedEventArgs e)
        {
            Ljh.Visibility = Ljh.Visibility == Visibility.Visible ? Visibility.Collapsed : Visibility.Visible;
        }

        private void BtnIsEnabled_Click(object sender, RoutedEventArgs e)
        {
            Ljh.IsEnabled = Ljh.IsEnabled != true;
        }

        private void BtnBackground_Click(object sender, RoutedEventArgs e)
        {
            Ljh.Background = Ljh.Background == Brushes.Transparent ? Brushes.Red : Brushes.Transparent;
        }

        private void BtnFontSize_Click(object sender, RoutedEventArgs e)
        {
            Ljh.FontSize = Math.Abs(Ljh.FontSize - 12d) < 1e-9 ? 14d : 12d;
        }
    }
}
