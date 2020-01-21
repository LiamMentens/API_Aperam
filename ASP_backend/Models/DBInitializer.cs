using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP_backend.Models
{
    public class DBInitializer
    {
        public static void Initialize(DataContext context)
        {
            context.Database.EnsureCreated();

            if (context.Personen.Any())
            {
                return;
            }

            context.Personen.AddRange(
                new Persoon { Naam = "Michiels", Usernaam="mnmpower", Voornaam = "Maarten", Type = 1, },
                new Persoon { Naam = "Admin", Usernaam = "Admin", Voornaam = "Admin", Type = 1, },
                new Persoon { Naam = "Gebruiker", Usernaam = "Gebruiker", Voornaam = "Gebruiker", Type = 2, },
                new Persoon { Naam = "g", Usernaam = "g", Voornaam = "g", Type = 2, },
                new Persoon { Naam = "a", Usernaam = "a", Voornaam = "a", Type = 1, }
                );

            context.Types.AddRange(
                new Type { Functie = "Admin"},
                new Type { Functie = "Gebruiker" }
                );

            context.Plaatsen.AddRange(
                new Plaats { Naam ="Loskade", Xcord=0.4444, Ycord=0.4444},
                new Plaats { Naam ="Rol brug", Xcord=0.5555, Ycord=0.5555}
                );

            context.Meldingen.AddRange(
                new Melding { OvertrederID = 3, PlaatsID = 1, Tijdstip = DateTime.Now },
                new Melding { OvertrederID = 4, PlaatsID = 2, Tijdstip = DateTime.Now }
                );
            context.SaveChanges();
        }
    }
}
