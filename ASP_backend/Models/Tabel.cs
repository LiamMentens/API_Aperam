using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP_backend.Models
{
    public class Tabel
    {
        public long Tagnummer { get; set; }
        public string Naam { get; set; }
        public string Voornaam { get; set; }
        public string Type { get; set; }
        public int Overtredingen { get; set; }
        public DateTime Recentste { get; set; }
        public string Locatie { get; set; }

    }
}
