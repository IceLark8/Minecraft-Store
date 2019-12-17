using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using DB.Models.Entities;

namespace DB
{
    public class StoreDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<Feedback> Feedbacks { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<CartItem> CartItems { get; set; }

        public StoreDbContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            //builder.Entity<CartItem>()
            //         .HasNoKey();

            //builder.Entity<Feedback>()
            //    .HasNoKey();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost;Database=MinecraftStore;Trusted_Connection=True;");
        }
    }
}