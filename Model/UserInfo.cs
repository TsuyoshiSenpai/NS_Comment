using System;

namespace NS_Comment
{
    class UserInfo : Observer
    {
        private string name;

        public string Name
        {
            get { return name; }
            set { name = value; OnPropertyChanged(); }
        }

        private string comment;

        public string Comment
        {
            get { return comment; }
            set { comment = value; OnPropertyChanged(); }
        }

        private Guid id;

        public Guid Id
        {
            get { return id; }
            set { id = value; }
        }

    }
}