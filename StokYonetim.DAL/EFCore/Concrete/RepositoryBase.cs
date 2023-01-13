using Microsoft.EntityFrameworkCore;
using StokYonetim.DAL.EFCore.Abstract;
using StokYonetim.DAL.EFCore.Contexts;
using StokYonetim.Entities;
using System.Linq.Expressions;

namespace StokYonetim.DAL.EFCore.Concrete
{
    // virtual olması daha sonrasında diğer kısımlarda ezerek yani override ederek kullanmak istediğimzide kolaylık sağlar.
    public class RepositoryBase<T> : IRepositoryBase<T> where T : BaseEntity, new()
    {
        public readonly StokYonetimDbContext dbContext;

        public RepositoryBase(StokYonetimDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async virtual Task<int> CreateAsync(T entity)
        {
            try
            {
                await dbContext.Set<T>().AddAsync(entity);
                return await dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return 0;
        }

        public async virtual Task<int> DeleteAsync(T entity)
        {
            var model = dbContext.Set<T>().FirstOrDefault(x => x.Id == entity.Id);
            if (model != null)
            {
                dbContext.Set<T>().Remove(model);
                return await dbContext.SaveChangesAsync();
            }
            return 0;
        }
        public async virtual Task<int> UpdateAsync(T entity)
        {
            dbContext.Set<T>().Update(entity);
            return await dbContext.SaveChangesAsync();
        }


        public async virtual Task<T?> GetByIdAsync(int id)
        {
            return await dbContext.Set<T>().FindAsync(id);

        }

        public async virtual Task<T?> GetByAsync(Expression<Func<T, bool>> filter)
        {
            if (filter != null)
                return await dbContext.Set<T>().Where(filter).FirstOrDefaultAsync();
            else
                return await dbContext.Set<T>().FirstOrDefaultAsync();
        }
        public async virtual Task<ICollection<T>> GetAllAsync(Expression<Func<T, bool>> filter = null)
        {
            if (filter != null)
                return await dbContext.Set<T>().Where(filter).ToListAsync();
            else
                return await dbContext.Set<T>().ToListAsync();

        }
        public async virtual Task<IQueryable<T>> FindAllIncludeAsync(Expression<Func<T, bool>> filter = null, params Expression<Func<T, object>>[] input)
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
