using Application.Services.Authentication;
using Contracts.Authentication;
using Microsoft.AspNetCore.Mvc;
using static Contracts.Authentication.AuthentionResponse;
using static Contracts.Authentication.LoginRequest;
using static Contracts.Authentication.RegisterRequest;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : BaseController
    {
        private readonly IAuthenticationService _authenticationService;

        public AuthenticationController(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        [HttpPost("register")]
        public IActionResult Register(SingInRequest request)
        {
            var authResult = _authenticationService.Register(request.FirstName, request.LastName, request.Email, request.Password);

            var response = new AuthenticationResponse(
               authResult.User.Id,
               authResult.User.Name,
               authResult.User.SurName,
               authResult.User.Email,
               authResult.Token);

            return Ok(response);
        }

        [HttpPost("login")]
        public IActionResult Login(SignOnReguest request)
        {
            var authResult = _authenticationService.Login(request.Email, request.Password);

            var response = new AuthenticationResponse(
                authResult.Result.User.Id,
                authResult.Result.User.Name,
                authResult.Result.User.SurName,
                authResult.Result.User.Email,
                authResult.Result.Token);

            return Ok(response);
        }
    }
}
