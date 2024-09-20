using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace WPF_Demo.Exercise.MahjongSolitaire
{
    /// <summary>
    /// Interaction logic for MahjongSolitaire.xaml
    /// </summary>
    public partial class MahjongSolitaire : Window
    {
        public MahjongSolitaire()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < 10; i++)
            {
                Board.ColumnDefinitions.Add(new ColumnDefinition());
                Board.RowDefinitions.Add(new RowDefinition());
            }


            string[] imgNames = ["gold", "silver", "copper"];
            Random random = new Random();
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    int imgIndex =  random.Next(imgNames.Length);
                    Image img = new Image
                    {
                        Source = new BitmapImage(new Uri($"Images/{imgNames[imgIndex]}.png", UriKind.Relative))
                    };
                    Grid.SetRow(img, i);
                    Grid.SetColumn(img, j);
                    Board.Children.Add(img);
                }
            }
        }
    }
}
