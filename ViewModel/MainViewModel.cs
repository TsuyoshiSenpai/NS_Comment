using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text.RegularExpressions;
using System.Windows;
using NS_Comment.View;

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
            set { if(value != index) index = value; OnPropertyChanged(); }
        }

        private string authorName;

        public string AuthorName
        {
            get { return authorName; }
            set { if(value != authorName) authorName = value; OnPropertyChanged(); }
        }

        private string userComment;

        public string UserComment
        {
            get { return userComment; }
            set { if (value != userComment) userComment = value; OnPropertyChanged(); }
        }
        public List<string> Authors
        { get; set; }
        public List<string> UserComments 
        { get; set; }

        #endregion
        #region commands
        public RelayCommand CancelCommand
        { get; set; }
        public RelayCommand OKCommand
        { get; set; }
        public RelayCommand AuthorSelectCommand
        { get; set; }
        public RelayCommand CommentSelectCommand
        { get; set; }
        #endregion

        public MainViewModel()
        {
            UserData = new ObservableCollection<UserInfo>();
            Authors = new List<string> { };
            UserComments = new List<string> { };
            CancelCommand = new RelayCommand(o => Cancel());
            OKCommand = new RelayCommand(o => OK());
            AuthorSelectCommand = new RelayCommand(o => Select("author"));
            CommentSelectCommand = new RelayCommand(o => Select("comment"));
        }
        public void OK()
        {
            UserData.Add(new UserInfo() { Name = AuthorName, Comment = UserComment, Id = Guid.NewGuid() });
            Authors.Add(UserData[Index].Name);
            UserComments.Add(UserData[Index].Comment);
        }
        public void Cancel()
        {
            foreach (Window window in Application.Current.Windows)
            {
                if (window.Title == "MainWindow")
                {
                    window.DialogResult = false;
                }
            }
        }
        public void Select(string SelectType)
        {
            if(SelectType == "author")
            {
                AuthorName = Authors[Index];
            } 
            else if (SelectType == "comment")
            {
                UserComment = UserComments[Index];
            }
        }
    }
}