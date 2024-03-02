using Domain.Entity;

namespace Domain.Repository
{
    public interface IUserRepository : IGenericRepository<UserApp>
    {
        Task<UserApp> CreateUserAsync(UserApp users);
        Task<UserApp> GetUserByNameAsync(string userName);
    }
}
