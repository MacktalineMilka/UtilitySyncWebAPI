using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace UtilityDataAccess.IRepositories
{
    public interface IRepository<T> where T: class
    {
        Task<T> GetAsync(int id);
        IQueryable<T> GetListAsync();
        Task<T> AddAsync(T entity);
        Task<T> UpdateAsync(T entity);
        Task<int> DeleteAsync(T entity);
    }
}
