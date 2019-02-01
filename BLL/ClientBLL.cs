using ASPNETCoreHeroku.DAL;
using ASPNETCoreHeroku.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNETCoreHeroku.BLL
{
    public class ClientBLL
    {
        private readonly ClientDAL _clientDAL;

        public ClientBLL(ClientContext clientContext)
        {
            _clientDAL = new ClientDAL(clientContext);
        }

        public Client Login(string username, string password)
        {
            try
            {
                var client = _clientDAL.Login(username, password);
                return client;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Register(Client client)
        {
            try
            {
                 _clientDAL.Register(client);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
