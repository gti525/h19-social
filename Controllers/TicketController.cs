using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using ASPNETCoreHeroku.Models;
using ASPNETCoreHeroku.Services;
using ASPNETCoreHeroku.Helpers;
using DinkToPdf.Contracts;
using Microsoft.AspNetCore.Authorization;
using org.pdfclown.documents.interaction.actions;
using Action = System.Action;

namespace ASPNETCoreHeroku.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class TicketController : Controller
    {
        private readonly ITicketService _ticketService;
        private IConverter _converter;

        public TicketController (ITicketService ticketService, IConverter converter)
        {
            _ticketService = ticketService;
            _converter = converter;
        }

        // GET: api/Ticket
        /// <summary>
        /// Recuperer les tickets d'un client
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult GetTicketsByClientId()
        {
            string token = Request.Headers["Authorization"];
            int id = -1;
            if (token != "" && token != null)
            {
                id = TokenHelper.GetIdFromToken(token);
            }

            try
            {
              return Ok(_ticketService.GetTicketsByClientId(id));
            }
            catch (Exception e)
            {
              return BadRequest("An error has occured while retrieving the tickets. Please verify the user's id.");
            }
        }

        [Route("friend")]
        [HttpGet]
        public ActionResult GetTicketsByFriendId(int friendId)
        {
            /*string token = Request.Headers["Authorization"];
            int id = -1;
            if (token != "" && token != null)
            {
                id = TokenHelper.GetIdFromToken(token);
            }*/
            try
            {
              return Ok(_ticketService.GetTicketsByClientId(friendId));
            }
            catch (Exception e)
            {
              return BadRequest("An error has occured. Please verify your friend's id");
            }
        }

        [HttpGet("{id}", Name = "GetClient")]
        public ActionResult GetTicketByTicketId(int id)
        {
          try
          {
            return Ok(_ticketService.GetTicketByTicketId(id));
          }
          catch (Exception e)
          {
            return BadRequest("An error has occured while retrieving the ticket. Please verify your ticket id");
          }
            
        }

        // POST: api/Ticket
        /// <summary>
        /// Reserver un ticket
        /// </summary>
        /// <param name="ticket"></param>
        [HttpPost]
        public ActionResult Post([FromBody] Ticket ticket)
        {
            string token = Request.Headers["Authorization"];
            int id = -1;
            if (token != "" && token != null)
            {
                id = TokenHelper.GetIdFromToken(token);
            }

            try
            {
              _ticketService.AddTicket(id, ticket);
              return Ok(ticket);
            }
            catch (Exception e)
            {
              return BadRequest(e.Message);
            }
        }
        
        [HttpGet("{id}/printPDF")]
        public ActionResult PrintTicket(int id)
        {
            //_ticketService.printPDF(id);
            return Conflict(
              "A call has been made to printTicket. The current version of the application should not call this endpoint. Please fix this.");
        }

        // PUT: api/Ticket/5
        /// <summary>
        /// Remplacer le ticket d'un client specifique
        /// </summary>
        /// <param name="id"></param>
        /// <param name="value"></param>
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        /// <summary>
        /// Supprimer le ticket d'un client
        /// </summary>
        /// <param name="id"></param>
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
          return BadRequest("Nop nop nop. To delete anything in here, please make a cheque to mr. Jacob PC.");
        }
    }
}
