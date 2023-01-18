namespace StokYonetim.WebUI.Models
{
    public class ApiUrls
    {
        public string GetById { get; set; }
        public string GetAll { get; set; }
        public string Login { get; set; }
        public string Post { get; set; }
        public string Put { get; set; }
        public string Delete { get; set; }
        public ApiUrls(string TableName)
        {
            GetById = "api/" + TableName + "/GetById/";
            GetAll = "api/" + TableName + "/GetAll/";
            Post = "api/" + TableName + "/Post/";
            Put = "api/" + TableName + "/Put/";
            Delete = "api/" + TableName + "/Delete/";
            Login = "api/Login/Login/";
        }
    }
}