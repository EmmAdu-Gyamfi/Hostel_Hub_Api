using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hostel_Hub_Api.Repositories.Base
{
    public interface IBaseRepository<T>
    {
        Task<List<T>> GetAllAsync();

        Task<T> GetAsync(object id);

        Task InsertAsync(T entity);

        Task SaveAsync();

        void Delete(T entity);

        void Update(T entity);

        IQueryable<T> Query();
    }
}
