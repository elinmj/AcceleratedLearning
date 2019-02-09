using System;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace Checkpoint6Elin
{
    class SpaceContext : DbContext
    {
        public DbSet<Spaceship> Spaceships { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
              "Server = (localdb)\\mssqllocaldb; Database = Checkpoint6Elin;");
        }

    }
}
