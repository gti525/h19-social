using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ASPNETCoreHeroku.Models;
using ASPNETCoreHeroku.BLL;

namespace ASPNETCoreHeroku.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly ClientBLL _clientBLL;

        public ClientController (ClientContext clientContext)
        {
            _clientBLL = new ClientBLL(clientContext);
        }

        // GET: api/Client
        [HttpGet]
        public ActionResult<Client> Login(string username, string password)
        {
            try
            {
                var client = _clientBLL.Login(username, password);
                return client;
            }
            catch(Exception)
            {
                return NotFound();
            }
        }

        // POST: api/Client
        [HttpPost]
        public void Post([FromBody] Client client)
        {
            try
            {
                 _clientBLL.Register(client);
            }
            catch (Exception)
            {
            }
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
