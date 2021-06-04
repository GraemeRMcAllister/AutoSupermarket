using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthService
{
    public interface IJwtAuthenticationManager
    {
        string Authenticate(string user, string password);

    }
}
