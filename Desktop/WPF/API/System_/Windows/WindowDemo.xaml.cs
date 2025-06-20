using System.Windows;
using WPF.Exercise;

namespace WPF.API.System_.Windows
{
    /// <summary>
    /// Interaction logic for WindowDemo.xaml
    /// </summary>
    public partial class WindowDemo
    {
        public WindowDemo()
        {
            InitializeComponent();
        }

        private void BtnShowDialog_Click(object sender, RoutedEventArgs e)
        {
            MyDialogWindow dialogWindow = new MyDialogWindow();
            bool? dialogResult = dialogWindow.ShowDialog();
            switch (dialogResult)
            {
                case true:
                    MessageBox.Show("确定：" + dialogWindow.Txt.Text);
                    break;
                case false:
                    MessageBox.Show("取消");
                    break;
                default:
                    MessageBox.Show("异常");
                    break;
            }
        }
    }
}
