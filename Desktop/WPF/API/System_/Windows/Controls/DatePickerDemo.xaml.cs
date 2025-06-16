using System.Windows;

namespace WPF.API.System_.Windows.Controls
{
    /// <summary>
    /// Interaction logic for DatePickerDemo.xaml
    /// </summary>
    public partial class DatePickerDemo
    {
        public DatePickerDemo()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            DateTime? selectedDate = DataPicker.SelectedDate;
            MessageBox.Show(selectedDate == null ? "请选择日期！" : selectedDate.ToString());
        }
    }
}
