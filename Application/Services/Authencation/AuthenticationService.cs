using Application.Common.Interfaces.Authentication;
using Domain.Entity;
using Domain.Repository;
using static Application.Services.Authencation.AuthentionResult;

namespace Application.Services.Authentication
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IJwtTokenGenerator _jwtTokenGenerator;
        private readonly IUserRepository _userRepository;

        public AuthenticationService(IJwtTokenGenerator jwtTokenGenerator, IUserRepository userRepository)
        {
            _jwtTokenGenerator = jwtTokenGenerator;
            _userRepository = userRepository;
        }
        public AuthenticationResult Register(string firstName, string lastName, string email, string password)
        {
            if (_userRepository.GetUserByEmail(email) != null)
            {
                throw new Exception("User with given email already exists");
            }
            //Create User
            var user = new Users { Name = firstName, SurName = lastName, Email = email, PasswordHash = password };
            _userRepository.Add(user);

            //Create JWT Token
            var token = _jwtTokenGenerator.GenerateToken(user);

            return new AuthenticationResult(user, token);
        }


        public async Task<AuthenticationResult> Login(string email, string password)
        {
            // Kullanıcının varlığını doğrula
            Users user = await _userRepository.GetUserByEmail(email);
            if (user == null)
            {
                throw new Exception("User with given email does not exist");
            }

            // Şifrenin doğruluğunu kontrol et
            if (user.PasswordHash != password)
            {
                throw new Exception("Invalid password");
            }

            // JWT Token oluştur
            var token = _jwtTokenGenerator.GenerateToken(user);

            // Oturum açma işlemi başarılı, sonuç nesnesini döndür
            return new AuthenticationResult(user, token);
        }



    }
}
