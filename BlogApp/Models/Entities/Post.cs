using System;

namespace BlogApp.Models
{
    public class Post : ObservableObject
    {
        #region Fields

        private int _id;
        private string _title;
        private string _body;
        private DateTime _publishDate;
        private User _user;

        #endregion

        #region Properties

        public int Id
        {
            get { return _id; }
            set
            {
                if (_id != value)
                {
                    _id = value;
                    OnPropertyChanged("Id");
                }
            }
        }

        public string Title
        {
            get { return _title; }
            set
            {
                if (_title != value)
                {
                    _title = value;
                    OnPropertyChanged("Title");
                }
            }
        }

        public string Body
        {
            get { return _body; }
            set
            {
                if (_body != value)
                {
                    _body = value;
                    OnPropertyChanged("Body");
                }
            }
        }

        public DateTime PublishDate
        {
            get { return _publishDate; }
            set
            {
                if (_publishDate != value)
                {
                    _publishDate = value;
                    OnPropertyChanged("PublishDate");
                }
            }
        }

        public User User
        {
            get { return _user; }
            set
            {
                if (_user != value)
                {
                    _user = value;
                    OnPropertyChanged("User");
                }
            }
        }
        #endregion


    }
}
