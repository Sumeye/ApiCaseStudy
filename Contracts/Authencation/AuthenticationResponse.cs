namespace Contracts.Authentication
{
    public class AuthentionResponse
    {
        public record AuthenticationResponse(string Id,string FirstName, string LastName, string Email, string Token);
    }
}
