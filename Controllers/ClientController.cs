using System;
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
             //if (credential.Email != null && credential.Password != null)
             if(ModelState.IsValid)
              {
                var client = _clientService.Login(credential.Email, credential.Password);

                client.Tickets = _ticketService.GetTicketsByClientIdWithoutClientRelation(client.Id).ToList();

                return Ok(client);
              }
              else
              {
                return BadRequest("An error has occured. Please verify your request format to match : \n" +
                                  "{\n    \"email\": \"jaco@email.com\",\n    \"password\": \"jaco\"\n}");
              }
            }
            catch(Exception e)
            {

                return NotFound(e.Message);
              
            }
        }
        
        // POST: api/Client
        /// <summary>
        /// Enregistrer un client
        /// </summary>
        /// <param name="client"></param>
        [AllowAnonymous]
        [HttpPost]
        public ActionResult Register([FromBody] Client client)
        {
            try
            {
                if(ModelState.IsValid)
                  _clientService.Register(client);
            }
            catch (Exception e)
            {
              return BadRequest(e.Message);
            }

            return Ok(client);
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
        public ActionResult UploadImageFromPost(IFormFile file)
        {
            string token = Request.Headers["Authorization"];
            int id = -1;
            if (token != "" && token != null)
            {
                id = TokenHelper.GetIdFromToken(token);
            }

            try
            {
              return Ok(_clientService.AddProfilePicture(id, file));
            }
            catch (Exception e)
            {
              return BadRequest(e.Message);
            }

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
                return BadRequest("The client does not exists");
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
                var friends = _clientService.GetFriends(id);
                if (friends.First() == null)
                {
                    return null;
                }
                return new ActionResult<IEnumerable<FriendRequestResponse>>(friends);
            }
            catch (Exception e)
            {
                return BadRequest("An error has occured");
            }
        }

        // PUT: api/client/resetpassword/5
        /// <summary>
        /// Réinitialiser le mot de passe d'un client
        /// </summary>
        /// <param name="id"></param>
        /// <param name="newPassword"></param>
        /// <returns></returns>
        [Route("resetpassword")]
        [HttpPatch]
        public ActionResult ResetPassword([FromBody] ClientPassword newPassword)
        {
            string token = Request.Headers["Authorization"];
            int id = -1;
            if (token != "" && token != null)
            {
                id = TokenHelper.GetIdFromToken(token);
            }

            try
            {
                _clientService.ChangePassword(id, newPassword);
                return Ok("Your password has been changed successfully.");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [Route("changePremiumState")]
        [HttpPost]
        public ActionResult ChangePremiumState()
        {
          string token = Request.Headers["Authorization"];
          int id = -1;
          if (token != "" && token != null)
          {
            id = TokenHelper.GetIdFromToken(token);
          }

          try
          {
            return Ok(_clientService.ChangePremiumState(id));
          }
          catch (Exception e)
          {
            return BadRequest("An error has occured, please try again later.");
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
