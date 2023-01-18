using Microsoft.AspNetCore.Mvc;
using StokYonetim.WebUI.Models.Abstract;

namespace StokYonetim.WebUI.Controllers
{
    public class KategoriController : Controller
    {
        private readonly IWebKategoriService webKategoriService;

        public KategoriController(IWebKategoriService webKategoriService)
        {
            this.webKategoriService = webKategoriService;
        }
        public async Task<IActionResult> Index()
        {
            var token = await webKategoriService.GetUserAsync("ali@gmail.com", "123");

            var kategoriler = await webKategoriService.GetAllAsync();


            return View(kategoriler.OrderBy(p => p.Id));
        }
    }
}
