using StokYonetim.BL.Abstract;
using StokYonetim.DAL.EFCore.Concrete;
using StokYonetim.DAL.EFCore.Contexts;
using StokYonetim.Entities;
using System.Linq.Expressions;

namespace StokYonetim.BL.Concrete
{
    public class ManagerBase<T> : IManagerBase<T> where T : BaseEntity, new()
    {
        public ManagerBase(StokYonetimDbContext dbContext) // ctrl. property yaptık bu sefer
        {
            RepositoryBase = new RepositoryBase<T>(dbContext);
        }

        public RepositoryBase<T> RepositoryBase { get; }

        public async virtual Task<int> CreateAsync(T entity)
        {
            return await RepositoryBase.CreateAsync(entity);
        }

        public async virtual Task<int> DeleteAsync(T entity)
        {
            return await RepositoryBase.DeleteAsync(entity);
        }

        public async virtual Task<IQueryable<T>> FindAllIncludeAsync(Expression<Func<T, bool>> filter = null, params Expression<Func<T, object>>[] input)
        {
            return await RepositoryBase.FindAllIncludeAsync(filter, input);
        }

        public async virtual Task<ICollection<T>> GetAllAsync(Expression<Func<T, bool>> filter = null)
        {
            return await RepositoryBase.GetAllAsync(filter);
        }

        public async virtual Task<T?> GetByAsync(Expression<Func<T, bool>> filter)
        {
            return await RepositoryBase.GetByAsync(filter);
        }

        public async virtual Task<T?> GetByIdAsync(int id)
        {
            return await RepositoryBase.GetByIdAsync(id);
        }

        public async virtual Task<int> UpdateAsync(T entity)
        {
            return await RepositoryBase.UpdateAsync(entity);
        }
    }
}
