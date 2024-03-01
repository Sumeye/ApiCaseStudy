using Application.User.Command;
using Domain.Entity;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : BaseController
    {

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateUser createUser)
        {
            Users result = await Mediator.Send(createUser);
            return Created("", result);
        }
    }
}
