using InförCheckpoint09.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InförCheckpoint09.ViewModels
{
    public class CreateAdventureVm
    {
        public IEnumerable<SelectListItem> AllDiciplins { get; set; }
        public IEnumerable<SelectListItem> AllLocations { get; set; }
        public Adventure Adventure { get; set; }
        public Location Location { get; set; }
    }
}
