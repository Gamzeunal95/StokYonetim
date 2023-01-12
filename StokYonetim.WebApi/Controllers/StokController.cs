using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using StokYonetim.BL.Abstract;
using StokYonetim.Entities;

namespace StokYonetim.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StokController : ControllerBase
    {
        private readonly IStokManager stokManager;

        public StokController(IStokManager stokManager, IValidator<Stok> validator)
        {
            this.stokManager = stokManager;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await stokManager.GetAllAsync();
            if (result.Count == 0)
            {
                return NotFound();
            }
            else
            {
                return Ok(result);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            Stok stok = await stokManager.GetByIdAsync(id);
            if (stok == null)
            {
                return NotFound(id);
            }
            else
            {
                return Ok(stok);
            }
        }

        [HttpPost]
        public async Task<IActionResult> StokEkle(Stok stok)  //Create-Post
        {
            var sonuc = await stokManager.CreateAsync(stok);
            if (sonuc > 0)
            {
                return Ok();
            }
            else
            {
                return BadRequest(sonuc);
            }
        }

        [HttpPut]
        public async Task<IActionResult> StokGuncelle(Stok stok) // Update-Put
        {
            var sonuc = await stokManager.UpdateAsync(stok);
            if (sonuc > 0)
            {
                return Ok();
            }
            else
            {
                return BadRequest(sonuc);
            }
        }

        [HttpDelete]
        public async Task<IActionResult> StokSil(Stok stok)
        {
            var sonuc = await stokManager.DeleteAsync(stok);
            if (sonuc > 0)
            {
                return Ok();
            }
            else
            {
                return BadRequest(sonuc);
            }
        }
    }
}
