using ASPNETCoreHeroku.DAL;
using ASPNETCoreHeroku.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNETCoreHeroku.Services
{
    public interface IFriendRequestService
    {
        IEnumerable<string> GetFriendRequests(int currentUserId, string friendUsername);
        void CreateFriendRequests(int currentUserId, string friendUsername);
    };

    public class FriendRequestService : IFriendRequestService
    {
        private readonly IFriendRequestDAL _friendRequestDAL;

        public FriendRequestService(IFriendRequestDAL friendRequestDAL)
        {
            _friendRequestDAL = friendRequestDAL;
        }

        public IEnumerable<string> GetFriendRequests(int currentUserId, string friendUsername)
        {
            try
            {
                var friendRequests = _friendRequestDAL.GetFriendRequests(currentUserId, friendUsername);

                return friendRequests;
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
                _friendRequestDAL.CreateFriendRequests(currentUserId, friendUsername);
            }
            catch (Exception e)
            {
                throw;
            }
        }
    }
}
