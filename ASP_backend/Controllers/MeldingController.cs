﻿using System;
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
            return await _context.Meldingen.ToListAsync();
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
            if (id != melding.NumberID)
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
            _context.Meldingen.Add(melding);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMelding", new { id = melding.NumberID }, melding);
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
            return _context.Meldingen.Any(e => e.NumberID == id);
        }
    }
}
