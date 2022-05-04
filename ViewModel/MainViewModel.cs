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

        private bool showAuthorsListButton;

        public bool ShowAuthorsListButton
        {
            get { return showAuthorsListButton; }
            set { showAuthorsListButton = value; OnPropertyChanged(); }
        }

        private bool showCommentsListButton;

        public bool ShowCommentsListButton
        {
            get { return showCommentsListButton; }
            set { showCommentsListButton = value; OnPropertyChanged(); }
        }

        private Visibility authorsListVisibility;

        public Visibility AuthorsListVisibility
        {
            get { return authorsListVisibility; }
            set { authorsListVisibility = value; OnPropertyChanged(); }
        }

        private Visibility commentsListVisibility;

        public Visibility CommentsListVisibility
        {
            get { return commentsListVisibility; }
            set { commentsListVisibility = value; OnPropertyChanged(); }
        }


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
            set { if(value != authorName) authorName = value; OnPropertyChanged(); CheckOkButtonMode(); }
        }

        private string userComment;

        public string UserComment
        {
            get { return userComment; }
            set { if (value != userComment) userComment = value; OnPropertyChanged(); CheckOkButtonMode(); }
        }
        public ObservableCollection<string> Authors
        { get; set; }
        public ObservableCollection<string> UserComments 
        { get; set; }

        private bool okIsEnabled;

        public bool OkIsEnabled
        {
            get { return okIsEnabled; }
            set { okIsEnabled = value; OnPropertyChanged(); }
        }

        public Mode SelectedMode;

        private bool authorsListIsShowed;

        public bool AuthorsListIsShowed
        {
            get { return authorsListIsShowed; }
            set { authorsListIsShowed = value; }
        }

        private bool commentsListIsShowed;

        public bool CommentsListIsShowed
        {
            get { return commentsListIsShowed; }
            set { commentsListIsShowed = value; }
        }


        #endregion
        #region commands
        public RelayCommand OKCommand
        { get; set; }
        public RelayCommand AuthorSelectCommand
        { get; set; }
        public RelayCommand CommentSelectCommand
        { get; set; }
        public RelayCommand ShowAuthorsListCommand
        { get; set; }
        public RelayCommand ShowCommentsListCommand
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

        public enum ListType
        {
            AuthorsList,
            CommentsList
        }
        public MainViewModel(Mode mode)
        {
            SelectedMode = mode;
            CheckListMode();
            AuthorsListVisibility = Visibility.Collapsed;
            CommentsListVisibility = Visibility.Collapsed;
            AuthorsListIsShowed = false;
            CommentsListIsShowed = false;
            UserData = new ObservableCollection<UserInfo>();
            Authors = new ObservableCollection<string> { };
            UserComments = new ObservableCollection<string> { };
            TestEditMode(mode);
            OKCommand = new RelayCommand(o => OK());
            AuthorSelectCommand = new RelayCommand(o => Select(Reciever.Author));
            CommentSelectCommand = new RelayCommand(o => Select(Reciever.Comment));
            ShowAuthorsListCommand = new RelayCommand(o => ShowList(ListType.AuthorsList));
            ShowCommentsListCommand = new RelayCommand(o => ShowList(ListType.CommentsList));
        }
        public void CheckOkButtonMode()
        {
            if (SelectedMode == Mode.New || SelectedMode == Mode.Edit)
            {
                if (string.IsNullOrEmpty(AuthorName) && string.IsNullOrEmpty(UserComment))
                {
                    OkIsEnabled = false;
                }
                else
                {
                    OkIsEnabled = true;
                }
            }
            if (SelectedMode == Mode.Read)
            {
                OkIsEnabled = false;
            }
        }
        public void OK()
        {
            if (SelectedMode == Mode.New)
            {
                UserData.Add(new UserInfo() { Name = AuthorName, Comment = UserComment, Id = Guid.NewGuid() });
                Authors.Add(UserData[Index].Name);
                UserComments.Add(UserData[Index].Comment);
                Index++;
                ShowAuthorsListButton = true;
                ShowCommentsListButton = true;
            }
            else if (SelectedMode == Mode.Edit)
            {
                for (int i = 0; i < UserData.Count; i++)
                {
                    if (UserData[i].Name.Equals(AuthorName))
                    {
                        UserData[i].Comment = UserComment;
                        UserComments[i] = UserComment;
                    }
                    else if (UserData[i].Comment.Equals(UserComment))
                    {
                        UserData[i].Name = AuthorName;
                        Authors[i] = AuthorName;
                    }
                }
            }
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
        public void ShowList(ListType listType)
        {
            if (listType == ListType.AuthorsList)
            {
                if (AuthorsListIsShowed)
                {
                    AuthorsListVisibility = Visibility.Collapsed;
                    CommentsListVisibility = Visibility.Collapsed;
                    AuthorsListIsShowed = false;
                    CommentsListIsShowed = false;
                    CheckListMode();
                }
                else
                {
                    AuthorsListVisibility = Visibility.Visible;
                    CommentsListVisibility = Visibility.Collapsed;
                    AuthorsListIsShowed = true;
                    CommentsListIsShowed = false;
                    CheckListMode();
                }
            }
            else if (listType == ListType.CommentsList)
            {
                if (CommentsListIsShowed)
                {
                    CommentsListVisibility = Visibility.Collapsed;
                    AuthorsListVisibility = Visibility.Collapsed;
                    CommentsListIsShowed = false;
                    AuthorsListIsShowed = false;
                    CheckListMode();
                }
                else
                {
                    CommentsListVisibility = Visibility.Visible;
                    AuthorsListVisibility = Visibility.Collapsed;
                    CommentsListIsShowed = true;
                    AuthorsListIsShowed = false;
                    CheckListMode();
                }
            }
        }
        public void CheckListMode()
        {
            if (Index == 0)
            {
                ShowAuthorsListButton = false;
                ShowCommentsListButton = false;
            }
        }
        public void TestEditMode(Mode mode)
        {
            if (mode == Mode.Edit || mode == Mode.Read)
            {
                UserData.Add(new UserInfo() { Name = "TestName1", Comment = "TestComment1", Id = Guid.NewGuid() });
                Authors.Add(UserData[Index].Name);
                UserComments.Add(UserData[Index].Comment);
                Index++;
                UserData.Add(new UserInfo() { Name = "TestName2", Comment = "TestComment2", Id = Guid.NewGuid() });
                Authors.Add(UserData[Index].Name);
                UserComments.Add(UserData[Index].Comment);
                Index++;
                ShowAuthorsListButton = true;
                ShowCommentsListButton = true;
                AuthorName = Authors[0];
                UserComment = UserComments[0];
            }
        }
    }
}