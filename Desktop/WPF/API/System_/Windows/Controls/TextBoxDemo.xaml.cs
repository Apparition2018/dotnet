using System.Windows;

namespace WPF.API.System_.Windows.Controls
{
    /// <summary>
    /// Interaction logic for TextBoxDemo.xaml
    /// </summary>
    public partial class TextBoxDemo
    {
        public TextBoxDemo()
        {
            InitializeComponent();
        }

        private void BtnIsReadonly_Click(object sender, RoutedEventArgs e)
        {
            Letter.IsReadOnly = !Letter.IsReadOnly;
        }

        private void BtnTextWrapping_Click(object sender, RoutedEventArgs e)
        {

            Letter.TextWrapping = Letter.TextWrapping == TextWrapping.Wrap ? TextWrapping.NoWrap : TextWrapping.Wrap;
        }

        private void BtnMaxLength_Click(object sender, RoutedEventArgs e)
        {
            Letter.MaxLength = Letter.MaxLength == 0 ? 5 : 0;
        }
    }
}
