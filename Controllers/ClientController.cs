using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ASPNETCoreHeroku.Models;

namespace ASPNETCoreHeroku.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly ClientContext _context;

        public ClientController(ClientContext context)
        {
            _context = context;
            if (_context.Clients.Count() == 0)
            {
                _context.Clients.Add(entity: new Client (1,"text@email.com","testpassword","Test","Test",DateTime.Now, "123","something","h9d0d0","whatever","pays") );
                _context.SaveChanges();
            }
        }

        // GET: api/Client
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Client/5
        [HttpGet("{id}", Name = "GetClient")]
        public ActionResult<Client> GetById(int id)
        {
            var item = _context.Clients.Find(id);
            if (item == null)
            {
                return NotFound();
            }
            return item;
        }
        /*
        public string Get(int id)
        {
            return "value";
        }
        */

        // POST: api/Client
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Client/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
