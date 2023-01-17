using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StokYonetim.BL.Abstract;
using StokYonetim.Entities;
using System.Net;

namespace StokYonetim.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class StokController : ControllerBase
    {
        private readonly IStokManager stokManager;
        private readonly IValidator<Stok> validator;

        public StokController(IStokManager stokManager, IValidator<Stok> validator)
        {
            this.stokManager = stokManager;
            this.validator = validator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await stokManager.GetAllAsync();
            if (result == null)
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
        public async Task<int> Post(Stok stok)  //Create-Post
        {
            ValidationResult valresult = await validator.ValidateAsync(stok);

            if (!valresult.IsValid)
            {

            }


            var result = await stokManager.CreateAsync(stok);
            if (result == null)
            {
                return (int)HttpStatusCode.NotFound;
            }
            else if (result == 0)
            {
                return (int)HttpStatusCode.NotImplemented;
            }
            return (int)HttpStatusCode.OK;
        }

        [HttpPut]
        public async Task<IActionResult> Put(Stok stok) // Update-Put
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
        public async Task<IActionResult> Delete(Stok stok)
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
