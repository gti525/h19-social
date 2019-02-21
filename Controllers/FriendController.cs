using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASPNETCoreHeroku.Helpers;
using ASPNETCoreHeroku.Models;
using ASPNETCoreHeroku.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ASPNETCoreHeroku.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class FriendController : Controller
    {
        private readonly IFriendRequestService _friendRequestService;

        public FriendController(IFriendRequestService friendRequestService)
        {
            _friendRequestService = friendRequestService;
        }

        [AllowAnonymous]
        [HttpGet]
        public IEnumerable<string> GetFriendRequests(string friendUsername)
        {
            try
            {
                string token = Request.Headers["Authorization"];
                int id = -1;
                if (token != "" && token != null)
                {
                    id = TokenHelper.GetIdFromToken(token);
                }

                return _friendRequestService.GetFriendRequests(id, friendUsername);
            }
            catch (Exception e)
            {
                throw;
            }
        }

        [AllowAnonymous]
        [HttpPost]
        public void CreateFriendRequest([FromBody] string friendUsername)
        {
            try
            {
                string token = Request.Headers["Authorization"];
                int id = -1;
                if (token != "" && token != null)
                {
                    id = TokenHelper.GetIdFromToken(token);
                }

                _friendRequestService.CreateFriendRequests(id, friendUsername);
            }
            catch (Exception e)
            {
            }
        }
    }
}