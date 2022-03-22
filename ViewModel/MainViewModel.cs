using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
            set { if(value != userComment) userComment = value; OnPropertyChanged(); }
        }

        #endregion
        #region commands
        public RelayCommand CancelCommand
        { get; set; }
        public RelayCommand OKCommand
        { get; set; }
        public RelayCommand AuthorsListCommand
        { get; set; }
        #endregion

        public MainViewModel()
        {
            UserData = new ObservableCollection<UserInfo>();
            CancelCommand = new RelayCommand(o => Cancel());
            OKCommand = new RelayCommand(o => OK());
            AuthorsListCommand = new RelayCommand(o => AuthorList());
        }
        public void OK()
        {
            UserData.Add(new UserInfo() { Name = AuthorName, Comment = UserComment, Id = Guid.NewGuid() });
            AuthorName = UserData[Index].Name;
            UserComment = UserData[Index].Comment;
        }
        public void Cancel()
        {
            foreach (Window window in Application.Current.Windows)
            {
                if (window.Title == "MainWindow")
                {
                    window.Close();
                }
            }
        }
        public void AuthorList()
        {
            AuthorsListWindow authorsListWindow = new AuthorsListWindow();
            authorsListWindow.Owner = Application.Current.MainWindow;
            authorsListWindow.Show();
            Application.Current.MainWindow.Hide();
        }
    }
}