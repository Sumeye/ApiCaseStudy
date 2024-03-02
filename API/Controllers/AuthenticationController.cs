using Application.Dto;
using Application.Services.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class AuthenticationController : BaseController
    {
        private readonly IAuthenticationService _authenticationService;

        public AuthenticationController(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }


        [HttpPost("login")]
        public IActionResult Login(LoginDto request)
        {
            var authResult = _authenticationService.Login(request);

            var response = new TokenDto
            { 
                AccessToken =  authResult.Result.Token.AccessToken,
                RefreshToken =  authResult.Result.Token.RefreshToken
            };
               

            return Ok(response);
        }
    }
}
