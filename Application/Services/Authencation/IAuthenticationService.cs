using Application.Dto;
using static Application.Services.Authencation.AuthentionResult;

namespace Application.Services.Authentication
{
    public interface IAuthenticationService
    {
       Task<AuthenticationResult> Login(LoginDto loginDto);
    }
}
