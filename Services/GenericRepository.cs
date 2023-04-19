using Conduit1.Models;
using Microsoft.EntityFrameworkCore;

namespace Conduit1.Services
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected readonly ConduitContext _context;

        public GenericRepository(ConduitContext context)
        {
            _context = context;
        }

        public async Task AddAsync(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
