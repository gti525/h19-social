﻿using System;
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
        public string From { get; set; }
        public string To { get; set; }
    }
}
