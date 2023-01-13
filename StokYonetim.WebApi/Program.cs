
using FluentValidation;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using StokYonetim.BL.Validations;
using StokYonetim.DAL.EFCore.Contexts;
using StokYonetim.Entities;
using StokYonetim.WebApi.Extensions;
using System.Text;

namespace StokYonetim.WebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();

            builder.Services.AddDbContext<StokYonetimDbContext>(
                options => options.UseNpgsql(builder.Configuration.GetConnectionString("StokYonetim")));

            builder.Services.AddScoped<IValidator<Stok>, StokValidation>();

            // bu kýsým çok dolduðu için extensions açýyoruz  ve aþaðýdaki gibi belirtiyoruz.
            builder.Services.AddStokExtensions();

            builder.Services.AddSwaggerGen();

            // JWT ayarlamalarý yapýldý
            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
               .AddJwtBearer(options =>
               {

                   options.RequireHttpsMetadata = false;
                   options.SaveToken = true;

                   options.TokenValidationParameters = new TokenValidationParameters
                   {
                       ValidateIssuer = true,
                       ValidateAudience = true,
                       ValidateLifetime = true,
                       ValidateIssuerSigningKey = true,
                       ValidIssuer = builder.Configuration["Token:Issuer"],
                       ValidAudience = builder.Configuration["Token:Audience"],
                       IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Token:SecurityKey"])),
                       ClockSkew = TimeSpan.Zero

                   };
               });


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}