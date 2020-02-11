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


            context.SaveChanges();

            //context.Personen.Add(new Persoon { Naam = "Michiels", Usernaam = "mnmpower", Voornaam = "Maarten", TypeID = 1, Wachtwoord = "R1234-56" });

            context.Personen.AddRange(
                new Persoon { Naam = "Michiels", Usernaam = "mnmpower", Voornaam = "Maarten", TypeID = 1, Wachtwoord = "R1234-56" },
                new Persoon { Naam = "Admin", Usernaam = "Admin", Voornaam = "Admin", TypeID = 1, Wachtwoord = "Admin" },
                new Persoon { Naam = "Mentens", Usernaam = "LiamUser", Voornaam = "Liam", TypeID = 2, Wachtwoord = "1234" },
                new Persoon { Naam = "Peeters", Usernaam = "ThomasUser", Voornaam = "Thomas", TypeID = 2, Wachtwoord = "Gebruiker" },
                new Persoon { Naam = "Vermeuelen", Usernaam = "ServerBoy1", Voornaam = "Jolan", TypeID = 2, Wachtwoord = "linux4life" },
                new Persoon { Naam = "Debruyne", Usernaam = "ServerBoy2", Voornaam = "Edward", TypeID = 2, Wachtwoord = "pfsense" },
                new Persoon { Naam = "Dicaprio", Usernaam = "LeonardoUser", Voornaam = "Leonardo", TypeID = 2, Wachtwoord = "titanic" },
                new Persoon { Naam = "Smeets", Usernaam = "ChristineUser", Voornaam = "Christine", TypeID = 2, Wachtwoord = "netbeans" },
                new Persoon { Naam = "De Peuter", Usernaam = "DDP", Voornaam = "Dirk", TypeID = 2, Wachtwoord = "letterkunde" },
                new Persoon { Naam = "Verboven", Usernaam = "MichielUser", Voornaam = "Michiel", TypeID = 2, Wachtwoord = "intellij" },
                new Persoon { Naam = "Pauwels", Usernaam = "PatrickUser", Voornaam = "Patrick", TypeID = 2, Wachtwoord = "netwerk" }
                );

            context.SaveChanges();
            //y-m-d h-m-s
            context.Meldingen.AddRange(
                new Melding { PersoonID = 3, PlaatsID = 1, Tijdstip = new DateTime(2020, 1, 13, 8, 52, 43) },
                new Melding { PersoonID = 3, PlaatsID = 1, Tijdstip = new DateTime(2019, 12, 3, 5, 32, 42) },
                new Melding { PersoonID = 4, PlaatsID = 2, Tijdstip = new DateTime(2020, 1, 27, 8, 49, 29) },
                new Melding { PersoonID = 5, PlaatsID = 2, Tijdstip = new DateTime(2020, 1, 17, 8, 47, 18) },
                new Melding { PersoonID = 6, PlaatsID = 2, Tijdstip = new DateTime(2019, 12, 24, 18, 50, 15) },
                new Melding { PersoonID = 7, PlaatsID = 2, Tijdstip = new DateTime(2020, 1, 2, 8, 47, 12) },
                new Melding { PersoonID = 7, PlaatsID = 1, Tijdstip = new DateTime(2019, 12, 17, 9, 37, 22) },
                new Melding { PersoonID = 7, PlaatsID = 2, Tijdstip = new DateTime(2020, 1, 27, 8, 47, 12) },
                new Melding { PersoonID = 9, PlaatsID = 1, Tijdstip = new DateTime(2020, 1, 1, 8, 31, 22) },
                new Melding { PersoonID = 9, PlaatsID = 1, Tijdstip = new DateTime(2020, 1, 25, 15, 23, 58) },
                new Melding { PersoonID = 9, PlaatsID = 1, Tijdstip = new DateTime(2020, 1, 16, 12, 01, 10) },
                new Melding { PersoonID = 9, PlaatsID = 2, Tijdstip = new DateTime(2020, 1, 5, 10, 12, 16) },

                new Melding { PersoonID = 9, PlaatsID = 2, Tijdstip = new DateTime(2019, 3, 5, 10, 12, 16) },
                new Melding { PersoonID = 9, PlaatsID = 2, Tijdstip = new DateTime(2020, 4, 5, 10, 12, 16) },
                new Melding { PersoonID = 9, PlaatsID = 2, Tijdstip = new DateTime(2020, 3, 5, 10, 12, 16) },
                new Melding { PersoonID = 9, PlaatsID = 2, Tijdstip = new DateTime(2020, 3, 5, 10, 12, 16) },
                new Melding { PersoonID = 9, PlaatsID = 2, Tijdstip = new DateTime(2020, 3, 5, 10, 12, 16) },
                new Melding { PersoonID = 9, PlaatsID = 2, Tijdstip = new DateTime(2020, 3, 5, 10, 12, 16) },
                new Melding { PersoonID = 9, PlaatsID = 2, Tijdstip = new DateTime(2020, 3, 5, 10, 12, 16) },
                new Melding { PersoonID = 9, PlaatsID = 2, Tijdstip = new DateTime(2020, 3, 5, 10, 12, 16) },

                new Melding { PersoonID = 9, PlaatsID = 1, Tijdstip = new DateTime(2019, 12, 25, 9, 30, 28) }
                );


            context.SaveChanges();
        }
    }
}
