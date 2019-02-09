using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Text;

namespace InförCheckpoint6
{

    public class Context : DbContext
    {
        public DbSet<Skidåkare> Skidåkares { get; set; }
        public DbSet<SkidåkTyp> SkidåkTyps { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
              "Server = (localdb)\\mssqllocaldb; Database = InförCheckpoint6;");
        }
    }
}
