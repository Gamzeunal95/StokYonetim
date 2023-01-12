using StokYonetim.BL.Abstract;
using StokYonetim.DAL.EFCore.Contexts;
using StokYonetim.Entities;

namespace StokYonetim.BL.Concrete
{
    public class KategoriManager : ManagerBase<Kategori>, IKategoriManager
    {
        public KategoriManager(StokYonetimDbContext dbContext) : base(dbContext)
        {
        }
    }
}
