using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNETCoreHeroku.Models
{
    public class FriendRequestResponse
    {
        public FriendRequestResponse(int clientId, string firstName, string lastName, string profileImage)
        {
            ClientId = clientId;
            FirstName = firstName;
            LastName = lastName;
            ProfileImage = profileImage;
        }

        public int ClientId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ProfileImage { get; set; }
    }
}
