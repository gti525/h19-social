using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNETCoreHeroku.Models
{
    public class Credential
    {
        [Required]
        [EmailAddress(ErrorMessage = "Please enter a valid email address")]
        public string Email { get; set; }
        [Required]
        [StringLength(50, ErrorMessage = "Passwords must contain less than 50 characters")]
        public string Password { get; set; }
    }
}
