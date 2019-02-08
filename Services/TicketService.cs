using ASPNETCoreHeroku.DAL;
using ASPNETCoreHeroku.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNETCoreHeroku.Services 
{
    public interface ITicketService
    {
        IEnumerable<Ticket> GetTicketsByClientId(int id);
        Ticket GetTicketByTicketId(int id);
        void AddTicket(Ticket ticket);
    }

    public class TicketService : ITicketService
    {
        private readonly ITicketDAL _ticketDAL;

        public TicketService(ITicketDAL ticketDAL)
        {
            _ticketDAL = ticketDAL;
        }

        public IEnumerable<Ticket> GetTicketsByClientId(int id)
        {
            return _ticketDAL.GetTicketsByClientId(id);
        }

        public Ticket GetTicketByTicketId(int id)
        {
            return _ticketDAL.GetTicketByTicketId(id);
        }

        public void AddTicket(Ticket ticket)
        {
            _ticketDAL.AddTicket(ticket);
        }
    }
}
