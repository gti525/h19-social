using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ASPNETCoreHeroku.Models
{
    public class Client
    {
        [Key]
        public int Id { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
        public string Province { get; set; }
        public string Country { get; set; }
        public string ProfileImage { get; set; } = "https://i.imgur.com/3w7hkeo.jpg";
        public int[] Friends { get; set; }
        public virtual ICollection<Ticket> Tickets { get; set; }
        public string Token { get; set; }
        public bool IsPremium { get; set; } = false;
    }
}
