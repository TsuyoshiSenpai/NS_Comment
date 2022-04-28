using System.Windows;

namespace NS_Comment
{
    public partial class CommentWindow : Window
    {
        public CommentWindow()
        {
            InitializeComponent();
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }

        public CommentWindow(MainViewModel model) : this()
        {
            InitializeComponent();
            this.DataContext = model;
        }
    }
}
