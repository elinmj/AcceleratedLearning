﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InförCheckpoint09.Models
{
    public class Location
    {

        public int Id { get; set; }
        public string Name { get; set; }

        public List<AdventureLocation> AdventureLocations { get; set; }
    }
}
