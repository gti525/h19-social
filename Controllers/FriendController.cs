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
        [AllowAnonymous]
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
        [AllowAnonymous]
        [Route("friendrequest")]
        [HttpPost]
        public void CreateFriendRequest(string friendUsername)
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

        [AllowAnonymous]
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

        [AllowAnonymous]
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

        [AllowAnonymous]
        [Route("search")]
        [HttpGet]
        public ActionResult<Client> SearchFriend(string friendUsername)
        {
            try
            {
                string token = Request.Headers["Authorization"];
                int id = -1;
                if (token != "" && token != null)
                {
                    id = TokenHelper.GetIdFromToken(token);
                }

                var clientId = _clientService.GetClientIdByUsername(friendUsername);
                var client = _clientService.GetClientById(clientId);

                return client;
            }
            catch (Exception e)
            {
                throw;
            }
        }
    }
}