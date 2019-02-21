using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ASPNETCoreHeroku.Models;
using Microsoft.EntityFrameworkCore;
using ASPNETCoreHeroku.Services;
using ASPNETCoreHeroku.Helpers;
using Microsoft.AspNetCore.Authorization;

namespace ASPNETCoreHeroku.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class TicketController : Controller
    {
        private readonly ITicketService _ticketService;

        public TicketController (ITicketService ticketService)
        {
            _ticketService = ticketService;
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
        public void Post([FromBody] Ticket ticket)
        {
            _ticketService.AddTicket(ticket);
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
