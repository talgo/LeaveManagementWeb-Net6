using LeaveManagement.Web.Contracts;
using LeaveManagement.Web.Data;
using Microsoft.EntityFrameworkCore;

namespace LeaveManagement.Web.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly ApplicationDbContext applicationDbContext;

        public GenericRepository(ApplicationDbContext applicationDbContext)
        {
            this.applicationDbContext = applicationDbContext;
        }
        public async Task<T> AddAsync(T entity)
        {
            await applicationDbContext.AddAsync(entity);
            await applicationDbContext.SaveChangesAsync();
            return entity;
        }

        public async Task DeleteAsync(int id)
        {
            T entity = await applicationDbContext.Set<T>().FindAsync(id);
            applicationDbContext.Set<T>().Remove(entity);
            await applicationDbContext.SaveChangesAsync();
        }

        public async Task<bool> Exists(int id)
        {
            return await GetAsync(id) != null;
        }

        public async Task<List<T>> GetAllAsync()
        {
            return await applicationDbContext.Set<T>().ToListAsync();
        }

        public async Task<T> GetAsync(int? id)
        {
            if(id == null)
                return null;

            return await applicationDbContext.Set<T>().FindAsync(id);
        }

        public async Task UpdateAsync(T entity)
        {
            //applicationDbContext.Entry(entity).State = EntityState.Modified;
            applicationDbContext.Update(entity);
            await applicationDbContext.SaveChangesAsync();
        }
    }
}
