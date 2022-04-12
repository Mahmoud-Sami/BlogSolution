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

        public static User UserEdit(User user, string fullName, string passowrd)
        {
            User _user = null;
            using (var db = new BlogDbContext())
            {
                _user = db.users.Find(user.Id);
                _user.FullName = fullName;
                if (passowrd.Trim() != "")
                    _user.Password = passowrd;
                db.SaveChanges();
            }
            return _user;
        }

        public static void Post(string title, string body, User user)
        {
            using (var db = new BlogDbContext())
            {
                User _user = db.users.Find(user.Id);
                var post = new Post() { Title = title, Body = body, PublishDate = DateTime.Now};
                if (_user.posts == null)
                    _user.posts = new List<Post>();
                _user.posts.Add(post);
                db.SaveChanges();
            }
        
        }

        public static User? getAuthorByPostID(int postID)
        {
            
            using (var db = new BlogDbContext())
            {
                foreach (var u in db.users)
                {
                    foreach (var p in u.posts)
                    {
                        if (p.Id == postID)
                            return u;
                    }
                }

            }
            return null;
        }
    }
}
