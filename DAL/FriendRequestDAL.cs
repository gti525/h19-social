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
        IEnumerable<string> GetFriendRequests(int currentUserId);
        void CreateFriendRequests(int currentUserId, string friendUsername);
        void AcceptFriend(int currentUserId, string friendUsername);
        void DeleteFriendRequest(int currentUserId, string friendUsername);
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

        public IEnumerable<string> GetFriendRequests(int currentUserId)
        {
            try
            {
                var currentClient = _clientService.GetClientById(currentUserId);
                var friendRequests = _appDbContext.FriendRequest.Where(x => x.To == currentClient.Email);
                currentClient.PendingFriendRequests = false;

                return friendRequests.Select(x => x.From);
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
                var currentClient = _clientService.GetClientById(currentUserId);

                _appDbContext.FriendRequest.Add(new FriendRequest() {
                    From = currentClient.Email,
                    To = friendUsername,
                });

                var friend = _appDbContext.Client.Where(x => x.Email == friendUsername).Single();

                friend.PendingFriendRequests = true;

                _appDbContext.SaveChanges();
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public void AcceptFriend(int currentUserId, string friendUsername)
        {
            try
            {
                var currentClient = _clientService.GetClientById(currentUserId);
                var friendId = _clientService.GetClientIdByUsername(friendUsername);

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

                DeleteFriendRequest(currentUserId, friendUsername);
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public void DeleteFriendRequest(int currentUserId, string friendUsername)
        {
            try
            {
                var currentClient = _clientService.GetClientById(currentUserId);
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
