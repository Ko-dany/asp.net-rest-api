using Assignment2.Models;
using Microsoft.EntityFrameworkCore;

namespace Assignment2.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<User> Users { get; set; }
        public AppDbContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>().HasData(
                    new Book { Id = 1, Title = "And Thene There Were None", Author = "Agatha Cristie", Price = 16.99M, IsAvailable = true },
                    new Book { Id = 1, Title = "A Study in Scarlet", Author = "Arthur Conan Doyle", Price = 15.99M, IsAvailable = true },
                    new Book { Id = 1, Title = "The Secret Garden", Author = "Gilbert Keith Chesterton", Price = 14.99M, IsAvailable = true }
                );
            modelBuilder.Entity<User>().HasData(
                    new User { Id = 1, Username = "admin", Password = "admin", Role = "Admin" },
                    new User { Id = 2, Username = "user", Password = "user", Role = "User" }
                );
        }
    }
}
