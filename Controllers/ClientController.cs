using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ASPNETCoreHeroku.Models;

namespace ASPNETCoreHeroku.Controllers
{
    [Route("client")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly ClientContext _context;

        public ClientController(ClientContext context)
        {
            _context = context;
            if (_context.client.Count() == 0)
            {
                _context.client.Add(entity: new Client (1,"text@email.com","testpassword","Test","Test",DateTime.Now, "123","something","h9d0d0","whatever","pays") );
                _context.SaveChanges();
            }
        }

        // GET: api/Client
        public ActionResult<Client> GetById(string username, string password)
        {
			try
			{
				var item = _context.client.Where(client => client.email == username).Single();
				return item;
			}
			catch (Exception)
			{

				return NotFound();
			}
            
            /*if (item == null)
            {
                return NotFound();
            }
            return item;*/
        }
        /*
        public string Get(int id)
        {
            return "value";
        }
        */

        // POST: api/Client
        [HttpPost]
        public void Post([FromBody] Client client)
        {
            _context.client.Add(entity: client);
            _context.SaveChanges();
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
