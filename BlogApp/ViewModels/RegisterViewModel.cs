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
    public class RegisterViewModel
    {
        public string FullName { get; set; }

        public string Username { get; set; }
        public string Password { get; set; }


        public RegisterWindow _registerWindow;

        public RegisterCommand registerCommand { get; private set; }
        public BlogDbContext _dbContext;

        public RegisterViewModel(BlogDbContext dbContext, RegisterWindow registerWindow)
        {
            _dbContext = dbContext;
            _registerWindow = registerWindow;
            registerCommand = new RegisterCommand(Register);
        }

        public bool userExist()
        {
            if (Username.Trim() == "") return false;

            foreach (var user in _dbContext.Users.ToList())
            {
                if (user.Username == Username)
                    return true;
            }
            return false;
        }

        public void Register()
        {
            if (FullName.Trim() == "" || Username.Trim() == "" || Password.Trim() == "")
            {
                MessageBox.Show("Complete the data");
                return;
            }

            if (userExist())
            {
                MessageBox.Show("The username exists");
                return;
            }

            User user = new User() { FullName = FullName, Username = Username, Password = Password };   
            _dbContext.Users.Add(user);
            _dbContext.SaveChanges();
            MessageBox.Show("Registration Completed Successfully");
            _registerWindow.Close();
        }
    }
}
