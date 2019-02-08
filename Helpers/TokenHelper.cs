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
            var sub = token.Substring("Bearer ".Length).Trim();
            var JSTH = new JwtSecurityTokenHandler();
            var tok = JSTH.ReadJwtToken(sub);
            int id = Int32.Parse(tok.Payload["nameid"].ToString());

            return id;
            //return (int) new JwtSecurityTokenHandler().ReadJwtToken(token.Substring("Bearer ".Length).Trim()).Payload["nameid"];
        }
    }
}
