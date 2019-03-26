using ASPNETCoreHeroku.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ASPNETCoreHeroku.DAL
{
    public interface ITicketDAL
    {
        IEnumerable<Ticket> GetTicketsByClientId(int id);
        IEnumerable<Ticket> GetTicketsByClientIdWithoutClientRelation(int id);
        Ticket GetTicketByTicketId(int id);
        void AddTicket(int id, Ticket ticket);
    }

    public class TicketDAL : ITicketDAL
    {
        private readonly AppDbContext _appDbContext;

        public TicketDAL(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public IEnumerable<Ticket> GetTicketsByClientId(int id)
        {
            return _appDbContext.Client.Where(c => c.Id == id).SelectMany(c => c.Tickets);
        }

        public IEnumerable<Ticket> GetTicketsByClientIdWithoutClientRelation(int id)
        {
            IEnumerable<Ticket> tickets = _appDbContext.Client.Where(c => c.Id == id).SelectMany(c => c.Tickets);

            foreach (var ticket in tickets)
            {
                ticket.ClientId = 0;
                ticket.Client = null;
            }

            return tickets;
        }

        public Ticket GetTicketByTicketId(int id)
        {
            return _appDbContext.Ticket.Find(id);
        }

        public void AddTicket(int id, Ticket ticket)
        {
          if (!_appDbContext.Ticket.Any(t => t.UUID == ticket.UUID))
          {
            ticket.ClientId = id;
            _appDbContext.Ticket.Add(entity: ticket);
            _appDbContext.SaveChanges();
          }
          else
          {
            throw new Exception("This ticket UUID is already used");
          }
        }
    }
}
