using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using ASPNETCoreHeroku.Models;
using ASPNETCoreHeroku.Services;
using ASPNETCoreHeroku.Helpers;
using DinkToPdf.Contracts;
using Microsoft.AspNetCore.Authorization;
using org.pdfclown.documents.interaction.actions;

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
        public IEnumerable<Ticket> GetTicketsByClientId()
        {
            string token = Request.Headers["Authorization"];
            int id = -1;
            if (token != "" && token != null)
            {
                id = TokenHelper.GetIdFromToken(token);
            }

            return _ticketService.GetTicketsByClientId(id);
        }

        [Route("friend")]
        [HttpGet]
        public IEnumerable<Ticket> GetTicketsByFriendId(int friendId)
        {
            /*string token = Request.Headers["Authorization"];
            int id = -1;
            if (token != "" && token != null)
            {
                id = TokenHelper.GetIdFromToken(token);
            }*/

            return _ticketService.GetTicketsByClientId(friendId);
        }

        [HttpGet("{id}", Name = "GetClient")]
        public ActionResult<Ticket> GetTicketByTicketId(int id)
        {
            return new ActionResult<Ticket>(_ticketService.GetTicketByTicketId(id));
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
              return Ok("The ticket has been created successfully.\n" + ticket.ToString());
            }
            catch (Exception e)
            {
              return BadRequest(e.Message);
            }
        }
        
        [HttpGet("{id}/printPDF")]
        public void PrintTicket(int id)
        {
            _ticketService.printPDF(id);
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
        public void Delete(int id)
        {
            /*var item = _context.Ticket.Find(id);
            if (item != null)
            {
                _context.Ticket.Remove(item);
                _context.SaveChanges();
            }*/
        }
    }
}
