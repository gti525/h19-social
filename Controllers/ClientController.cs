﻿using System;
using System.Collections;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ASPNETCoreHeroku.Models;
using ASPNETCoreHeroku.Services;
using ASPNETCoreHeroku.DAL;
using Microsoft.AspNetCore.Authorization;
using System.IO;
using System.Linq;
using ASPNETCoreHeroku.Helpers;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;

namespace ASPNETCoreHeroku.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        //private readonly IClientService _clientService;
        private IClientService _clientService;
        private ITicketService _ticketService;

        public ClientController (IClientService clientService, ITicketService ticketService)
        {
            _clientService = clientService;
            _ticketService = ticketService;
        }

        // POST: api/Client/login
        /// <summary>
        /// Recuperer les identifiants d'un client
        /// </summary>
        /// <param name="credential"></param>
        /// <returns></returns>
        [AllowAnonymous]
        [Route("login")]
        [HttpPost]
        public ActionResult<Client> Login([FromBody] Credential credential)
        {
            try
            {
                var client = _clientService.Login(credential.Email, credential.Password);

                //client.Tickets = _ticketService.GetTicketsByClientIdWithoutClientRelation(client.Id).ToList();

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

        [HttpGet]
        [Route("friend")]
        public ActionResult<IEnumerable<FriendRequestResponse>> GetFriends()
        {
            string token = Request.Headers["Authorization"];
            int id = -1;
            if (token != "" && token != null)
            {
                id = TokenHelper.GetIdFromToken(token);
            }
            try
            {
                return new ActionResult<IEnumerable<FriendRequestResponse>>(_clientService.GetFriends(id));
            }
            catch (Exception e)
            {
                throw;
            }
        }

        // PUT: api/client/resetpassword/5
        /// <summary>
        /// Réinitialiser le mot de passe d'un client
        /// </summary>
        /// <param name="id"></param>
        /// <param name="newPassword"></param>
        /// <returns></returns>
        [AllowAnonymous]
        [Route("resetpassword/{id}")]
        [HttpPut("{id}")]
        public ActionResult<Client> ResetPassword(int id, [FromBody] NewPassword newPassword)
        {
            try
            {
                return _clientService.ChangePassword(id, newPassword.Password);
            }
            catch (Exception e)
            {
                Debug.Write("An error occurred while changing password.");
                Debug.Write(e.Message);
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
