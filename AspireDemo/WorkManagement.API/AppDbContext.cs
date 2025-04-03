﻿using Microsoft.EntityFrameworkCore;

namespace WorkManagement.API
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<WorkUnit> WorkUnits { get; set; }
    }
}