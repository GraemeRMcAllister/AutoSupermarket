using AuthService.Database;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace AuthService
{
    public class JwtAuthenticationManager : IJwtAuthenticationManager
    {

        DatabaseContext db;
        private readonly string key;

        public ClaimsIdentity Subject { get; private set; }

        public JwtAuthenticationManager(string key)
        {
            db = new DatabaseContext();
            this.key = key;
        }


        public JwtAuthenticationManager()
        {
            db = new DatabaseContext();
        }


        public string Authenticate(string username, string password)
        {
            if (!db.UserCredentials.Any(u => u.UserName == username && u.Password == password))
            {
                return null;
            }


            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenKey = Encoding.ASCII.GetBytes(key);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, username)

                }),
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(tokenKey), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
