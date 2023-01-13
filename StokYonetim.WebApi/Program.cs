
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using StokYonetim.BL.Validations;
using StokYonetim.DAL.EFCore.Contexts;
using StokYonetim.Entities;
using StokYonetim.WebApi.Extensions;

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