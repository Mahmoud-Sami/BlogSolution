using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Models
{
    internal class BlogDbContext : DbContext
    {
        public DbSet<User> users { get; set; }
        public DbSet<Post> posts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies().UseSqlServer(@"Data Source=LAPTOP-Q4O24L2B;Database=BlogDB; Integrated Security=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(new User[] { new User() { Id = 1, Username = "admin", Password = "123", FullName = "Mahmoud Sami", RegisterDate = DateTime.Now } });
            base.OnModelCreating(modelBuilder);
        }
    }
}
