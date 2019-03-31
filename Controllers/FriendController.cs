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
        public ActionResult GetFriendRequests()
        {
            try
            {
                string token = Request.Headers["Authorization"];
                int id = -1;
                if (token != "" && token != null)
                {
                    id = TokenHelper.GetIdFromToken(token);
                }
                return Ok(_friendRequestService.GetFriendRequests(id));
            }
            catch (Exception e)
            {
                return BadRequest("An error occured while retrieving your friend requests");
            }
        }

        // POST: api/Friend
        /// <summary>
        /// ajouter un ami
        /// </summary>
        /// <param name="friendUsername"></param>
        [Route("friendrequest")]
        [HttpPost]
        public ActionResult CreateFriendRequest([FromBody] FriendUsername friendUsername)
        {
            try
            {
                string token = Request.Headers["Authorization"];
                int id = -1;
                if (token != "" && token != null)
                {
                    id = TokenHelper.GetIdFromToken(token);
                }

                if (ModelState.IsValid)
                  _friendRequestService.CreateFriendRequests(id, friendUsername.Username);
            }
            catch (Exception e)
            {
              return BadRequest("An error has occured. Please verify the user's email");
            }

            return Ok("An invitation has been sent to " + friendUsername.Username);
    }

        [Route("accept")]
        [HttpGet]
        public ActionResult AcceptFriendRequest(int FriendId)
        {
            try
            {
                string token = Request.Headers["Authorization"];
                int id = -1;
                if (token != "" && token != null)
                {
                    id = TokenHelper.GetIdFromToken(token);
                }

                if(FriendId != 0)
                  _friendRequestService.AcceptFriendRequests(id, FriendId, true);
                else
                {
                  return NotFound("User with Id " + FriendId +
                                  " is not registered. You might want to annoy him to sign up to our awesome social network!");
                }
            }
            catch (Exception e)
            {
              return BadRequest("An error has occured. Please verify the user's id");
            }

            return Ok("The friend request with " + FriendId + " has been accepted");
        }

        [Route("denie")]
        [HttpGet]
        public ActionResult DenieFriendRequest(int friendId)
        {
            try
            {
                string token = Request.Headers["Authorization"];
                int id = -1;
                if (token != "" && token != null)
                {
                    id = TokenHelper.GetIdFromToken(token);
                }

                if(friendId != 0) 
                  _friendRequestService.AcceptFriendRequests(id, friendId, false);
            }
            catch (Exception e)
            {
              return BadRequest("An error has occured. Please verify the user's id");
            }

            return Ok("The friend request with " + friendId + " has been denied");
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
