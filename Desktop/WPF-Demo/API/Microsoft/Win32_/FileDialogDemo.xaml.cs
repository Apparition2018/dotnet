using System.IO;
using System.Windows;
using System.Windows.Media.Imaging;
using Microsoft.Win32;

namespace WPF_Demo.API.Microsoft.Win32_
{
    /// <summary>
    /// Interaction logic for OpenFileDialogDemo.xaml
    /// </summary>
    public partial class FileDialogDemo : Window
    {
        public FileDialogDemo()
        {
            InitializeComponent();
        }

        private void BtnOpen_Click(Object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Title = "选择一张图片",
                Filter = "所有图片文件|*.bmp;*.dib;*.jpg;*.jpeg;*.jpe;*.jfif;*.gif;*.tif;*.tiff;*.png;*.ico;*.heic;*.webp|" +
                         "位图文件|*.bmp;*.dib|" +
                         "JPEG|*.jpg;*.jpeg;*.jpe;*.jfif|" +
                         "GIF|*.gif|" +
                         "TIFF|*.tif;*.tiff|" +
                         "PNG|*.png|" +
                         "ICO|*.ico|" +
                         "HEIC|*.heic|" +
                         "WEBP|*.webp"
            };
            if (openFileDialog.ShowDialog() == true)
            {
                Img.Source = new BitmapImage(new Uri(openFileDialog.FileName));
            }
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog()
            {
                Title = "保存文本",
                Filter = "所有文件|*|TXT|*.txt",
                DefaultExt = ".txt"
            };
            if (saveFileDialog.ShowDialog() != true) return;
            using StreamWriter writer = new StreamWriter(saveFileDialog.FileName);
            writer.WriteLine("Hello, WPF!");
        }
    }
}
