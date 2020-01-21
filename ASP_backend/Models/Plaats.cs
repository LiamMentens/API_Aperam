using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ASP_backend.Models
{
    public class Plaats
    {
        [Key]
        public long NumberID { get; set; }
        public string Naam { get; set; }
        public double Xcord { get; set; }
        public double Ycord { get; set; }
    }
}
