using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNETCoreHeroku.Models
{
    public class TestUser
    {
        public TestUser(string username, string password)
        {
            username = Username;
            password = Password;
        }

        public string Username { get; set; }
        public string Password { get; set; }
    }
}
