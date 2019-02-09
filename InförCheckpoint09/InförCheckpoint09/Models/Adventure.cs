using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InförCheckpoint09.Models
{
    public class Adventure
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Days { get; set; }
        public DateTime Date { get; set; }

        public int DiciplinId { get; set; }
        public Diciplin Diciplin { get; set; }

        public List<AdventureLocation> AdventureLocations { get; set; }
    }
}
