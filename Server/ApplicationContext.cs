using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Server
{
    public class ApplicationContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Chat> Chats { get; set; }
        public DbSet<Message> Messages { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasKey(u => u.Id);
            modelBuilder.Entity<Chat>().HasKey(c => c.Id);
            modelBuilder.Entity<Message>().HasKey(m => m.Id);
            modelBuilder.Entity<User>().HasMany(u => u.Chats).WithMany(c => c.Users);
            modelBuilder.Entity<User>().HasMany(u => u.Messages).WithOne(m => m.User);
            modelBuilder.Entity<Chat>().HasMany(c => c.Messages).WithOne(m => m.Chat);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var builder = new ConfigurationBuilder();
            builder.SetBasePath(Directory.GetCurrentDirectory());
            builder.AddJsonFile("C:\\Users\\cefe_a8xp\\source\\repos\\MessengerWPF\\Server\\appsettings.json");
            var config = builder.Build();
            string connectionString = config.GetConnectionString("DefaultConnection");
            optionsBuilder.UseSqlServer(connectionString);
            base.OnConfiguring(optionsBuilder);
        }
    }
}
