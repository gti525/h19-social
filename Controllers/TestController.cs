using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;

using ASPNETCoreHeroku.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ASPNETCoreHeroku.Controllers
{
    [Route("test")]
    [ApiController]
    public class TestController : ControllerBase
    {
        private TestUser MyTestUser;
        //private readonly TodoContext _context;

        public TestController(TodoContext context)
        {
            MyTestUser = new TestUser("username","password");
            /*_context = context;
            if (_context.bumb.Count() == 0)
            {
                _context.bumb.Add(new bumb { numb = 10 }); _context.SaveChanges();
            }*/
        }

        // GET: /<controller>/q
        [Route("login")]
        [HttpGet]
        public ActionResult<string> Get(TestUser testUser)
        {
            if (MyTestUser.Username == testUser.Username && MyTestUser.Password == MyTestUser.Password)
            {
                return new ActionResult<string>("true");
            }
            else
            {
                return new ActionResult<string>("false");
            }
            
        }
    }
}
