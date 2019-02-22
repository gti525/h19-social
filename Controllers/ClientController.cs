using System;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ASPNETCoreHeroku.Models;
using ASPNETCoreHeroku.Services;
using ASPNETCoreHeroku.DAL;
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
        [Route("api/[controller]/login")]
        [HttpPost]
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

        // PUT: api/Client/5/photo
        /// <summary>
        /// Modifier la photo de profil d'un client
        /// </summary>
        /// <param name="id"></param>
        [AllowAnonymous]
        [HttpPut("{id}")]
        /*
         * https://imgurapi.readthedocs.io/en/latest/quick-start/#upload-image-synchronously-not-recommended
         */
        public void UploadImage(int id)
        {
            _clientService.AddProfilePicture(id);
        }

        [AllowAnonymous]
        [HttpGet("{id}")]
        public ActionResult<Client> GetImage(int id)
        {
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
