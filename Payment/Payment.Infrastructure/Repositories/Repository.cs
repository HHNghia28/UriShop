using Payment.Application.Interfaces;
using Payment.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payment.Infrastructure.Repositories
{
    public class Repository<T>(ApplicationDbContext _context) : IRepository<T> where T : class
    {
        private readonly DbSet<T> _dbSet = _context.Set<T>();

        public async virtual Task<T> GetByIdAsync<TKey>(TKey id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async virtual Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async virtual Task AddAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
        }

        public async virtual Task UpdateAsync(T entity)
        {
            _dbSet.Update(entity);
        }

        public async virtual Task DeleteAsync(T entity)
        {
            _dbSet.Remove(entity);
        }

        public async virtual Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
