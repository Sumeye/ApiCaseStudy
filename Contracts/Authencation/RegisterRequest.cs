namespace Contracts.Authentication
{
    public class RegisterRequest
    {
        public  record SingInRequest(string FirstName, string LastName,string userName, string Email, string Password);
    }
}
