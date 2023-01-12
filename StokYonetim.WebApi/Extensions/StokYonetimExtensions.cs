using StokYonetim.BL.Abstract;
using StokYonetim.BL.Concrete;

namespace StokYonetim.WebApi.Extensions
{
    public static class StokYonetimExtensions
    {
        public static IServiceCollection AddStokExtensions(this IServiceCollection services)
        {
            services.AddScoped<IKategoriManager, KategoriManager>();
            services.AddScoped<IStokManager, StokManager>();

            return services;
        }
    }
}
