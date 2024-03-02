using static Application.Services.Authencation.AuthentionResult;

namespace Application.Services.Authentication
{
    public interface IAuthenticationService
    {
       Task<AuthenticationResult> Login(string Email, string password);
        AuthenticationResult Register(string firstName, string lastName, string email, string password);
    }
}
