using System;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ASPNETCoreHeroku.Models;
using ASPNETCoreHeroku.Services;
using Microsoft.AspNetCore.Authorization;
using System.IO;
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
        [AllowAnonymous]
        [HttpPut("{id}")]
        public void UploadImage(int id)
        {
            try
            {
                var path = @"c:\users\jacobpc\pictures\dino.jpg";
                var client = new ImgurClient("1573808507169ed", "64c55ef97e8bb9885002995e9247e4ffaa5b81e6");
                var endpoint = new ImageEndpoint(client);
                IImage image;
                using (var fs = new FileStream(path, FileMode.Open))
                {
                    image = endpoint.UploadImageStreamAsync(fs).GetAwaiter().GetResult();
                }
                Debug.Write("Image uploaded. Image Url: " + image.Link);
            }
            catch (ImgurException imgurEx)
            {
                Debug.Write("An error occurred uploading an image to Imgur.");
                Debug.Write(imgurEx.Message);
            }
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
