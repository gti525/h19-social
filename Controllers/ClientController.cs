using System;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ASPNETCoreHeroku.Models;
using ASPNETCoreHeroku.Services;
using ASPNETCoreHeroku.DAL;
using Microsoft.AspNetCore.Authorization;
using System.IO;
using ASPNETCoreHeroku.Helpers;
using Imgur.API;
using Imgur.API.Authentication.Impl;
using Imgur.API.Endpoints.Impl;
using Imgur.API.Models;
using Imgur.API.Models.Impl;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json.Linq;

namespace ASPNETCoreHeroku.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        //private readonly IClientService _clientService;
        private IClientService _clientService;

        public ClientController (IClientService clientService)
        {
            _clientService = clientService;
        }

        // POST: api/Client/login
        /// <summary>
        /// Recuperer les identifiants d'un client
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        [AllowAnonymous]
        [Route("login")]
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
        /// <summary>
        /// Enregistrer un client
        /// </summary>
        /// <param name="client"></param>
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

        // POST: api/Client/uploadImage
        /// <summary>
        /// Modifier la photo de profil d'un client
        /// </summary>
        /// <param name="file"></param>
        /*
         * https://imgurapi.readthedocs.io/en/latest/quick-start/#upload-image-synchronously-not-recommended
         */
        [HttpPost("uploadImage")]
        public void UploadImageFromPost(IFormFile file)
        {
            string token = Request.Headers["Authorization"];
            int id = -1;
            if (token != "" && token != null)
            {
                id = TokenHelper.GetIdFromToken(token);
            }
            _clientService.AddProfilePicture(id, file);
        }

        [HttpGet]
        public ActionResult<Client> GetClientById()
        {
            string token = Request.Headers["Authorization"];
            int id = -1;
            if (token != "" && token != null)
            {
                id = TokenHelper.GetIdFromToken(token);
            }
            try
            {
                return _clientService.GetClientById(id);
            }
            catch (Exception e)
            {
                throw;
            }
        }

        // DELETE: api/ApiWithActions/5
        /// <summary>
        /// Removes a customer 
        /// </summary>
        /// <param name="id"></param>
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
