using NS_Comment.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NS_Comment.Model
{
    class DataBase : Observer
    {
        private string _Name;

        public string Name
        {
            get { return _Name; }
            set { _Name = value; OnPropertyChanged(); }
        }

        private string _Comment;

        public string Comment
        {
            get { return _Comment; }
            set { _Comment = value; OnPropertyChanged(); }
        }

        private Guid _Id;

        public Guid Id
        {
            get { return _Id; }
            set { _Id = value; }
        }

    }
}