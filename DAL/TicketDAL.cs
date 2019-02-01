using ASPNETCoreHeroku.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ASPNETCoreHeroku.DAL
{
    public class TicketDAL
    {
        private readonly ClientContext _context;

        public TicketDAL(ClientContext clientContext)
        {
            _context = clientContext;

        }

        public IEnumerable<Ticket> GetTicketsByClientId(int id)
        {
            return _context.Client.Where(c => c.ClientId == id).SelectMany(c => c.Tickets);
        }

        public Ticket GetTicketByTicketId(int id)
        {
            return _context.Ticket.Find(id);
        }

        public void AddTicket(Ticket ticket)
        {
            _context.Ticket.Add(entity: ticket);
            _context.SaveChanges();
        }
    }
}
