using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Text;

namespace Checkpoint6Elin
{
    public class Spaceship
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Ravioli { get; set; }
        public DateTime PackDateRavioli { get; set; }
        public DateTime BestBeforeRavioli { get; set; }
    }
}
