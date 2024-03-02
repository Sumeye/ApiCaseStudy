using Domain.Entity;

namespace Application.Services.Authencation
{
    public class AuthentionResult
    {
        public record AuthenticationResult(Users User, string Token);
    }
}
