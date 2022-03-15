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

        private int _Index = 0;
        public int Index
        {
            get { return _Index; }
            set { _Index = value; OnPropertyChanged(); }
        }

        private string _AuthorBox;

        public string AuthorBox
        {
            get { return _AuthorBox; }
            set { _AuthorBox = value; OnPropertyChanged(); }
        }

        private string _UserCommentBox;

        public string UserCommentBox
        {
            get { return _UserCommentBox; }
            set { _UserCommentBox = value; OnPropertyChanged(); }
        }

        private string _AuthorName;

        public string AuthorName
        {
            get { return _AuthorName; }
            set { _AuthorName = value; OnPropertyChanged(); }
        }

        private string _UserComment;

        public string UserComment
        {
            get { return _UserComment; }
            set { _UserComment = value; OnPropertyChanged(); }
        }


        #endregion
        #region commands
        public RelayCommand CancelCommand
        { get; set; }
        public RelayCommand OKCommand
        { get; set; }
        public RelayCommand DoubleClickCommand
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
            OKCommand = new RelayCommand(o =>
            {
                UserData.Add(new UserInfo() { Name = AuthorBox, Comment = UserCommentBox, Id = Guid.NewGuid() });
                AuthorBox = null;
                UserCommentBox = null;
                AuthorName = UserData[Index].Name;
                UserComment = UserData[Index].Comment;
            });
            /*DoubleClickCommand = new RelayCommand(o =>
            {
                AuthorBox = UserData[Index].Name;
                UserCommentBox = UserData[Index].Comment;
            });*/
        }
    }
}