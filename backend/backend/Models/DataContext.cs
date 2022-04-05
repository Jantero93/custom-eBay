﻿using Microsoft.EntityFrameworkCore;

namespace backend.Models
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) :
            base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           modelBuilder.UseSerialColumns();
        }

        public DbSet<User> Users { get; set; } = null!;
    }
}
