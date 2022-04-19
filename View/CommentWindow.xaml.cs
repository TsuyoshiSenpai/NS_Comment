using System.Windows;

namespace NS_Comment
{
    /// <summary>
    /// Логика взаимодействия для CommentWindow.xaml
    /// </summary>
    public partial class CommentWindow : Window
    {
        public CommentWindow()
        {
            InitializeComponent();
            this.DataContext = new MainViewModel();
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }

        public CommentWindow(MainViewModel model) : this()
        {
            this.DataContext = model;
        }
    }
}
