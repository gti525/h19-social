﻿
using ASPNETCoreHeroku.DAL;
using ASPNETCoreHeroku.Models;
using System;
using System.Drawing;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mime;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using ASPNETCoreHeroku.Helpers;
using Imgur.API.Models.Impl;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Microsoft.IdentityModel.Logging;
using Imgur.API.Models;
using Imgur.API.Endpoints.Impl;
using Imgur.API.Authentication.Impl;
using System.Diagnostics;
using Imgur.API;
using Image = System.Drawing.Image;

namespace ASPNETCoreHeroku.Services
{
    public interface IClientService
    {
        Client Login(string username, string password);
        void Register(Client client);
        void AddProfilePicture(int id, IFormFile file);
        Client GetClientById(int id);
        int GetClientIdByUsername(string username);
        IEnumerable<FriendRequestResponse> GetClientsByUsername(IEnumerable<string> usernames);
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

        public void AddProfilePicture(int id, IFormFile file)
        {
            try
            {
                // Possibilité d'envoyer des images à Imgur dans les formats suivants : JPG/PNG, Base64 et fichier bin
                //var path = @"c:\users\jacobpc\pictures\base64_decrypt.bin";
                var filePath = Path.GetTempFileName();

                if (file.Length > 0)
                    using (var stream = new FileStream(filePath, FileMode.Create))
                        file.CopyTo(stream);

                //var path = @"c:\users\jacobpc\pictures\dino.jpg";
                var client = new ImgurClient("1573808507169ed", "64c55ef97e8bb9885002995e9247e4ffaa5b81e6");
                var endpoint = new ImageEndpoint(client);
                IImage image;

                //image = endpoint.UploadImageStreamAsync(filePath).GetAwaiter().GetResult();

                using (var fs = new FileStream(filePath, FileMode.Open))
                {
                    image = endpoint.UploadImageStreamAsync(fs).GetAwaiter().GetResult();
                }

                Debug.Write("Image uploaded. Image Url: " + image.Link);

                _clientDAL.AddProfilePicture(id, image.Link);

            }
            catch (ImgurException imgurEx)
            {
                Debug.Write("An error occurred uploading an image to Imgur.");
                Debug.Write(imgurEx.Message);
            }
        }

        public Client GetClientById(int id)
        {
            return _clientDAL.GetClientById(id);
        }

        public int GetClientIdByUsername(string username)
        {
            return _clientDAL.GetClientIdByUsername(username);
        }

        public IEnumerable<FriendRequestResponse> GetClientsByUsername(IEnumerable<string> usernames)
        {
            var a = _clientDAL.GetClientsByUsername(usernames);
            return a;
            
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
