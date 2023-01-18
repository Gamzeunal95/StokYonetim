using StokYonetim.Entities;

namespace StokYonetim.WebUI.Models.Abstract
{
    public interface IWebApiBaseService<T> where T : BaseEntity, new()
    {

        Task<T> GetByIdAsync(int id);
        Task<List<T>> GetAllAsync();
        Task<Token> GetUserAsync(string email, string password);
    }
}
