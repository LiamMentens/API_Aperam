using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ASP_backend.Models;
using ASP_backend.Services;
using System.Text;
using System.Security.Cryptography;
using Microsoft.AspNetCore.Authorization;

namespace ASP_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersoonController : ControllerBase
    {
        private IUserService _userService;
        private readonly DataContext _context;

        public PersoonController(IUserService userService, DataContext context)
        {
            _userService = userService;
            _context = context;
        }

        [HttpPost("authenticate")]
        public IActionResult Authenticate([FromBody]Persoon userParam)
        {
            // hash password before compare
            //var data = Encoding.ASCII.GetBytes(userParam.Wachtwoord);
            //var sha1 = new SHA1CryptoServiceProvider();
            //userParam.Wachtwoord = Convert.ToBase64String(sha1.ComputeHash(data));

            var persoon = _userService.Authenticate(userParam.Usernaam, userParam.Wachtwoord);

            if (persoon == null)
                return BadRequest(new { message = "usernme or password is incorrect" });

            return Ok(persoon);
        }


        // GET: api/Persoon
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Persoon>>> GetPersonen()
        {
            return await _context.Personen
                .Include(p => p.Type)
                .ToListAsync();
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
        //[Authorize]
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
        //[Authorize]
        [HttpPost]
        public async Task<ActionResult<Persoon>> PostPersoon(Persoon persoon)
        {
            _context.Personen.Add(persoon);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPersoon", new { id = persoon.PersoonID }, persoon);
        }

        // DELETE: api/Persoon/5
        //[Authorize]
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
