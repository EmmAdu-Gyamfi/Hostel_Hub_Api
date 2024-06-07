using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hostel_Hub_Api.Repositories.Base
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class, new()
    {
        private readonly DbContext _dbContext;

        public BaseRepository(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Delete(T entity)
        {
            _dbContext.Set<T>().Remove(entity);
        }

        public async Task<List<T>> GetAllAsync()
        {
            var entities = await _dbContext.Set<T>().ToListAsync();

            return entities;
        }

        public async Task<T> GetAsync(object id)
        {
            var entity = await _dbContext.Set<T>().FindAsync(id);

            return entity;
        }

        public async Task InsertAsync(T entity)
        {
            await _dbContext.Set<T>().AddAsync(entity);
        }

        public IQueryable<T> Query()
        {
            var entity = _dbContext.Set<T>().AsQueryable();

            return entity;
        }

        public async Task SaveAsync()
        {
            await _dbContext.SaveChangesAsync();
        }

        public void Update(T entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
        }
    }
}
