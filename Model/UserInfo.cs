using System;

namespace NS_Comment
{
    class UserInfo : Observer
    {
        private string name;

        public string Name
        {
            get { return name; }
            set { if(value != name) name = value; OnPropertyChanged(); }
        }

        private string comment;

        public string Comment
        {
            get { return comment; }
            set { if(value != comment) comment = value; OnPropertyChanged(); }
        }

        private Guid id;

        public Guid Id
        {
            get { return id; }
            set { if(value != id) id = value; }
        }

    }
}