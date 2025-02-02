using Identity.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Identity.Infrastructure.Context
{
    public class ApplicationDbContext(DbContextOptions options) : DbContext(options)
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<EmailConfirmationToken> EmailConfirmationTokens { get; set; }
        public DbSet<RefreshToken> RefreshTokens { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Role>()
                .HasData(
                    new Role() { Id = 1, Name = "Admin"},
                    new Role() { Id = 2, Name = "STaff"},
                    new Role() { Id = 3, Name = "User"}
                );

            Guid adminId = Guid.NewGuid();
            Guid staffId = Guid.NewGuid();
            Guid userId = Guid.NewGuid();

            builder.Entity<User>()
                .HasData(
                    new User()
                    {
                        Id = adminId,
                        Email = "admin@gmail.com",
                        PasswordHash = BCrypt.Net.BCrypt.HashPassword("aA@123"),
                        FullName = "admin",
                        IsEmailConfirmed = true,
                        RoleId = 1
                    },
                    new User()
                    {
                        Id = staffId,
                        Email = "staff@gmail.com",
                        PasswordHash = BCrypt.Net.BCrypt.HashPassword("aA@123"),
                        FullName = "staff",
                        IsEmailConfirmed = true,
                        RoleId = 2
                    },
                    new User()
                    {
                        Id = userId,
                        Email = "user@gmail.com",
                        PasswordHash = BCrypt.Net.BCrypt.HashPassword("aA@123"),
                        FullName = "user",
                        IsEmailConfirmed = true,
                        RoleId = 3
                    }
                );
        }
    }
}
