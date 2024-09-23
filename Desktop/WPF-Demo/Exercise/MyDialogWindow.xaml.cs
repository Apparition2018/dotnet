using System.Windows;

namespace WPF_Demo.Exercise;

public partial class MyDialogWindow : Window
{
    public MyDialogWindow()
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
