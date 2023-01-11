using StokYonetim.DAL.EFCore.Abstract;
using StokYonetim.DAL.EFCore.Contexts;
using System.Linq.Expressions;

namespace StokYonetim.DAL.EFCore.Concrete
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T : class, new()
    {
        public readonly StokYonetimDbContext dbContext;
        public RepositoryBase()
        {
            StokYonetimDbContext dbContext = new StokYonetimDbContext();
        }
        public Task<int> CreateAsync(T entity)
        {
            throw new NotImplementedException();
        }

        public Task<int> DeleteAsync(T entity)
        {
            throw new NotImplementedException();
        }

        public Task<IQueryable<T>> FindAllIncludeAsync(Expression<Func<T, bool>> filter = null, params Expression<Func<T, object>>[] input)
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<T>> GetAll(Expression<Func<T, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public Task<T> GetByAsync(Expression<Func<T, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public Task<T> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<int> UpdateAsync(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
