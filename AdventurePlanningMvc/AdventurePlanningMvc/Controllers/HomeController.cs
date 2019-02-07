using AdventurePlanningMvc.Models;
using AdventurePlanningMvc.Services;
using AdventurePlanningMvc.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdventurePlanningMvc.Controllers
{
    public class HomeController : Controller
    {
        private IAdventureRepository _repo;

        public HomeController(IAdventureRepository repo)
        {
            _repo = repo;
        }

        public IActionResult Listall()
        {
            List<Adventure> allAdv = _repo.GetAll();
            return View(allAdv);

        }

        public IActionResult GetById(int id)
        {
            Adventure adv = _repo.GetById(id);
            return View(adv);

        }

        [HttpGet]
        public IActionResult AddAdventure()
        {
            var adv = new AdventureListVm();
            List<Adventure> advList = _repo.GetAll();
            var list = new List<SelectListItem>();

            foreach (var item in advList)
            {
                list.Add(new SelectListItem
                {
                    Value = item.Id.ToString(),
                    Text = item.Name
                });

            }

            adv.AllAdventures = list;

            return View(adv);
        }

        [HttpPost] 
        public IActionResult AddAdventure(AdventureListVm al)
        {
            _repo.Add(al.Adventure);
            return View("adventureadded");

        }
        public IActionResult Index()
        {
            return View("index");
        }

        public IActionResult GetLocation(string location)
        {
            return View("getlocation");
        }
    }
}
