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
            context.Types.AddRange(
                new Type { Functie = "Admin" },
                new Type { Functie = "Gebruiker" }
                );

            context.Plaatsen.AddRange(
                new Plaats { Naam = "Loskade", Xcord = 0.4444, Ycord = 0.4444 },
                new Plaats { Naam = "Rol brug", Xcord = 0.5555, Ycord = 0.5555 }
                );

            //context.Personen.AddRange(
            //    new Persoon { Naam = "Michiels", Usernaam = "mnmpower", Voornaam = "Maarten", TypeID = 1, Wachtwoord = "R1234-56" },
            //    new Persoon { Naam = "Admin", Usernaam = "Admin", Voornaam = "Admin", TypeID = 1, Wachtwoord = "Admin" },
            //    new Persoon { Naam = "Gebruiker", Usernaam = "Gebruiker", Voornaam = "Gebruiker", TypeID = 2, Wachtwoord = "Gebruiker" },
            //    new Persoon { Naam = "g", Usernaam = "g", Voornaam = "g", TypeID = 2, Wachtwoord = "g" },
            //    new Persoon { Naam = "a", Usernaam = "a", Voornaam = "a", TypeID = 1, Wachtwoord = "g" }
            //    );

            //context.Meldingen.AddRange(
            //    new Melding { PersoonID = 3, PlaatsID = 1, Tijdstip = DateTime.Now },
            //    new Melding { PersoonID = 4, PlaatsID = 2, Tijdstip = DateTime.Now }
            //    );


            context.SaveChanges();
        }
    }
}
