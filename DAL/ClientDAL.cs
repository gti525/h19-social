﻿using ASPNETCoreHeroku.Models;
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
        int GetClientIdByUsername(string username);
        IEnumerable<FriendRequestResponse> GetClientsByUsername(IEnumerable<string> usernames);
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

        public Client GetClientById(int id)
        {
            return _appDbContext.Client.Find(id);
        }

        public int GetClientIdByUsername(string username)
        {
            return _appDbContext.Client.Where(x => x.Email == username).Single().Id;
        }

        public IEnumerable<FriendRequestResponse> GetClientsByUsername(IEnumerable<string> usernamess)
        {
            foreach (string username in usernamess) {
                var client = _appDbContext.Client.Where(c => c.Email == username).First();
                var temp = new FriendRequestResponse(client.Id, client.FirstName, client.LastName, client.ProfileImage);
                yield return temp;
            }
        }
    }
}
