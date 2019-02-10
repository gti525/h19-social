﻿using ASPNETCoreHeroku.Models;
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

        public Ticket GetTicketByTicketId(int id)
        {
            return _appDbContext.Ticket.Find(id);
        }

        public void AddTicket(Ticket ticket)
        {
            _appDbContext.Ticket.Add(entity: ticket);
            _appDbContext.SaveChanges();
        }
    }
}