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
    public class PlaatsController : ControllerBase
    {
        private readonly DataContext _context;

        public PlaatsController(DataContext context)
        {
            _context = context;
        }

        // GET: api/Plaats
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Plaats>>> GetPlaatsen()
        {
            return await _context.Plaatsen.ToListAsync();
        }

        // GET: api/Plaats/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Plaats>> GetPlaats(long id)
        {
            var plaats = await _context.Plaatsen.FindAsync(id);

            if (plaats == null)
            {
                return NotFound();
            }

            return plaats;
        }

        // PUT: api/Plaats/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPlaats(long id, Plaats plaats)
        {
            if (id != plaats.plaatsID)
            {
                return BadRequest();
            }

            _context.Entry(plaats).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PlaatsExists(id))
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

        // POST: api/Plaats
        [HttpPost]
        public async Task<ActionResult<Plaats>> PostPlaats(Plaats plaats)
        {
            _context.Plaatsen.Add(plaats);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPlaats", new { id = plaats.plaatsID }, plaats);
        }

        // DELETE: api/Plaats/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Plaats>> DeletePlaats(long id)
        {
            var plaats = await _context.Plaatsen.FindAsync(id);
            if (plaats == null)
            {
                return NotFound();
            }

            _context.Plaatsen.Remove(plaats);
            await _context.SaveChangesAsync();

            return plaats;
        }

        private bool PlaatsExists(long id)
        {
            return _context.Plaatsen.Any(e => e.plaatsID == id);
        }
    }
}
