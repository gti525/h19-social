using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNETCoreHeroku.Models
{
    public class FriendUsername
    {
        [EmailAddress(ErrorMessage = "Please enter a valid email address")]
        public string Username { get; set; }
    }
}
