using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using InförCheckpoint09.Models;

namespace InförCheckpoint09.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AdventureLocation>().HasKey(s => new { s.AdventureId, s.LocationId });
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Adventure> Adventure { get; set; }
        public DbSet<Diciplin> Diciplin { get; set; }
        public DbSet<Location> Locations { get; set; }

    }
}
