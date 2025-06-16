using System.Windows;

namespace WPF.Exercise;

public partial class MyDialogWindow
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
