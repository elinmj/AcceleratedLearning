using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using InförCheckpoint09.Data;
using InförCheckpoint09.Models;
using InförCheckpoint09.ViewModels;

namespace InförCheckpoint09.Controllers
{
    public class AdventuresController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AdventuresController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Display(int id)
        {
            var y = await _context.Adventure.Include(x => x.Diciplin).Where(x => x.DiciplinId == id).ToListAsync();
            return View("Index", y);
        }

        // GET: Adventures
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Adventure.Include(a => a.Diciplin);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Adventures/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var adventure = await _context.Adventure
                .Include(a => a.Diciplin)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (adventure == null)
            {
                return NotFound();
            }

            return View(adventure);
        }

        // GET: Adventures/Create
        public IActionResult Create()
        {
            //ViewData["DiciplinName"] = new SelectList(_context.Diciplin, "Id", "Name");
            //return View();
            var vm = new CreateAdventureVm();

            var listofdiciplins = _context.Diciplin;


            var list = new List<SelectListItem>();
            foreach (var diciplin in listofdiciplins)
            {
                list.Add(new SelectListItem
                {
                    Text = diciplin.Name,
                    Value = diciplin.Id.ToString(),
                }
                );
            }


            var listoflocations = _context.Locations;


            var list2 = new List<SelectListItem>();
            foreach (var locations in listoflocations)
            {
                list2.Add(new SelectListItem
                {
                    Text = locations.Name,
                    Value = locations.Id.ToString(),
                }
                );
            }

            vm.AllDiciplins = list;
            vm.AllLocations = list2;
            return View(vm);
        }

        // POST: Adventures/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Description,Days,Date,DiciplinId,LocationId")] Adventure adventure)
        {
            if (ModelState.IsValid)
            {
                _context.Add(adventure);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DiciplinId"] = new SelectList(_context.Diciplin, "Id", "Id", adventure.DiciplinId);
            return View(adventure);
        }

        // GET: Adventures/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var adventure = await _context.Adventure.FindAsync(id);
            if (adventure == null)
            {
                return NotFound();
            }

            ViewData["DiciplinId"] = new SelectList(_context.Diciplin, "Id", "Id", adventure.DiciplinId);

            var listofdiciplins = _context.Diciplin;

            var vm = new CreateAdventureVm();

            var list = new List<SelectListItem>();
            foreach (var diciplin in listofdiciplins)
            {
                list.Add(new SelectListItem
                {
                    Text = diciplin.Name,
                    Value = diciplin.Id.ToString(),

                }
                );
            }

            vm.Adventure = await _context.Adventure.FindAsync(id);

            vm.AllDiciplins = list;
            return View(vm);
            //return View(adventure);
        }

        // POST: Adventures/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Description,Days,Date,DiciplinId,LocationId")] Adventure adventure)
        {
            if (id != adventure.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(adventure);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AdventureExists(adventure.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["DiciplinId"] = new SelectList(_context.Diciplin, "Id", "Id", adventure.DiciplinId);
            return View(adventure);
        }

        // GET: Adventures/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var adventure = await _context.Adventure
                .Include(a => a.Diciplin)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (adventure == null)
            {
                return NotFound();
            }

            return View(adventure);
        }

        // POST: Adventures/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var adventure = await _context.Adventure.FindAsync(id);
            _context.Adventure.Remove(adventure);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AdventureExists(int id)
        {
            return _context.Adventure.Any(e => e.Id == id);
        }
    }
}
