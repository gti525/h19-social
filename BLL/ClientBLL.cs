
using ASPNETCoreHeroku.DAL;
using ASPNETCoreHeroku.Models;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using ASPNETCoreHeroku.Helpers;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace ASPNETCoreHeroku.BLL
{
    public interface IClientBLL
    {
        Client Login(string username, string password);

        void Register(Client client);
    };

    public class ClientBLL : IClientBLL
    {
        private readonly ClientDAL _clientDAL;

        private readonly AppSettings _appSettings;

        public ClientBLL(IOptions<AppSettings> appSettings)
        {
            _appSettings = appSettings.Value;
            _clientDAL = new ClientDAL(clientContext);
        }

        public Client Login(string username, string password)
        {
            try
            {
                var client = _clientDAL.Login(username, password);

                // authentication successful so generate jwt token
                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new Claim[]
                    {
                        new Claim(ClaimTypes.Name, client.Id.ToString())
                    }),
                    Expires = DateTime.UtcNow.AddDays(7),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                };
                var token = tokenHandler.CreateToken(tokenDescriptor);
                client.Token = tokenHandler.WriteToken(token);

                // remove password before returning
                client.Password = null;

                return client;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Register(Client client)
        {
            try
            {
                 _clientDAL.Register(client);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
