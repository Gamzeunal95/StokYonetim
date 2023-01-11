using Microsoft.EntityFrameworkCore;
using StokYonetim.DAL.EFCore.Abstract;
using StokYonetim.DAL.EFCore.Contexts;
using System.Linq.Expressions;

namespace StokYonetim.DAL.EFCore.Concrete
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T : class, new()
    {
        public readonly StokYonetimDbContext dbContext;

        public RepositoryBase(StokYonetimDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<int> CreateAsync(T entity)
        {
            await dbContext.Set<T>().AddAsync(entity);
            return await dbContext.SaveChangesAsync();
        }

        public async Task<int> DeleteAsync(T entity)
        {
            dbContext.Set<T>().Remove(entity);
            return await dbContext.SaveChangesAsync();
        }
        public async Task<int> UpdateAsync(T entity)
        {
            dbContext.Set<T>().Update(entity);
            return await dbContext.SaveChangesAsync();
        }


        public async Task<T?> GetByIdAsync(int id)
        {
            return await dbContext.Set<T>().FindAsync(id);

        }
        public async Task<T?> GetByAsync(Expression<Func<T, bool>> filter)
        {
            if (filter != null)
                return await dbContext.Set<T>().Where(filter).FirstOrDefaultAsync();
            else
                return await dbContext.Set<T>().FirstOrDefaultAsync();
        }
        public async Task<ICollection<T>> GetAllAsync(Expression<Func<T, bool>> filter = null)
        {
            if (filter != null)
                return await dbContext.Set<T>().Where(filter).ToListAsync();
            else
                return await dbContext.Set<T>().ToListAsync();

        }
        public async Task<IQueryable<T>> FindAllIncludeAsync(Expression<Func<T, bool>> filter = null, params Expression<Func<T, object>>[] input)
        {
            var query = dbContext.Set<T>();

            if (filter != null)
                query.Where(filter);
            var result = input.Aggregate(query.AsQueryable(),
            (current, includeprop) => current.Include(includeprop));

            return result;

        }

    }
}
