using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ASP_backend.Models
{
    public class Type
    {
        [Key]
        public long NumberID { get; set; }
        public string Functie { get; set; }
        public String Wachtwoord { get; set; }
    }
}
