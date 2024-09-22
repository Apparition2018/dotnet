using System.Windows;

namespace WPF_Demo.Exercise.MultiWindows;

public partial class InputWindow : Window
{
    public InputWindow()
    {
        InitializeComponent();
    }

    private void BtnConfirm_Click(object sender, RoutedEventArgs e)
    {
        DialogResult = true;
    }

    private void BtnCancel_Click(object sender, RoutedEventArgs e)
    {
        DialogResult = false;
    }
}
