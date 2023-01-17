namespace StokYonetim.WebUI.Models
{
    public class ApiUrls
    {
        public string GetById { get; set; }
        public string GetAll { get; set; }

        public ApiUrls(string TableName)
        {
            GetById = "api/" + TableName + "/GetById";
            GetAll = "api/" + TableName + "/GetAll";
        }
    }
}