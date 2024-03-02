using AutoMapper;
using Domain.Entity;
using Domain.Repository;
using Infrastructure.Data;
using Microsoft.AspNetCore.Identity;

namespace Infrastructure.Repository
{
    public class UserRepository : GenericRepository<UserApp>, IUserRepository
    {
        private readonly UserManager<UserApp> _userManager;
        private readonly IMapper _mapper;
        public UserRepository(AppDbContext context, UserManager<UserApp> userManager, IMapper mapper) : base(context)
        {
            _userManager = userManager;
            _mapper = mapper;
        }

        public async Task<UserApp> CreateUserAsync(UserApp createUserDto)
        {
            var user = new UserApp
            {
                Email = createUserDto.Email,
                UserName = createUserDto.UserName,
                Name = createUserDto.Name,
                SurName = createUserDto.SurName,
                PasswordHash = createUserDto.PasswordHash,
            };
            var result = await _userManager.CreateAsync(user, createUserDto.PasswordHash);
            if (!result.Succeeded)
            {
                var errors = result.Errors.Select(x => x.Description).ToList();

            }
            return user;
        }


        public async Task<UserApp?> GetUserByNameAsync(string userName)
        {
            // Belirli bir e-posta adresine sahip kullanıcıyı bul
            return await _userManager.FindByNameAsync(userName);
        }
    }
}
