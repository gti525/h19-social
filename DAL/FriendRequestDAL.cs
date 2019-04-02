using ASPNETCoreHeroku.Models;
using ASPNETCoreHeroku.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNETCoreHeroku.DAL
{
    public interface IFriendRequestDAL
    {
        IEnumerable<FriendRequestResponse> GetFriendRequests(int currentUserId); 
        IEnumerable<FriendRequestResponse> GetFriendRequested(int currentUserId); 
        void CreateFriendRequests(int currentUserId, string friendUsername);
        void AcceptFriend(int currentUserId, int friendId);
        void DeleteFriendRequest(int currentUserId, int friendId);
    };

    public class FriendRequestDAL : IFriendRequestDAL
    {
        private readonly AppDbContext _appDbContext;
        private readonly IClientService _clientService;

        public FriendRequestDAL(AppDbContext appDbContext, IClientService clientService)
        {
            _appDbContext = appDbContext;
            _clientService = clientService;
        }

        public IEnumerable<FriendRequestResponse> GetFriendRequests(int currentUserId)
        {
            try
            {
                var currentClient = _clientService.GetClientById(currentUserId);
                var friendRequestUsernames = _appDbContext.FriendRequest.Where(x => x.To == currentClient.Email).Select(t => t.From);

                var friendRequestClients = _clientService.GetClientsByUsername(friendRequestUsernames);

                return friendRequestClients;
            }
            catch (Exception e)
            {
                throw;
            }
        }

    public IEnumerable<FriendRequestResponse> GetFriendRequested(int currentUserId)
    {
      try
      {
        var currentClient = _clientService.GetClientById(currentUserId);
        var friendRequestUsernames = _appDbContext.FriendRequest.Where(x => x.From == currentClient.Email).Select(t => t.To);

        var friendRequestClients = _clientService.GetClientsByUsername(friendRequestUsernames);

        return friendRequestClients;
      }
      catch (Exception e)
      {
        throw;
      }
    }

    public void CreateFriendRequests(int currentUserId, string friendUsername)
        {
            try
            {
                var friend = _appDbContext.Client.Where(x => x.Email == friendUsername).Single();
                var currentClient = _clientService.GetClientById(currentUserId);

                _appDbContext.FriendRequest.Add(new FriendRequest() {
                    From = currentClient.Email,
                    To = friend.Email,
                });

                //var friend = _appDbContext.Client.Where(x => x.Email == friendUsername).Single();

                _appDbContext.SaveChanges();
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public void AcceptFriend(int currentUserId, int friendId)
        {
            try
            {
                var currentClient = _clientService.GetClientById(currentUserId);

                if (currentClient.Friends == null)
                {
                    currentClient.Friends = new int[1];
                    currentClient.Friends[0] = friendId;
                }
                else
                {
                    var tempFriends = currentClient.Friends;
                    var friendList = new int[tempFriends.Length + 1];

                    for (int i = 0; i < tempFriends.Length; i++)
                    {
                        friendList[i] = tempFriends[i];
                    }

                    friendList[tempFriends.Length] = friendId;
                    currentClient.Friends = friendList;
                }

                _appDbContext.SaveChanges();

                DeleteFriendRequest(currentUserId, friendId);
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public void DeleteFriendRequest(int currentUserId, int friendId)
        {
            try
            {
                var currentClient = _clientService.GetClientById(currentUserId);
                var friendUsername = _clientService.GetClientById(friendId).Email;
                var friendRequest = _appDbContext.FriendRequest.Where(x => x.To == currentClient.Email && x.From == friendUsername).Single();

                _appDbContext.Remove(friendRequest);
                _appDbContext.SaveChanges();
            }
            catch (Exception e)
            {
                throw;
            }
        }
    }
}
