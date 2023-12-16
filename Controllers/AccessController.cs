﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace IdentityGuard.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class AccessController : ControllerBase
    {
        [HttpGet]
        [Authorize(Policy = "MinimumAge")]
        public IActionResult Get()
        {
            return Ok("Access Granted!");
        }
    }
}
