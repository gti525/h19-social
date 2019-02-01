
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

namespace ASPNETCoreHeroku.Services
{
    public interface IClientService
    {
        Client Login(string username, string password);
        void Register(Client client);
    };

    public class ClientService : IClientService
    {
        private readonly IClientDAL _clientDAL;
        private readonly AppSettings _appSettings;

        public ClientService(IOptions<AppSettings> appSettings, IClientDAL clientDAL)
        {
            _appSettings = appSettings.Value;
            _clientDAL = clientDAL;
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
