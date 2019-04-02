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
        [EmailAddress(ErrorMessage = "Please enter a valid email address")]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        [RegularExpression("^[\\p{L}\\s'.-]+$", ErrorMessage = "Please enter a valid first name")]
        public string FirstName { get; set; }
        [Required]
        [RegularExpression("^[\\p{L}\\s'.-]+$", ErrorMessage = "Please enter a valid last name")]
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        [StringLength(100)]
        public string Address { get; set; }
        [StringLength(50)]
        [RegularExpression("^[\\p{L}\\s'.-]+$", ErrorMessage = "Please enter a valid city (no special characters and less than 50 characters)")]
        public string City { get; set; }
        [StringLength(7)]
        [RegularExpression("^[A-Za-z]\\d[A-Za-z][ -]?\\d[A-Za-z]\\d$", ErrorMessage = "Please enter a valid postal code (max of 7 characters)")]
        public string PostalCode { get; set; }
        [StringLength(50)]
        [RegularExpression("^[\\p{L}\\s'.-]+$", ErrorMessage = "Please enter a valid province name")]
        public string Province { get; set; }
        [StringLength(50)]
        [RegularExpression("^[\\p{L}\\s'.-]+$", ErrorMessage = "Please enter a valid country name")]
        public string Country { get; set; }
        public string ProfileImage { get; set; } = "https://i.imgur.com/3w7hkeo.jpg";
        public int[] Friends { get; set; }
        public virtual ICollection<Ticket> Tickets { get; set; }
        public string Token { get; set; }
        public bool IsPremium { get; set; } = false;
    }
}
