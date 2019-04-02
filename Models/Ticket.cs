using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;

namespace ASPNETCoreHeroku.Models
{
    public class Ticket
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(36, ErrorMessage = "A valid UUID must contains 36 characters")]
        public string UUID { get; set; }
        [Required]
        [RegularExpression("^[\\p{L}\\s'.-]+$", ErrorMessage = "Please enter a valid event name")]
        [StringLength(100)]
        public string EventName { get; set; }
        [Required]
        [RegularExpression("^[\\p{L}\\s'.-]+$", ErrorMessage = "Please enter a valid artist name")]
        [StringLength(100)]
        public string Artist { get; set; }
        [Required]
        public DateTime Date { get; set; }
        [Required]
        [RegularExpression("^[\\p{L}\\s'.-]+$", ErrorMessage = "Please enter a valid location")]
        [StringLength(100)]
        public string Location { get; set; }
        public int ClientId { get; set; }
        public virtual Client Client { get; set; }
    }
}
