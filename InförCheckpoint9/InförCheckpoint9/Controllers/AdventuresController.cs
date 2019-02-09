using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using InförCheckpoint9.Data;
using InförCheckpoint9.Models;

namespace InförCheckpoint9.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdventuresController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public AdventuresController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Adventures
        [HttpGet]
        public IEnumerable<Adventure> GetAdventure()
        {
            return _context.Adventure;
        }

        // GET: api/Adventures/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAdventure([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var adventure = await _context.Adventure.FindAsync(id);

            if (adventure == null)
            {
                return NotFound();
            }

            return Ok(adventure);
        }

        // PUT: api/Adventures/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAdventure([FromRoute] int id, [FromBody] Adventure adventure)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != adventure.AdventureId)
            {
                return BadRequest();
            }

            _context.Entry(adventure).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AdventureExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Adventures
        [HttpPost]
        public async Task<IActionResult> PostAdventure([FromBody] Adventure adventure)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Adventure.Add(adventure);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAdventure", new { id = adventure.AdventureId }, adventure);
        }

        // DELETE: api/Adventures/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAdventure([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var adventure = await _context.Adventure.FindAsync(id);
            if (adventure == null)
            {
                return NotFound();
            }

            _context.Adventure.Remove(adventure);
            await _context.SaveChangesAsync();

            return Ok(adventure);
        }

        private bool AdventureExists(int id)
        {
            return _context.Adventure.Any(e => e.AdventureId == id);
        }
    }
}