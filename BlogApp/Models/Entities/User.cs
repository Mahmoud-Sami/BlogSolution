using System;

namespace BlogApp.Models
{
    public class User : ObservableObject
    {
        #region Fields

        private int _id;
        private string _username;
        private string _password;
        private string _fullName;
        private DateTime _registerDate;

        #endregion

        #region Properties

        public int Id {
            get { return _id; }
            set
            {
                if (_id != value) {
                    _id = value;
                    OnPropertyChanged("Id");
                }
            }
        }

        public string Username
        {
            get { return _username; }
            set
            {
                if (_username != value)
                {
                    _username = value;
                    OnPropertyChanged("Username");
                }
            }
        }

        public string Password
        {
            get { return _password; }
            set
            {
                if (_password != value)
                {
                    _password = value;
                    OnPropertyChanged("Password");
                }
            }
        }

        public string FullName
        {
            get { return _fullName; }
            set
            {
                if (_fullName != value)
                {
                    _fullName = value;
                    OnPropertyChanged("FullName");
                }
            }
        }

        public DateTime RegisterDate
        {
            get { return _registerDate; }
            set
            {
                if (_registerDate != value)
                {
                    _registerDate = value;
                    OnPropertyChanged("RegisterDate");
                }
            }
        }

        #endregion
    }
}
