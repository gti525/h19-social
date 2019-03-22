
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
        String AddProfilePicture(int id, IFormFile file);
        Client GetClientById(int id);
        IEnumerable<FriendRequestResponse> GetFriends(int id);
        int GetClientIdByUsername(string username);
        IEnumerable<FriendRequestResponse> GetClientsByUsername(IEnumerable<string> usernames);
        FriendRequestResponse GetClientByUsername(string username);
        void ChangePassword(int id, string newPassword);
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
            catch (Exception e)
            {
              if (e.Message != null)
              {
                throw;
              }
              else
              {
                throw new Exception("Error with registering request. Please look at the json format and be sure the client isn't already in the system" +
                              "\nExample of a client object : " +
                              "\n{\n    \"email\": \"mike@email.com\",\n    \"password\": \"mike\",\n    \"firstName\": \"Mike\",\n    \"lastName\": \"PC\",\n    \"birthDate\": \"1999-01-02T00:00:00\",\n    \"address\": \"123\",\n    \"city\": \"Villemar\",\n    \"postalCode\": \"d0d0d0\",\n    \"province\": \"QC\",\n    \"country\": \"CAN\"\n}");
              }
            }
        }

        public String AddProfilePicture(int id, IFormFile file)
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

                return image.Link;

            }
            catch (ImgurException imgurEx)
            {
                Debug.Write("An error occurred uploading an image to Imgur.");
                Debug.Write(imgurEx.Message);

                throw new Exception( "Imgur Error, image format must be JPG or PNG. \nMore details from Imgur's exception handler : " + imgurEx.Message);
            }
        }


        public void ChangePassword(int id, string newPassword)
        {
            try
            {
                var client = GetClientById(id);
                if (client.Password != newPassword)
                {
                    _clientDAL.ChangePassword(id, newPassword);
                }
                else
                {
                    //Message
                }
            }
            catch (Exception e)
            {
                throw;
            }
        }



        public Client GetClientById(int id)
        {
            return _clientDAL.GetClientById(id);
        }

        public IEnumerable<FriendRequestResponse> GetFriends(int id)
        {
            return _clientDAL.GetFriends(id);
        }

        public int GetClientIdByUsername(string username)
        {
            return _clientDAL.GetClientIdByUsername(username);
        }

        public IEnumerable<FriendRequestResponse> GetClientsByUsername(IEnumerable<string> usernames)
        {
            return _clientDAL.GetClientsByUsername(usernames);
        }

        public FriendRequestResponse GetClientByUsername(string username)
        {
            return _clientDAL.GetClientByUsername(username);
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
