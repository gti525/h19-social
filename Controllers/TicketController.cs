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

namespace ASPNETCoreHeroku.Controllers
{
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
        [HttpGet]
        public IEnumerable<Ticket> GetTicketsByClientId()
        {
            string token = Request.Headers["Authorization"];
            var id = TokenHelper.GetIdFromToken(token);

            return _ticketService.GetTicketsByClientId(id);
        }

        [HttpGet("{id}", Name = "GetClient")]
        public ActionResult<Ticket> GetTicketByTicketId(int id)
        {
            return new ActionResult<Ticket>(_ticketService.GetTicketByTicketId(id));
        }

        // POST: api/Ticket
        [HttpPost]
        public void Post([FromBody] Ticket ticket)
        {
            _ticketService.AddTicket(ticket);
        }

        // PUT: api/Ticket/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
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
