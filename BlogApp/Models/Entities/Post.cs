using System;

namespace BlogApp.Models
{
    public class Post
    {
        public User User { get; set; }
        public int Id { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public DateTime PublishDate { get; set; }
    }
}
