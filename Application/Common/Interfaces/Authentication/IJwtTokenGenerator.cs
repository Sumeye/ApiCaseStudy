using Application.Dto;
using Domain.Entity;

namespace Application.Common.Interfaces.Authentication
{
    public interface IJwtTokenGenerator
    {
        TokenDto GenerateToken(UserApp users);
    }
}
