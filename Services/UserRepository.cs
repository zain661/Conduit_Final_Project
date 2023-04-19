using Conduit1.Models;
using Conduit1.Services;
using Microsoft.EntityFrameworkCore;

namespace Conduit.Services
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        
        public UserRepository(ConduitContext context) : base(context)
        {
        }
        public async Task<IEnumerable<User>> GetUsers()
        {
            var users = await _context.Users.OrderBy(a => a.UserId).ToListAsync();
            return users;
        }
        public async Task<User> GetUserAsync(int id)
        {
           var user = await _context.Users.Where(a => a.UserId == id).FirstOrDefaultAsync();
            return user;
        }
        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync() >= 0);
        }
        public async Task UpdateUser(User user)
        {
            _context.Users.Update(user);
            await _context.SaveChangesAsync();

        }
        public async Task<User> GetName(string name)
        {
           var user =  await _context.Users.Where(a => a.Username == name).FirstOrDefaultAsync();
           return user;
        }
    }
}
