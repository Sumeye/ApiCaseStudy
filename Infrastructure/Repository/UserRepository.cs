using Domain.Entity;
using Domain.Repository;
using Infrastructure.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository
{
    public class UserRepository : GenericRepository<Users>, IUserRepository
    {
        private readonly UserManager<Users> _userManager;
        public UserRepository(AppDbContext context, UserManager<Users> userManager) : base(context)
        {
            _userManager = userManager;
        }

        public async Task<Users> GetUserByEmail(string email)
        {
            // Belirli bir e-posta adresine sahip kullanıcıyı bul
            Users user = await _userManager.FindByEmailAsync(email);

            // Eğer kullanıcı bulunamadıysa istisna fırlat
            if (user == null)
            {
                throw new Exception("User with given email does not exist");
            }

            // Kullanıcıyı döndür
            return user;
        }
    }
}
