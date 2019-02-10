using ASPNETCoreHeroku.Models;
using System;
using System.Linq;

namespace ASPNETCoreHeroku.DAL
{
    public interface IClientDAL
    {
        Client Login(string username, string password);
        void Register(Client client);
        void AddProfilePicture(int id, string picture);
    };

    public class ClientDAL : IClientDAL
    {
        private readonly AppDbContext _appDbContext;

        public ClientDAL(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;

        }

        public Client Login(string username, string password)
        {
            try
            {
                var client = _appDbContext.Client.Where(x => x.Email == username && x.Password == password).Single();
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
                _appDbContext.Client.Add(entity: client);
                _appDbContext.SaveChanges();
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public void AddProfilePicture(int id, string picture)
        {
            try
            {
                var client = _appDbContext.Client.Find(id);
                client.ProfileImage = picture;
            }
            catch (Exception e)
            {
                throw;
            }
        }
    }
}
