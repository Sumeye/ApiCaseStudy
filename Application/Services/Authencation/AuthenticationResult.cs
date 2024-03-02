using Application.Dto;
using Domain.Entity;

namespace Application.Services.Authencation
{
    public class AuthentionResult
    {
        public record AuthenticationResult(UserApp User, TokenDto Token);
    }
}
