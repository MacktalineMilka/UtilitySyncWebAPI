using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using UtilityDataAccess.IRepositories;

namespace UtilityDataAccess.Repositories
{
    public class Repostiory<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private readonly UtilityDBContext utilityDBContext;

        public Repostiory(UtilityDBContext utilityDBContext)
        {
            this.utilityDBContext  = utilityDBContext;
        }
        public async Task<TEntity> AddAsync(TEntity entity)
        {
           await utilityDBContext.AddAsync(entity);
           await utilityDBContext.SaveChangesAsync();
           return entity;
        } 

        public async Task<int> DeleteAsync(TEntity entity)
        {
            utilityDBContext.Remove(entity);
            var id = await utilityDBContext.SaveChangesAsync();
            return id;
        } 

        public async Task<TEntity> GetAsync(int id)
        {
            return await  utilityDBContext.Set<TEntity>().FindAsync(id);
        } 

        public  IQueryable<TEntity> GetListAsync()
        {
            return utilityDBContext.Set<TEntity>().AsQueryable();
        } 

        public async Task<TEntity> UpdateAsync(TEntity entity)
        {
            utilityDBContext.Update(entity);
            await utilityDBContext.SaveChangesAsync();
            return entity;
        }
    }
}
