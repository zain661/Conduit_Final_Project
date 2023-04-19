using Conduit.DTOs;
using Conduit1.Models;

namespace Conduit.Services
{
    public interface IUserRepository
    {
        Task<User> GetUserAsync(int id);
        Task<IEnumerable<User>> GetUsers();
        Task UpdateUser(User user);
        Task<bool> SaveChangesAsync();
        Task<User> GetName(string name);
    }
}
