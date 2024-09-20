using System.Windows;

namespace WPF_Demo.Controls
{
    /// <summary>
    /// Interaction logic for TextBoxDemo.xaml
    /// </summary>
    public partial class TextBoxDemo : Window
    {
        public TextBoxDemo()
        {
            InitializeComponent();
        }

        private void BtnIsReadonly_Click(object sender, RoutedEventArgs e)
        {
            letter.IsReadOnly = !letter.IsReadOnly;
        }

        private void BtnTextWrapping_Click(object sender, RoutedEventArgs e)
        {

            letter.TextWrapping = letter.TextWrapping == TextWrapping.Wrap ? TextWrapping.NoWrap : TextWrapping.Wrap;
        }

        private void BtnMaxLength_Click(object sender, RoutedEventArgs e)
        {
            letter.MaxLength = letter.MaxLength == 0 ? 5 : 0;
        }
    }
}
