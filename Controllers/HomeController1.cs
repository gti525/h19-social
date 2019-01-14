﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ASPNETCoreHeroku.Controllers
{
    [Route("yolo")]
    [ApiController]
    public class HomeController1 : Controller
    {
        // GET: /<controller>/
        [HttpGet]
        public ActionResult<string> Get()
        {
            return "test";
        }
    }
}
