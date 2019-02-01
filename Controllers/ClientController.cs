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
        }

        // GET: api/Client
        public ActionResult<Client> GetById(string username, string password)
        {
			try
			{
				var item = _context.Client.Where(client => client.Email == username && client.Password == password).Single();
                return item;
  			}
			catch (Exception)
			{

				return NotFound();
			}
        }
        /*
        [HttpGet("{id}", Name = "GetClient")]
        public ActionResult<Client> GetById(int id)
        {
            var item = _context.client.Find(id);
            if (item == null)
            {
                return NotFound();
            }
            return item;
        }
        */

        // POST: api/Client
        [HttpPost]
        public void Post([FromBody] Client client)
        {
            _context.Client.Add(entity: client);
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
