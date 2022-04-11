using BlogApp.Models;
using BlogApp.ViewModels.Commands;
using BlogApp.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace BlogApp.ViewModels
{
    public class LoginViewModel
    {
        public string Username { get; set; }
        public string Password { get; set; }

        public LoginWindow _loginWindow;

        public LoginCommand loginCommand { get; private set; }
        public BlogDbContext _dbContext;

        public LoginViewModel(BlogDbContext dbContext, LoginWindow loginWindow)
        {
            _dbContext = dbContext;
            _loginWindow = loginWindow;
            loginCommand = new LoginCommand(Login);
        }

        public bool userExist(string username, string password, ref List<User> users)
        {
            foreach (var user in users)
            {
                if (user.Username == username && user.Password == password)
                    return true;
            }
            return false;
        }

        public void Login()
        {
            if (Username.Trim() == "" || Password.Trim() == "")
            {
                MessageBox.Show("Enter login data");
                return;
            }

            List<User> users = _dbContext.Users.ToList();
            bool validLogin = userExist(Username, Password, ref users);
            if (validLogin)
            {
                new MainWindow().Show();
                _loginWindow.Close();
            }
            else
            {
                MessageBox.Show("Wrong data");
            }
        }
    }
}
