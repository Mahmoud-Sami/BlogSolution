using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Models
{
    public class BlogDbContext : DbContext
    {
        private const string connectionString = @"Server=LAPTOP-Q4O24L2B;Database=BlogDB;Integrated Security=True;";
        public DbSet<User> Users { get; set; }
        public DbSet<Post> Posts { get; set; } 
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(new User[] { new User() {Id = 1, Username = "admin", Password = "123", FullName = "Mahmoud Sami", RegisterDate = DateTime.Now } });
            base.OnModelCreating(modelBuilder);
        }
    }
}
