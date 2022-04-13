using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;

namespace NS_Comment
{
    public class MainViewModel : Observer
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

        private bool okIsEnabled = true;

        public bool OkIsEnabled
        {
            get { return okIsEnabled; }
            set { okIsEnabled = value; OnPropertyChanged(); }
        }


        #endregion
        #region commands
        public RelayCommand OKCommand
        { get; set; }
        public RelayCommand AuthorSelectCommand
        { get; set; }
        public RelayCommand CommentSelectCommand
        { get; set; }
        public RelayCommand CreateNewUserCommand
        { get; set; }
        public RelayCommand EditUserInfoCommand
        { get; set; }
        public RelayCommand ReadUserInfoCommand
        { get; set; }
        #endregion

        public enum Mode
        {
            New,
            Edit,
            Read
        }

        public enum Reciever
        {
            Author,
            Comment
        }

        public MainViewModel()
        {
            UserData = new ObservableCollection<UserInfo>();
            Authors = new List<string> { };
            UserComments = new List<string> { };
            OKCommand = new RelayCommand(o => OK());
            AuthorSelectCommand = new RelayCommand(o => Select(Reciever.Author));
            CommentSelectCommand = new RelayCommand(o => Select(Reciever.Comment));
            CreateNewUserCommand = new RelayCommand(o => SelectMode(Mode.New));
            EditUserInfoCommand = new RelayCommand(o => SelectMode(Mode.Edit));
            ReadUserInfoCommand = new RelayCommand(o => SelectMode(Mode.Read));
        }
        public void OK()
        {
            UserData.Add(new UserInfo() { Name = AuthorName, Comment = UserComment, Id = Guid.NewGuid() });
            Authors.Add(UserData[Index].Name);
            UserComments.Add(UserData[Index].Comment);
        }
        public void Select(Reciever reciever)
        {
            if(reciever == Reciever.Author)
            {
                AuthorName = Authors[Index];
            } 
            else if (reciever == Reciever.Comment)
            {
                UserComment = UserComments[Index];
            }
        }
        public void SelectMode(Mode mode)
        {
            OkIsEnabled = true;
            if (mode == Mode.New)
            {
                CommentWindow commentWindow = new CommentWindow(this);
                commentWindow.Owner = Application.Current.MainWindow;
                commentWindow.ShowDialog();
            }
            else if (mode == Mode.Edit)
            {
                OkIsEnabled = false;
                CommentWindow commentWindow = new CommentWindow(this);
                commentWindow.Owner = Application.Current.MainWindow;
                commentWindow.ShowDialog();
            }
            else if (mode == Mode.Read)
            {
                OkIsEnabled = true;
                CommentWindow commentWindow = new CommentWindow(this);
                commentWindow.Owner = Application.Current.MainWindow;
                commentWindow.ShowDialog();
            }
        }
    }
}