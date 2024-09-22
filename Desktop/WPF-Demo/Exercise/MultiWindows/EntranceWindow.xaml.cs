using System.Windows;

namespace WPF_Demo.Exercise.MultiWindows
{
    /// <summary>
    /// EntranceWindow.xaml 的交互逻辑
    /// </summary>
    public partial class EntranceWindow : Window
    {
        public EntranceWindow()
        {
            InitializeComponent();
        }

        private void Btn_Click(object sender, RoutedEventArgs e)
        {
            InputWindow inputWindow = new InputWindow();
            bool? dialogResult = inputWindow.ShowDialog();
            switch (dialogResult)
            {
                case null:
                    MessageBox.Show("异常");
                    break;
                case true:
                {
                    MessageBox.Show("确定：" + inputWindow.Txt.Text);
                    break;
                }
                default:
                {
                    MessageBox.Show("取消");
                    break;
                }
            }
        }
    }
}
