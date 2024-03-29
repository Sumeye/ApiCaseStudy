﻿using Application.User.Command;
using Domain.Entity;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : BaseController
    {
        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody] CreateUser createUser)
        {
            UserApp result = await Mediator.Send(createUser);
            return Created("", result);
        }

    }
}
