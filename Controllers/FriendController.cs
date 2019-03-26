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
        private readonly IClientService _clientService;

        public FriendController(IFriendRequestService friendRequestService, IClientService clientService)
        {
            _friendRequestService = friendRequestService;
            _clientService = clientService;
        }

        // GET: api/Fiend
        /// <summary>
        /// Rechercher un ami
        /// </summary>
        /// <param name="friendUsername"></param>
        [Route("friendrequest")]
        [HttpGet]
        public IEnumerable<FriendRequestResponse> GetFriendRequests()
        {
            try
            {
                string token = Request.Headers["Authorization"];
                int id = -1;
                if (token != "" && token != null)
                {
                    id = TokenHelper.GetIdFromToken(token);
                }
                return _friendRequestService.GetFriendRequests(id);
            }
            catch (Exception e)
            {
                throw;
            }
        }

        // POST: api/Friend
        /// <summary>
        /// ajouter un ami
        /// </summary>
        /// <param name="friendUsername"></param>
        [Route("friendrequest")]
        [HttpPost]
        public void CreateFriendRequest([FromBody] FriendUsername friendUsername)
        {
            try
            {
                string token = Request.Headers["Authorization"];
                int id = -1;
                if (token != "" && token != null)
                {
                    id = TokenHelper.GetIdFromToken(token);
                }

                _friendRequestService.CreateFriendRequests(id, friendUsername.Username);
            }
            catch (Exception e)
            {
            }
        }

        [Route("accept")]
        [HttpGet]
        public void AcceptFriendRequest(int FriendId)
        {
            var a = "asdf";
            try
            {
                string token = Request.Headers["Authorization"];
                int id = -1;
                if (token != "" && token != null)
                {
                    id = TokenHelper.GetIdFromToken(token);
                }

                _friendRequestService.AcceptFriendRequests(id, FriendId, true);
            }
            catch (Exception e)
            {
            }
        }

        [Route("denie")]
        [HttpGet]
        public void DenieFriendRequest(int friendId)
        {
            try
            {
                string token = Request.Headers["Authorization"];
                int id = -1;
                if (token != "" && token != null)
                {
                    id = TokenHelper.GetIdFromToken(token);
                }

                _friendRequestService.AcceptFriendRequests(id, friendId, false);
            }
            catch (Exception e)
            {
            }
        }

        [Route("search")]
        [HttpGet]
        public ActionResult SearchFriend(string friendUsername)
        {
            try
            {
                string token = Request.Headers["Authorization"];
                int id = -1;
                if (token != "" && token != null)
                {
                    id = TokenHelper.GetIdFromToken(token);
                }
                
                FriendRequestResponse a = _clientService.GetClientByUsername(friendUsername);
                return Ok(a);
            }
            catch (Exception e)
            {
              return NotFound("The client requested is not a member of My Eventory");
            }
        }
    }
}
