using System.Windows;

namespace WPF_Demo.Controls
{
    /// <summary>
    /// Interaction logic for DatePickerDemo.xaml
    /// </summary>
    public partial class DatePickerDemo : Window
    {
        public DatePickerDemo()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            DateTime? selectedDate = dataPicker.SelectedDate;
            MessageBox.Show(selectedDate == null ? "请选择日期！" : selectedDate.ToString());
        }
    }
}
