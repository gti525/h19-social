using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ASPNETCoreHeroku.Models
{
    public class Ticket
    {
        [Key]
        public int TicketId { get; set; }
        public string EventName { get; set; }
        public string Artist { get; set; }
        public DateTime Date { get; set; }
        public string Location { get; set; }
        public int ClientId { get; set; }
        public virtual Client Client { get; set; }
    }
}
