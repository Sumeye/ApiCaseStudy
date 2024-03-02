using Domain.Entity;

namespace Domain.Repository
{
    public interface IUserRepository : IGenericRepository<Users>
    {
        Task<Users> GetUserByEmail(string email);
    }
}
