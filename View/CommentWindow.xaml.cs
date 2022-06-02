using System.Windows;

namespace NS_Comment
{
    public partial class CommentWindow : Window
    {
        private bool modeIsEdit;

        public bool ModeIsEdit
        {
            get { return modeIsEdit; }
            set { modeIsEdit = value; }
        }

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
            if (model.SelectedMode == MainViewModel.Mode.Edit)
            {
                ModeIsEdit = true;
            }
            else
            {
                ModeIsEdit = false;
            }
        }

        private void AuthorBox_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            if (ModeIsEdit)
            {
                OkButton.IsEnabled = true;
            }
        }

        private void CommentBox_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            if (ModeIsEdit)
            {
                OkButton.IsEnabled = true;
            }
        }

        private void OkButton_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
        }
    }
}
