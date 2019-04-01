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
        IEnumerable<FriendRequestResponse> GetFriendRequests(int currentUserId); 
        IEnumerable<FriendRequestResponse> GetFriendRequested(int currentUserId); 
        void CreateFriendRequests(int currentUserId, string friendUsername);
        void AcceptFriendRequests(int currentUserId, int friendId, bool accepted);
    };

    public class FriendRequestService : IFriendRequestService
    {
        private readonly IFriendRequestDAL _friendRequestDAL;

        public FriendRequestService(IFriendRequestDAL friendRequestDAL)
        {
            _friendRequestDAL = friendRequestDAL;
        }

        public IEnumerable<FriendRequestResponse> GetFriendRequests(int currentUserId)
        {
            try
            {
                var friendRequests = _friendRequestDAL.GetFriendRequests(currentUserId);

                return friendRequests;
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
        var friendRequested = _friendRequestDAL.GetFriendRequested(currentUserId);

        return friendRequested;
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

        public void AcceptFriendRequests(int currentUserId, int friendId, bool accepted)
        {
            try
            {
                if(accepted)
                {
                    _friendRequestDAL.AcceptFriend(currentUserId, friendId);
                    _friendRequestDAL.AcceptFriend(friendId, currentUserId);
                }
                else
                {
                    _friendRequestDAL.DeleteFriendRequest(currentUserId, friendId);
                }
            }
            catch (Exception e)
            {
                throw;
            }
        }
    }
}
