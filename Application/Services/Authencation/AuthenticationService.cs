using Application.Common.Interfaces.Authentication;
using Application.Dto;
using Domain.Entity;
using Domain.Repository;
using Domain.UnitOfWork;
using Microsoft.AspNetCore.Identity;
using static Application.Services.Authencation.AuthentionResult;

namespace Application.Services.Authentication
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IJwtTokenGenerator _jwtTokenGenerator;
        private readonly IUserRepository _userRepository;
        private readonly UserManager<UserApp> _userManager;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IGenericRepository<UserRefreshToken> _userRefreshTokenService;

        public AuthenticationService(IJwtTokenGenerator jwtTokenGenerator,
            IUserRepository userRepository,
            IGenericRepository<UserRefreshToken> userRefreshTokenService,
            UserManager<UserApp> userManager,
            IUnitOfWork unitOfWork
            )
        {
            _jwtTokenGenerator = jwtTokenGenerator;
            _userRepository = userRepository;
            _userRefreshTokenService = userRefreshTokenService;
            _userManager = userManager;
            _unitOfWork = unitOfWork;
        }
        public async Task<AuthenticationResult> Login(LoginDto loginDto)
        {
            if (loginDto == null)
                throw new ArgumentNullException(nameof(loginDto));

            var user = await _userManager.FindByEmailAsync(loginDto.Email);
            if (user == null)
                throw new Exception("User with given email does not exist");

            if (!await _userManager.CheckPasswordAsync(user, loginDto.Password))
                throw new Exception("Invalid password");

            // JWT Token oluştur
            var token = _jwtTokenGenerator.GenerateToken(user);

            var userRefreshToken = _userRefreshTokenService.Where(x => x.UserId == user.Id).SingleOrDefault();
            if (userRefreshToken == null)
            {
                await _userRefreshTokenService.AddAsync(new UserRefreshToken
                {
                    UserId = user.Id,
                    Code = token.RefreshToken,
                });
            }
            else
            {
                userRefreshToken.Code = token.RefreshToken;
            }
            await _unitOfWork.CommitAsync();

            // Oturum açma işlemi başarılı, sonuç nesnesini döndür
            return new AuthenticationResult(user, token);
        }



    }
}
