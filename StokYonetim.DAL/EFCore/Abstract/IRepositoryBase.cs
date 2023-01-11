using System.Linq.Expressions;

namespace StokYonetim.DAL.EFCore.Abstract
{
    public interface IRepositoryBase<T> where T : class, new()
    {
        Task<int> CreateAsync(T entity);
        Task<int> DeleteAsync(T entity);
        Task<int> UpdateAsync(T entity);

        Task<T> GetByIdAsync(int id);

        Task<T> GetByAsync(Expression<Func<T, bool>> filter); // null verilmeyecek çünkü ne getireceğini belirtmesi gerekir. filter vermeli

        Task<ICollection<T>> GetAllAsync(Expression<Func<T, bool>> filter = null); // Predicate 

        Task<IQueryable<T>> FindAllIncludeAsync(Expression<Func<T, bool>> filter = null
            , params Expression<Func<T, object>>[] input);
    }
}
