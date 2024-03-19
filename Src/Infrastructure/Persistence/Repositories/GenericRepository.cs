using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly ApplicationDbContext _dbContext;

        public GenericRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task CreateAsync(T entity)
        {
            await _dbContext.AddAsync(entity);
            await SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            //Implement Soft delete

            _dbContext.Set<T>().Remove(await GetAsync(id));
            await SaveChangesAsync();
        }

        public async Task<IReadOnlyList<T>> GetAllAsync()
        =>await _dbContext.Set<T>().AsNoTracking().ToListAsync();

        public async Task<T> GetAsync(int id)
        =>await _dbContext.Set<T>().FindAsync(id);

        public async Task<bool> IsExisting(int id)
        {
            var entry = await GetAsync(id);
            return entry != null;
        }

        public async Task SaveChangesAsync()
        {
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(T entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            await SaveChangesAsync();
        }
    }
}
