using System.Windows;

namespace NS_Comment
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

        private void NewButton_Click(object sender, RoutedEventArgs e)
        {
            MainViewModel mainViewModel = new MainViewModel(MainViewModel.Mode.New);
            CommentWindow commentWindow = new CommentWindow(mainViewModel);
            commentWindow.Owner = Application.Current.MainWindow;
            commentWindow.ShowDialog();
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            MainViewModel editViewModel = new MainViewModel(MainViewModel.Mode.Edit);
            CommentWindow commentWindow = new CommentWindow(editViewModel);
            commentWindow.Owner = Application.Current.MainWindow;
            commentWindow.ShowDialog();
            // тут нужно выводить первые элементы списков
        }

        private void ReadButton_Click(object sender, RoutedEventArgs e)
        {
            MainViewModel mainViewModel = new MainViewModel(MainViewModel.Mode.Read);
            CommentWindow commentWindow = new CommentWindow(mainViewModel);
            commentWindow.Owner = Application.Current.MainWindow;
            commentWindow.ShowDialog();
            // тут нужно выводить первые элементы списков
        }
    }
}
