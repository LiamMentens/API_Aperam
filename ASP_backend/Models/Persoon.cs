using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ASP_backend.Models
{
    public class Persoon
    {
        [Key]
        public long PersoonID { get; set; }
        public string Naam { get; set; }
        public string Voornaam { get; set; }
        public long Type { get; set; }
    }
}
