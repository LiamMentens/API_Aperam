using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ASP_backend.Models
{
    public class Melding
    {
        public long MeldingID { get; set; }
        public long PersoonID { get; set; }
        public long PlaatsID { get; set; }
        public DateTime Tijdstip { get; set; }
        
        public virtual Plaats Plaats { get; set; }
        public virtual Persoon Persoon { get; set; }
    }
}
