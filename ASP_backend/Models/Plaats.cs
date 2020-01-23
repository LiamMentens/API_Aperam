using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ASP_backend.Models
{
    public class Plaats
    {
        public long plaatsID { get; set; }
        public string Naam { get; set; }
        public double Xcord { get; set; }
        public double Ycord { get; set; }

        
        public virtual ICollection<Melding> Meldingen { get; set; }
    }
}
