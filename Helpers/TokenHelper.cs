using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNETCoreHeroku.Helpers
{
    public static class TokenHelper
    {
        public static int GetIdFromToken(string token)
        {
            return (int) new JwtSecurityTokenHandler().ReadJwtToken(token.Substring("Bearer ".Length).Trim()).Payload["nameid"];
        }
    }
}
