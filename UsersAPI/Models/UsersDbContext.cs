using Microsoft.EntityFrameworkCore;

namespace UsersAPI.Models
{
    public class UsersDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public UsersDbContext(DbContextOptions<UsersDbContext> options) :
            base(options)
        {
        }
        public UsersDbContext()
        {
            Database.EnsureDeleted();
            Database.EnsureCreated();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasKey(user => user.Guid);
            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Guid  = Guid.NewGuid(),
                    Name = "Admin",
                    Admin = true,
                    Birthday = DateTime.Now,
                    Gender = 1,
                    Login = "Admin",
                    Password = "secret123",
                    CreatedBy = "Init"
                },
                new User
                {
                    Guid = Guid.NewGuid(),
                    Name = "User",
                    Admin = false,
                    Birthday = new DateTime(1979, 5, 12),
                    Gender = 0,
                    Login = "User1",
                    Password = "secret123",
                    CreatedBy = "Init"
                },
                new User
                {
                    Guid = Guid.NewGuid(),
                    Name = "User",
                    Admin = false,
                    Birthday = new DateTime(1999, 1, 12),
                    Gender = 0,
                    Login = "User2",
                    Password = "secret123",
                    CreatedBy = "Init"
                },
                 new User
                 {
                     Guid = Guid.NewGuid(),
                     Name = "User",
                     Admin = false,
                     Birthday = new DateTime(2004, 5, 12),
                     Gender = 0,
                     Login = "User3",
                     Password = "secret123",
                     CreatedBy = "Init"
                 },
                new User
                {
                    Guid = Guid.NewGuid(),
                    Name = "User",
                    Admin = false,
                    Birthday = new DateTime(2003, 1, 12),
                    Gender = 1,
                    Login = "User4",
                    Password = "secret123",
                    CreatedBy = "Init"
                });
            modelBuilder.Entity<User>().HasIndex(user => user.Login).IsUnique();
        }
    }
}
