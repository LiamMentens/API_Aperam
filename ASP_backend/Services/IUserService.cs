using ASP_backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP_backend.Services
{
    public interface IUserService
    {
        Persoon Authenticate(string email, string password);
    }
}
