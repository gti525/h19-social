using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNETCoreHeroku.Models
{
    public class FriendRequest
    {
        [Key]
        public int Id { get; set; }
        [EmailAddress(ErrorMessage = "Please enter a valid email address")]
        public string From { get; set; }
        [EmailAddress(ErrorMessage = "Please enter a valid email address")]
        public string To { get; set; }
    }
}
