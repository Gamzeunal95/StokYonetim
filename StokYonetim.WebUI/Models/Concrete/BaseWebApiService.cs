using StokYonetim.Entities;
using StokYonetim.WebUI.Models.Abstract;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;

namespace StokYonetim.WebUI.Models.Concrete
{
    public abstract class BaseWebApiService<T> : IWebApiBaseService<T> where T : BaseEntity, new()
    {
        readonly Uri BaseUrl;

        readonly HttpClient httpClient;
        ApiUrls ApiUrls;
        public string TableName { get; set; }
        protected BaseWebApiService()
        {
            var table = nameof(T);
            httpClient = new HttpClient();
            BaseUrl = new Uri(@"https://localhost:7036/");
            httpClient.BaseAddress = BaseUrl;
            TableName = typeof(T).Name;
            ApiUrls = new ApiUrls(TableName);
        }

        public async Task<T> GetByIdAsync(int id)
        {
            string tableName = typeof(T).Name;

            T sonuc = new T();

            var token = await GetUserAsync("ali@gmail.com", "123");

            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token.AccessToken);

            var response = await httpClient.GetAsync(ApiUrls.GetById + id.ToString());


            if (response != null)
            {
                var result = await response.Content.ReadAsStringAsync();
                sonuc = JsonSerializer.Deserialize<T>(result);


            }


            //httpClient.PostAsync();
            //httpClient.PutAsync();
            //httpClient.DeleteAsync();

            return sonuc;
        }

        public async Task<List<T>> GetAllAsync()
        {
            string tableName = typeof(T).Name;

            List<T> sonuc = new List<T>();

            var token = await GetUserAsync("ali@gmail.com", "123");

            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token.AccessToken.Replace("Bearer", ""));

            var response = await httpClient.GetAsync(ApiUrls.GetAll);


            if (response != null)
            {
                var result = await response.Content.ReadAsStringAsync();
                sonuc = JsonSerializer.Deserialize<List<T>>(result);


            }


            //httpClient.PostAsync();
            //httpClient.PutAsync();
            //httpClient.DeleteAsync();

            return sonuc;
        }


        public async Task<Token> GetUserAsync(string email, string password)
        {


            LoginModel loginModel = new LoginModel { email = "ali@gmail.com", password = "123" };
            httpClient.DefaultRequestHeaders.Accept.Clear();
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var serilizeObject = JsonSerializer.Serialize(loginModel);
            StringContent stringContent = new StringContent(serilizeObject, Encoding.UTF8, "application/json");
            HttpResponseMessage responseMessage = await httpClient.PostAsync(ApiUrls.Login, stringContent);

            var jsonresult = await responseMessage.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<Token>(jsonresult);
            return result;
        }



        //public int  { get; set; }
    }

}
