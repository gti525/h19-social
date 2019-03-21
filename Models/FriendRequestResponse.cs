using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNETCoreHeroku.Models
{
    public class FriendRequestResponse
    {
        public FriendRequestResponse(int clientId, string firstName, string lastName, string profileImage, ICollection<Ticket> tickets)
        {
            ClientId = clientId;
            FirstName = firstName;
            LastName = lastName;
            ProfileImage = profileImage;
            Tickets = tickets;
        }

        public int ClientId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ProfileImage { get; set; }
        public virtual ICollection<Ticket> Tickets { get; set; }
  }
}
