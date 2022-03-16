using System;
using System.Collections.ObjectModel;
using System.Windows;

namespace NS_Comment
{
    class MainViewModel : Observer
    {
        #region properties
        public ObservableCollection<UserInfo> UserData
        { get; set; }

        private int index = 0;
        public int Index
        {
            get { return index; }
            set { index = value; OnPropertyChanged(); }
        }

        private string authorBox;

        public string AuthorBox
        {
            get { return authorBox; }
            set { authorBox = value; OnPropertyChanged(); }
        }

        private string userCommentBox;

        public string UserCommentBox
        {
            get { return userCommentBox; }
            set { userCommentBox = value; OnPropertyChanged(); }
        }

        private string authorName;

        public string AuthorName
        {
            get { return authorName; }
            set { authorName = value; OnPropertyChanged(); }
        }

        private string userComment;

        public string UserComment
        {
            get { return userComment; }
            set { userComment = value; OnPropertyChanged(); }
        }


        #endregion
        #region commands
        public RelayCommand CancelCommand
        { get; set; }
        public RelayCommand OKCommand
        { get; set; }
        public RelayCommand SelectCommand
        { get; set; }
        #endregion

        public MainViewModel()
        {
            UserData = new ObservableCollection<UserInfo>();
            CancelCommand = new RelayCommand(o =>
            {
                foreach (Window window in Application.Current.Windows)
                {
                    if (window.Title == "MainWindow")
                    {
                        window.Close();
                    }
                }
            });
            OKCommand = new RelayCommand(o => OK());
            SelectCommand = new RelayCommand(o => Select());
        }

        public void OK()
        {
            UserData.Add(new UserInfo() { Name = AuthorBox, Comment = UserCommentBox, Id = Guid.NewGuid() });
            ClearInfo();
            AuthorName = UserData[Index].Name;
            UserComment = UserData[Index].Comment;
        }
        public void ClearInfo()
        {
            AuthorBox = null;
            UserCommentBox = null;
        }
        public void Select()
        {
            AuthorBox = UserData[Index].Name;
            UserCommentBox = UserData[Index].Comment;
        }
    }
}