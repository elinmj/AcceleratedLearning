using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using InförCheckpoint09.Data;
using InförCheckpoint09.Models;

namespace InförCheckpoint09.Controllers
{
    public class DiciplinsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DiciplinsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Diciplins
        public async Task<IActionResult> Index()
        {
            return View(await _context.Diciplin.ToListAsync());
        }

        // GET: Diciplins/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var diciplin = await _context.Diciplin
                .FirstOrDefaultAsync(m => m.Id == id);
            if (diciplin == null)
            {
                return NotFound();
            }

            return View(diciplin);
        }

        // GET: Diciplins/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Diciplins/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] Diciplin diciplin)
        {
            if (ModelState.IsValid)
            {
                _context.Add(diciplin);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(diciplin);
        }

        // GET: Diciplins/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var diciplin = await _context.Diciplin.FindAsync(id);
            if (diciplin == null)
            {
                return NotFound();
            }
            return View(diciplin);
        }

        // POST: Diciplins/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] Diciplin diciplin)
        {
            if (id != diciplin.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(diciplin);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DiciplinExists(diciplin.Id))
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
            return View(diciplin);
        }

        // GET: Diciplins/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var diciplin = await _context.Diciplin
                .FirstOrDefaultAsync(m => m.Id == id);
            if (diciplin == null)
            {
                return NotFound();
            }

            return View(diciplin);
        }

        // POST: Diciplins/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var diciplin = await _context.Diciplin.FindAsync(id);
            _context.Diciplin.Remove(diciplin);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DiciplinExists(int id)
        {
            return _context.Diciplin.Any(e => e.Id == id);
        }
    }
}
