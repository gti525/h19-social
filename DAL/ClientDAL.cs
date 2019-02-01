using ASPNETCoreHeroku.Models;
using System;
using System.Linq;

namespace ASPNETCoreHeroku.DAL
{
    public class ClientDAL
    {
        private readonly ClientContext _context;

        public ClientDAL(ClientContext clientContext)
        {
            _context = clientContext;

        }

        public Client Login(string username, string password)
        {
            try
            {
                var client = _context.Client.Where(x => x.Email == username && x.Password == password).Single();
                return client;
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public void Register(Client client)
        {
            try
            {
                _context.Client.Add(entity: client);
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                throw;
            }
        }
    }
}
