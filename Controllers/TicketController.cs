using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ASPNETCoreHeroku.Models;
using Microsoft.EntityFrameworkCore;

namespace ASPNETCoreHeroku.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketController : Controller
    {
        private readonly ClientContext _context;

        public TicketController (ClientContext context)
        {
            _context = context;
        }

        // GET: api/Ticket
        [HttpGet]
        public IEnumerable<Ticket> GetTickets()
        {
            return _context.Client.Where(c => c.ClientId == 2).SelectMany(c => c.Tickets);
        }

        // GET: api/Ticket/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }


        [HttpGet("{id}", Name = "GetClient")]
        public ActionResult<Ticket> GetById(int id)
        {
            var item = _context.Ticket.Find(id);
            if (item == null)
            {
                return NotFound();
            }
            return item;
        }

        // POST: api/Ticket
        [HttpPost]
        public void Post([FromBody] Ticket ticket)
        {
            _context.Ticket.Add(entity: ticket);

            _context.SaveChanges();
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
            var item = _context.Ticket.Find(id);
            if (item != null)
            {
                _context.Ticket.Remove(item);
                _context.SaveChanges();
            }
        }
    }
}
