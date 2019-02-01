using ASPNETCoreHeroku.Models;
using System;
using System.Linq;

namespace ASPNETCoreHeroku.DAL
{
    public interface IClientDAL
    {
        Client Login(string username, string password);
        void Register(Client client);
    };

    public class ClientDAL : IClientDAL
    {
        private readonly ClientContext _clientContext;

        public ClientDAL(ClientContext clientContext)
        {
            _clientContext = clientContext;

        }

        public Client Login(string username, string password)
        {
            try
            {
                var client = _clientContext.Client.Where(x => x.Email == username && x.Password == password).Single();
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
                _clientContext.Client.Add(entity: client);
                _clientContext.SaveChanges();
            }
            catch (Exception e)
            {
                throw;
            }
        }
    }
}
