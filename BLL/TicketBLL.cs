using ASPNETCoreHeroku.DAL;
using ASPNETCoreHeroku.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNETCoreHeroku.BLL
{
    public class TicketBLL
    {
        private readonly TicketDAL _ticketDAL;

        public TicketBLL(ClientContext clientContext)
        {
            _ticketDAL = new TicketDAL(clientContext);
        }

        public IEnumerable<Ticket> GetTicketsById(int id)
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
