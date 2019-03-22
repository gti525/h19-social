using ASPNETCoreHeroku.Models;
using ASPNETCoreHeroku.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

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
    void ChangePassword(int id, string newPassword);
  };

  public class ClientDAL : IClientDAL
  {
    private readonly AppDbContext _appDbContext;
    private ITicketService _ticketService;

    public ClientDAL(AppDbContext appDbContext, ITicketService ticketService)
    {
      _appDbContext = appDbContext;
      _ticketService = ticketService;
    }

    public Client Login(string username, string password)
    {
      try
      {
        password = hash(password);
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
        if (!_appDbContext.Client.Any(c => c.Email == client.Email))
        {
          client.ProfileImage = "https://i.imgur.com/3w7hkeo.jpg";
          client.Password = hash(client.Password);
          _appDbContext.Client.Add(entity: client);
          _appDbContext.SaveChanges();
        }
        else
        {
          throw new Exception("Account already registered. Please use another email.");
        }
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

    public void ChangePassword(int id, string newPassword)
    {
      try
      {
        var client = _appDbContext.Client.Find(id);
        client.Password = hash(newPassword);
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

    public IEnumerable<FriendRequestResponse> GetFriends(int id)
    {
      var friendsIds = _appDbContext.Client.Find(id).Friends;

      if (friendsIds != null)
      {
        foreach (var friendId in friendsIds)
        {
          var client = _appDbContext.Client.Where(c => c.Id == friendId).First();
          var tickets = _ticketService.GetTicketsByClientIdWithoutClientRelation(client.Id).ToList();
          yield return new FriendRequestResponse(client.Id, client.FirstName, client.LastName, client.ProfileImage, tickets);
        }
      }
      else
      {
        yield return null;
      }
    }

    public int GetClientIdByUsername(string username)
    {
      return _appDbContext.Client.Where(x => x.Email == username).Single().Id;
    }

    public IEnumerable<FriendRequestResponse> GetClientsByUsername(IEnumerable<string> usernames)
    {
      foreach (string username in usernames)
      {
        var client = _appDbContext.Client.Where(c => c.Email == username).First();
        yield return new FriendRequestResponse(client.Id, client.FirstName, client.LastName, client.ProfileImage, client.Tickets);
      }
    }

    public FriendRequestResponse GetClientByUsername(string username)
    {
      var client = _appDbContext.Client.Where(c => c.Email == username).First();
      return new FriendRequestResponse(client.Id, client.FirstName, client.LastName, client.ProfileImage, client.Tickets);
    }

    private string hash(string text)
    {
      using (var sha256 = SHA256.Create())
      {
        var hashedPassword = sha256.ComputeHash(Encoding.UTF8.GetBytes(text));
        return BitConverter.ToString(hashedPassword).Replace("-", "").ToLower();
      }
    }
  }
}
