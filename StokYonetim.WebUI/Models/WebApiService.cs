using StokYonetim.Entities;
using StokYonetim.WebUI.Controllers;

namespace StokYonetim.WebUI.Models
{
    public abstract class BaseWebApiService<T> where T : BaseEntity, new()
    {

        readonly Uri BaseUrl;

        readonly HttpClient httpClient;

        protected BaseWebApiService()
        {
            this.httpClient = new HttpClient();
            BaseUrl = new Uri(@"http://localhost:5115/");
            httpClient.BaseAddress = BaseUrl;
        }

        public async Task<T> GetById(int id)
        {

            string tableName = nameof(T);
            ApiUrls apiUrls = new ApiUrls(tableName);
            var result = await httpClient.GetAsync(apiUrls.GetById + id.ToString());

            return result;
        }

    }
}
