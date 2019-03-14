using ASPNETCoreHeroku.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ASPNETCoreHeroku.DAL
{
    public interface IClientDAL
    {
        Client Login(string username, string password);
        void Register(Client client);
        void AddProfilePicture(int id, string picture);
        Client GetClientById(int id);
        IEnumerable<FriendRequestResponse> GetFriends(int id);
        int GetClientIdByUsername(string username);
        IEnumerable<FriendRequestResponse> GetClientsByUsername(IEnumerable<string> usernames);
        FriendRequestResponse GetClientByUsername(string username);
        Client ChangePassword(int id, string newPassword);
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
                var client = _appDbContext.Client.Where(x => x.Email == username && x.Password == password).First();
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
                _appDbContext.SaveChanges();
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public Client ChangePassword(int id, string newPassword)
        {
            try
            {
                var client = _appDbContext.Client.Find(id);
                client.Password = newPassword;
                _appDbContext.SaveChanges();
                return client;
            }
            catch (Exception e)
            {
                throw;
            }
        }
        public Client GetClientById(int id)
        {
            return _appDbContext.Client.Find(id);
        }

        public IEnumerable<FriendRequestResponse> GetFriends(int id)
        {
            var friendsIds = _appDbContext.Client.Find(id).Friends;

            foreach(var friendId in friendsIds)
            {
                var client = _appDbContext.Client.Where(c => c.Id == friendId).First();
                yield return new FriendRequestResponse(client.Id, client.FirstName, client.LastName, client.ProfileImage);
            }
        }

        public int GetClientIdByUsername(string username)
        {
            return _appDbContext.Client.Where(x => x.Email == username).Single().Id;
        }

        public IEnumerable<FriendRequestResponse> GetClientsByUsername(IEnumerable<string> usernames)
        {
            foreach (string username in usernames) {
                var client = _appDbContext.Client.Where(c => c.Email == username).First();
                yield return new FriendRequestResponse(client.Id, client.FirstName, client.LastName, client.ProfileImage);
            }
        }

        public FriendRequestResponse GetClientByUsername(string username)
        {
                var client = _appDbContext.Client.Where(c => c.Email == username).First();
                return new FriendRequestResponse(client.Id, client.FirstName, client.LastName, client.ProfileImage);
        }
    }
}
