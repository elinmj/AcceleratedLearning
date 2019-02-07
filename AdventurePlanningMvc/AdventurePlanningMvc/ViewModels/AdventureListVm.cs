using AdventurePlanningMvc.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace AdventurePlanningMvc.ViewModels
{
    public class AdventureListVm
    {
        public IEnumerable<SelectListItem> AllAdventures { get; set; }
        public IEnumerable<SelectListItem> AllTypes { get; set; }
        public Adventure Adventure { get; set; }

    }
}
