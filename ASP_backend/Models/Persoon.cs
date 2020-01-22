using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ASP_backend.Models
{
    public class Persoon
    {
        public long PersoonID { get; set; }
        public string Naam { get; set; }
        public string Voornaam { get; set; }
        public string Usernaam { get; set; }
        public long TypeID { get; set; }
        public String Wachtwoord { get; set; }


        [NotMapped]
        public ICollection<Melding> Meldingen { get; set; }

        [NotMapped]
        public Type type { get; set; }

        [NotMapped]
        public string Token { get; set; }
    }
}
