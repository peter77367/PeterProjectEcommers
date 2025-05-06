using System.Collections.Generic;
using System.Linq.Expressions;
using Application.Contracts;
using Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructrure
{
    public class GenericRepo<T> : IGenericRepo<T> where T : class
    {
        private readonly PeterDbContext _context;

        private readonly DbSet<T> _dbSet;
        public GenericRepo(PeterDbContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }

        public async Task<T?> GetByIdAsync(Guid id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task AddAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
        }

        public void Update(T entity)
        {
            _dbSet.Update(entity);
        }

        public void Delete(T entity)
        {
            _dbSet.Remove(entity);
        }

        public async Task<T> GetAsync(Expression<Func<T, bool>> predicate)
        {
            return await _context.Set<T>().FirstOrDefaultAsync(predicate);
        }
    }
}
