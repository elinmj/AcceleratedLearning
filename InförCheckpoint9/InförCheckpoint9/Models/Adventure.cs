using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InförCheckpoint9.Models
{
    public class Adventure
    {
        public int AdventureId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int TypeId { get; set; }
        public string Location { get; set; }
        public DateTime Date { get; set; }
    }
}
