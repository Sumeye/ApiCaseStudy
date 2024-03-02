namespace Contracts.Authentication
{
    public class LoginRequest
    {
        public record SignOnReguest(string Email, string Password);
    }
}
