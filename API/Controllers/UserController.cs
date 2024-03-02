using Application.Categories.Command;
using Application.Dto;
using Application.Products.Command;
using Application.User.Command;
using Domain.Entity;
using Microsoft.AspNetCore.Http;
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
