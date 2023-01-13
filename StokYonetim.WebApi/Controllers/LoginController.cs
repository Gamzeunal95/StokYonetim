using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StokYonetim.DAL.EFCore.Contexts;
using StokYonetim.Entities;
using StokYonetim.WebApi.Models;

namespace StokYonetim.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly StokYonetimDbContext dbcontext;
        private readonly IConfiguration configuration;

        public LoginController(StokYonetimDbContext dbcontext, IConfiguration configuration) // field olusturuldu
        {
            this.dbcontext = dbcontext;
            this.configuration = configuration;
        }
        /// <summary>
        /// Login için Email ve Şifre Gerekli
        /// </summary>
        /// <param name="loginModel"></param>
        /// <returns></returns>

        [HttpPost("[action]")]
        public async Task<IActionResult> Login(LoginModel loginModel)
        {
            User user = await dbcontext.Users
                               .Include(u => u.UserRoles)
                               .ThenInclude(p => p.Role)
                               .FirstOrDefaultAsync(p => p.Email == loginModel.Email && p.Password == loginModel.Password);
            if (user != null)
            {
                //Token uretme aşaması
                TokenHandler tokenHandler = new(configuration);
                Token token = tokenHandler.CreateAccessToken(user);

                // Refresh token'i User tablosuna ekleme
                user.RefreshToken = token.RefreshToken;
                user.RefreshTokenEndTime = token.Expiration.AddMinutes(3);
                await dbcontext.SaveChangesAsync();
                return Ok(token);
            }
            return NotFound();
        }

    }
}
