using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ASPNETCoreHeroku.Models;
using ASPNETCoreHeroku.Services;
using Microsoft.AspNetCore.Authorization;
using System.IdentityModel.Tokens.Jwt;
using System.Net.Http;
using ASPNETCoreHeroku.Helpers;
using System.IO;
using System.Net;
using Imgur.API;
using Imgur.API.Authentication.Impl;
using Imgur.API.Endpoints.Impl;
using Imgur.API.Models;
using Imgur.API.Models.Impl;

namespace ASPNETCoreHeroku.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly IClientService _clientService;

        public ClientController (IClientService clientService)
        {
            _clientService = clientService;
        }

        // GET: api/Client
        [AllowAnonymous]
        [HttpGet]
        public ActionResult<Client> Login(string username, string password)
        {
            try
            {
                var client = _clientService.Login(username, password);
                return client;
            }
            catch(Exception e)
            {
                return NotFound();
            }
        }

        // POST: api/Client
        [AllowAnonymous]
        [HttpPost]
        public void Register([FromBody] Client client)
        {
            try
            {
                _clientService.Register(client);
            }
            catch (Exception e)
            {
                throw;
            }
        }

        // PUT: api/Client/5/photo
        [HttpPut("{id}/photo")]
        public async void UploadImage(int id, [FromBody] string value)
        {
            try
            {
                ImgurClient cli = new ImgurClient("1573808507169ed", "64c55ef97e8bb9885002995e9247e4ffaa5b81e6",
                    new OAuth2Token("f16c1313676f733ec363e2e38ac4a09783ddd7db", "", "json", "1573808507169ed",
                        "am98290", 262800000));
                ImageEndpoint endPoint = new ImageEndpoint(cli);
                IImage img;

                using (var fs = new FileStream(@"C:\Users\JacobPC\Pictures\dino.jpg", FileMode.Open))
                {
                    img = await endPoint.UploadImageStreamAsync(fs);
                }

                Debug.Write(("Img uploaded. IMG URL : " + img.Link));


                //_clientService.AddProfilePicture(id, value);
            }
            catch (ImgurException e)
            {
                Debug.Write(("Error uploading"));
                Debug.Write(e.Message);
            }
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
