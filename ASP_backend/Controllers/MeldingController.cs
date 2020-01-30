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
    public class MeldingController : ControllerBase
    {
        private readonly DataContext _context;

        public MeldingController(DataContext context)
        {
            _context = context;
        }

        // GET: api/Melding
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Melding>>> GetMeldingen()
        {
            var meldingen = await _context.Meldingen.ToListAsync();

            foreach (var melding in meldingen)
            {
                var plaats = await _context.Plaatsen.Where(p => p.plaatsID == melding.PlaatsID).SingleOrDefaultAsync();
                var persoon = await _context.Personen.Where(p => p.PersoonID == melding.PersoonID).SingleOrDefaultAsync();

                melding.Plaats = plaats;
                melding.Persoon = persoon;
            }

            return meldingen;
        }

        // GET: api/Melding/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Melding>> GetMelding(long id)
        {
            var melding = await _context.Meldingen.FindAsync(id);

            if (melding == null)
            {
                return NotFound();
            }

            return melding;
        }

        // PUT: api/Melding/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMelding(long id, Melding melding)
        {
            if (id != melding.MeldingID)
            {
                return BadRequest();
            }

            _context.Entry(melding).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MeldingExists(id))
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

        // POST: api/Melding
        [HttpPost]
        public async Task<ActionResult<Melding>> PostMelding(Melding melding)
        {
            if (melding.Tijdstip == null)
            {
                melding.Tijdstip = DateTime.Now;
            }

            _context.Meldingen.Add(melding);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMelding", new { id = melding.MeldingID }, melding);
        }

        // DELETE: api/Melding/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Melding>> DeleteMelding(long id)
        {
            var melding = await _context.Meldingen.FindAsync(id);
            if (melding == null)
            {
                return NotFound();
            }

            _context.Meldingen.Remove(melding);
            await _context.SaveChangesAsync();

            return melding;
        }

        private bool MeldingExists(long id)
        {
            return _context.Meldingen.Any(e => e.MeldingID == id);
        }


        [HttpGet]
        [Route("countEachMonth")]
        public async Task<List<int>> GetCountEachMonth(string year)
        {
            List<int> countMonthList = new List<int>();
            for (int i = 1; i <= 12; i++)
            {
                countMonthList.Add(await _context.Meldingen.Where(m => m.Tijdstip.Month.ToString() == i.ToString() && m.Tijdstip.Year.ToString() == year).CountAsync());
            }

            return countMonthList;
        }
    }
}
