using ASP_backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP_backend.ViewModels
{
    public class DashboardUserVM
    {
        public ICollection<Tabel> tabellen { get; set; }
    }
}
