
using Microsoft.AspNetCore.OData;
using Microsoft.EntityFrameworkCore;
using Microsoft.OData.Edm;
using Microsoft.OData.ModelBuilder;
using StokYonetim.BL.Abstract;
using StokYonetim.BL.Concrete;
using StokYonetim.DAL.EFCore.Contexts;
using StokYonetim.Entities;

namespace OdataWebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            //builder.Services.AddControllers();
            //OData kullan�lacak
            static IEdmModel GetEdmModel()
            {
                ODataConventionModelBuilder modelBuilder = new ODataConventionModelBuilder();
                modelBuilder.EntitySet<Kategori>("Kategori");
                return modelBuilder.GetEdmModel();
            }

            builder.Services.AddControllers().AddOData(
                opt => opt.AddRouteComponents("odata", GetEdmModel())   // odata url de yazmas� gerekecek
                          .Filter()
                          .Select()
                          .Expand()
                          .OrderBy()
                );


            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();


            // connection bilgileri Appsetting.json dosyas�na da eklemeyi unutma
            builder.Services.AddDbContext<StokYonetimDbContext>(
               options => options.UseNpgsql(builder.Configuration.GetConnectionString("StokYonetim")));

            //kullan�lacak di�er servisler.
            builder.Services.AddScoped<IKategoriManager, KategoriManager>();
            builder.Services.AddScoped<IStokManager, StokManager>();



            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseRouting();

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            #region OData Configuration

            //// Sorgulanacak entitiy'leri burada tan�ml�yoruz.            
            //var odatabuilder = new ODataConventionModelBuilder();
            //odatabuilder.EntitySet<Kategori>("Kategori");
            //odatabuilder.EntitySet<Stok>("Stok");

            #endregion


            app.Run();
        }
    }
}