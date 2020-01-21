using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ASP_backend.Models
{
    public class Melding
    {
        [Key]
        public long NumberID { get; set; }
        public long OvertrederID { get; set; }
        public long PlaatsID { get; set; }
        public DateTime Tijdstip { get; set; }
    }
}
