using StokYonetim.BL.Abstract;
using StokYonetim.DAL.EFCore.Contexts;
using StokYonetim.Entities;

namespace StokYonetim.BL.Concrete
{
    public class StokManager : ManagerBase<Stok>, IStokManager
    {
        public StokManager(StokYonetimDbContext dbContext) : base(dbContext)
        {

        }

        public override async Task<int> CreateAsync(Stok entity)
        {
            if (string.IsNullOrEmpty(entity.StokAdi))
            {
                throw new Exception("Stok Adı Boş Bırakılamaz Berkay kızar");
            }
            if (string.IsNullOrEmpty(entity.Birim))
            {
                throw new Exception("Birim adı boş bırakılamaz");
            }
            return await base.CreateAsync(entity);

            // Bu kısımda exeption fırlatıldığı için api kısmında try catch yapılmalı
        }
    }
}
