using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ASP_backend.Models;

namespace ASP_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersoonController : ControllerBase
    {
        private readonly DataContext _context;

        public PersoonController(DataContext context)
        {
            _context = context;
        }

        // GET: api/Persoon
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Persoon>>> GetPersonen()
        {
            return await _context.Personen.ToListAsync();
        }

        // GET: api/Persoon/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Persoon>> GetPersoon(long id)
        {
            var persoon = await _context.Personen.FindAsync(id);

            if (persoon == null)
            {
                return NotFound();
            }

            return persoon;
        }

        // PUT: api/Persoon/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPersoon(long id, Persoon persoon)
        {
            if (id != persoon.PersoonID)
            {
                return BadRequest();
            }

            _context.Entry(persoon).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PersoonExists(id))
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

        // POST: api/Persoon
        [HttpPost]
        public async Task<ActionResult<Persoon>> PostPersoon(Persoon persoon)
        {
            _context.Personen.Add(persoon);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPersoon", new { id = persoon.PersoonID }, persoon);
        }

        // DELETE: api/Persoon/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Persoon>> DeletePersoon(long id)
        {
            var persoon = await _context.Personen.FindAsync(id);
            if (persoon == null)
            {
                return NotFound();
            }

            _context.Personen.Remove(persoon);
            await _context.SaveChangesAsync();

            return persoon;
        }

        private bool PersoonExists(long id)
        {
            return _context.Personen.Any(e => e.PersoonID == id);
        }
    }
}
