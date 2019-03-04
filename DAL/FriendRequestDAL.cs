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
        IEnumerable<string> GetFriendRequests(int currentUserId, string friendUsername);
        void CreateFriendRequests(int currentUserId, string friendUsername);
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

        public IEnumerable<string> GetFriendRequests(int currentUserId, string friendUsername)
        {
            try
            {
                var currentClient = _clientService.GetClientById(currentUserId);
                var friendRequests = _appDbContext.FriendRequest.Where(x => x.To == currentClient.Email);
                currentClient.PendingFriendRequests = false;

                return friendRequests.Select(x => x.To);
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
    }
}
