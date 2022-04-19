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
            CommentWindow commentWindow = new CommentWindow();
            commentWindow.Owner = Application.Current.MainWindow;
            commentWindow.ShowDialog();
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            CommentWindow commentWindow = new CommentWindow();
            commentWindow.Owner = Application.Current.MainWindow;
            commentWindow.ShowDialog();
        }

        private void ReadButton_Click(object sender, RoutedEventArgs e)
        {
            CommentWindow commentWindow = new CommentWindow();
            commentWindow.Owner = Application.Current.MainWindow;
            commentWindow.ShowDialog();
        }
    }
}
