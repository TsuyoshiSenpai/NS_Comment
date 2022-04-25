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

        public void AuthorBoxTextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            OkButton.IsEnabled = true;
        }

        public void CommentBoxTextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            OkButton.IsEnabled = true;
        }
    }
}
