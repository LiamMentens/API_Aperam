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

            //context.Personen.AddRange(
            //    new Persoon { Naam = "Test naam", Voornaam = "Test voornaam", Type = 3, }
            //    );
            context.SaveChanges();
        }
    }
}
