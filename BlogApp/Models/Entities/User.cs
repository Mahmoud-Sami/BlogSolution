using System;

namespace BlogApp.Models
{
    internal class User
    {
        
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string FullName { get; set; }
        public DateTime RegisterDate { get; set; }
    }
}
