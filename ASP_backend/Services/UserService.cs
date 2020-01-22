using ASP_backend.Helpers;
using ASP_backend.Models;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ASP_backend.Services
{
    public class UserService : IUserService
    {
        private readonly AppSettings _appSettings;
        private readonly DataContext _dataContext;
        public UserService(IOptions<AppSettings> appSettings, DataContext dataContext)
        {
            _appSettings = appSettings.Value;
            _dataContext = dataContext;
        }

        public Persoon Authenticate(string username, string password)
        {
            var persoon = _dataContext.Personen.SingleOrDefault(x => x.Usernaam == username && x.Wachtwoord == password);

            
            // return null if user not found
            if (persoon == null)
                return null;

            // authentication successful so generate jwttoken
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim("UserID", persoon.PersoonID.ToString()),
                    new Claim("Email", persoon.Usernaam)
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            persoon.Token = tokenHandler.WriteToken(token);

            // remove password before returning
            persoon.Wachtwoord = null;
            return persoon;
        }
    }
}
