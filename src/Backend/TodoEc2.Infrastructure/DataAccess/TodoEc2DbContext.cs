﻿using Microsoft.EntityFrameworkCore;
using TodoEc2.Domain.Entities;

namespace TodoEc2.Infrastructure.DataAccess
{
    public class TodoEc2DbContext: DbContext
    {
        public TodoEc2DbContext(DbContextOptions options) : base(options) { }

        public DbSet<User> Users { get; set; }

        public DbSet<Todo> Todos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(TodoEc2DbContext).Assembly);
        }
    }
}
