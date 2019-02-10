
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
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Microsoft.IdentityModel.Logging;

namespace ASPNETCoreHeroku.Services
{
    public interface IClientService
    {
        Client Login(string username, string password);
        void Register(Client client);
        void AddProfilePicture(int id, string picture);
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

                client.Token = this.GenerateToken(client);
                client.Password = null;

                return client;
            }
            catch (Exception e)
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

        public void AddProfilePicture(int id, string picture)
        {
            
        }

        private string GenerateToken (Client client)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            IdentityModelEventSource.ShowPII = true;

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                        new Claim(ClaimTypes.NameIdentifier, client.Id.ToString())
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }
    }
}
