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
        public RelayCommand SelectCommand
        { get; set; }
        #endregion

        public MainViewModel()
        {
            UserData = new ObservableCollection<UserInfo>();
            CancelCommand = new RelayCommand(o => Cancel());
            OKCommand = new RelayCommand(o => OK());
            SelectCommand = new RelayCommand(o => Select());
        }

        public void OK()
        {
            UserData.Add(new UserInfo() { Name = AuthorName, Comment = UserComment, Id = Guid.NewGuid() });
            AuthorName = UserData[Index].Name;
            UserComment = UserData[Index].Comment;
        }
        public void Select()
        {
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
    }
}