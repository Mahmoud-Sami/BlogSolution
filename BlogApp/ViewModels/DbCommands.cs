using BlogApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.ViewModels
{
    public static class DbCommands
    {
        public static User? userExist(string username)
        {
            List<User> users;
            using (var db = new BlogDbContext())
            {
                users = db.users.ToList();
            }

            foreach (var user in users)
            {
                if (user.Username.ToLower() == username.ToLower())
                    return user;
            }
            return null;
        }

        public static void UserRegister(string fullName, string username, string passowrd)
        {
            User newUser = new User() { FullName = fullName, Username = username.ToLower().Trim(), Password = passowrd };
            using (var db = new BlogDbContext())
            {
                db.users.Add(newUser);
                db.SaveChanges();
            }
        }
    }
}
