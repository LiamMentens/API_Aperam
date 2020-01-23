using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASP_backend.Models;
using ASP_backend.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ASP_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DashboardUserVMController : Controller
    {
        private readonly DataContext _context;

        public DashboardUserVMController(DataContext context)
        {
            _context = context;
        }

        // GET: api/DashboardUserVM
        [HttpGet]
        public async Task<ActionResult<DashboardUserVM>> GetDashboardUserVM()
        {
            DashboardUserVM vm = new DashboardUserVM();

            List<Tabel> tabellen = new List<Tabel>();
            List<Persoon> personen = new List<Persoon>();
            Melding recentsteMelding = null;

            personen = await _context.Personen
                .Include(p => p.Type)
                .Include(p => p.Meldingen).ThenInclude(p => p.Plaats)
                .ToListAsync();

            foreach (var persoon in personen)
            {
                Tabel tabel = new Tabel();
                if (persoon.Meldingen != null && persoon.Meldingen.Count() != 0)
                {
                    foreach (var melding in persoon.Meldingen)
                    {
                        if (recentsteMelding == null)
                        {
                            recentsteMelding = melding;
                        }
                        if (melding.Tijdstip > recentsteMelding.Tijdstip)
                        {
                            recentsteMelding = melding;
                        }
                    }
                }

                

                tabel.Naam = persoon.Naam;
                tabel.Voornaam = persoon.Voornaam;
                tabel.Type = persoon.Type.Functie;
                tabel.Overtredingen = persoon.Meldingen.Count();
                if (recentsteMelding != null)
                {
                    tabel.Recentste = recentsteMelding.Tijdstip;
                    tabel.Locatie = recentsteMelding.Plaats.Naam;
                }
                tabel.Tagnummer = persoon.PersoonID;

                tabellen.Add(tabel);
            }

            vm.tabellen = tabellen;

            return vm;
        }


    }
}