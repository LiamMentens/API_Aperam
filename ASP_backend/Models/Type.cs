using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ASP_backend.Models
{
    public class Type
    {
        public long TypeID { get; set; }
        public string Functie { get; set; }



        [NotMapped]
        public virtual ICollection<Persoon> Personen { get; set; }
    }
}
