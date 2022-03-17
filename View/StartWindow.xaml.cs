using System.Windows;

namespace NS_Comment.View
{
    /// <summary>
    /// Логика взаимодействия для StartWindow.xaml
    /// </summary>
    public partial class StartWindow : Window
    {
        public StartWindow()
        {
            InitializeComponent();
        }

        private void NewMode(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Owner = Application.Current.MainWindow;
            mainWindow.Show();
            Application.Current.MainWindow.Hide();
        }

        private void EditMode(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Owner = Application.Current.MainWindow;
            mainWindow.Show();
            Application.Current.MainWindow.Hide();
        }

        private void ReadMode(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Owner = Application.Current.MainWindow;
            mainWindow.Show();
            Application.Current.MainWindow.Hide();
        }
    }
}
