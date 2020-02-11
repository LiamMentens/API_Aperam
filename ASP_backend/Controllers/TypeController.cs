using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ASP_backend.Models;
using Type = ASP_backend.Models.Type;
using Microsoft.AspNetCore.Authorization;

namespace ASP_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TypeController : ControllerBase
    {
        private readonly DataContext _context;

        public TypeController(DataContext context)
        {
            _context = context;
        }

        // GET: api/Type
        [Authorize]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Type>>> GetTypes()
        {
            return await _context.Types.ToListAsync();
        }

        // GET: api/Type/5
        [Authorize]
        [HttpGet("{id}")]
        public async Task<ActionResult<Models.Type>> GetType(long id)
        {
            var @type = await _context.Types.FindAsync(id);

            if (@type == null)
            {
                return NotFound();
            }

            return @type;
        }

        // PUT: api/Type/5
        [Authorize]
        [HttpPut("{id}")]
        public async Task<IActionResult> PutType(long id, Type @type)
        {
            if (id != @type.TypeID)
            {
                return BadRequest();
            }

            _context.Entry(@type).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TypeExists(id))
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

        // POST: api/Type
        [Authorize]
        [HttpPost]
        public async Task<ActionResult<Type>> PostType(Type @type)
        {
            _context.Types.Add(@type);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetType", new { id = @type.TypeID }, @type);
        }

        // DELETE: api/Type/5
        [Authorize]
        [HttpDelete("{id}")]
        public async Task<ActionResult<Type>> DeleteType(long id)
        {
            var @type = await _context.Types.FindAsync(id);
            if (@type == null)
            {
                return NotFound();
            }

            _context.Types.Remove(@type);
            await _context.SaveChangesAsync();

            return @type;
        }

        private bool TypeExists(long id)
        {
            return _context.Types.Any(e => e.TypeID == id);
        }
    }
}
