﻿using System;
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

        // GET: api/Fiend
        /// <summary>
        /// Rechercher un ami
        /// </summary>
        /// <param name="friendUsername"></param>
        [AllowAnonymous]
        [HttpGet]
        public IEnumerable<string> GetFriendRequests()
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
        [HttpPost]
        public void AcceptFriendRequest(string friendUsername)
        {
            try
            {
                string token = Request.Headers["Authorization"];
                int id = -1;
                if (token != "" && token != null)
                {
                    id = TokenHelper.GetIdFromToken(token);
                }

                _friendRequestService.AcceptFriendRequests(id, friendUsername, true);
            }
            catch (Exception e)
            {
            }
        }

        [AllowAnonymous]
        [Route("denie")]
        [HttpPost]
        public void DenieFriendRequest(string friendUsername)
        {
            try
            {
                string token = Request.Headers["Authorization"];
                int id = -1;
                if (token != "" && token != null)
                {
                    id = TokenHelper.GetIdFromToken(token);
                }

                _friendRequestService.AcceptFriendRequests(id, friendUsername, false);
            }
            catch (Exception e)
            {
            }
        }
    }
}