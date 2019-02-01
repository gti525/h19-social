using ASPNETCoreHeroku.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ASPNETCoreHeroku.DAL
{
    public interface ITicketDAL
    {
        IEnumerable<Ticket> GetTicketsByClientId(int id);
        Ticket GetTicketByTicketId(int id);
        void AddTicket(Ticket ticket);
    }

    public class TicketDAL
    {
        private readonly ClientContext _clientContext;

        public TicketDAL(ClientContext clientContext)
        {
            _clientContext = clientContext;
        }

        public IEnumerable<Ticket> GetTicketsByClientId(int id)
        {
            return _clientContext.Client.Where(c => c.Id == id).SelectMany(c => c.Tickets);
        }

        public Ticket GetTicketByTicketId(int id)
        {
            return _clientContext.Ticket.Find(id);
        }

        public void AddTicket(Ticket ticket)
        {
            _clientContext.Ticket.Add(entity: ticket);
            _clientContext.SaveChanges();
        }
    }
}
