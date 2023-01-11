using Microsoft.AspNetCore.Mvc;
using StokYonetim.DAL.EFCore.Abstract;

namespace StokYonetim.WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class KategoriController : ControllerBase
    {
        private readonly IKategoriDal kategoriDal;

        public KategoriController(IKategoriDal kategoriDal)
        {
            this.kategoriDal = kategoriDal;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await kategoriDal.GetAllAsync();
            return Ok(result);
        }
    }
}
