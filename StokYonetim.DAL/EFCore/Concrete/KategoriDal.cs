using StokYonetim.DAL.EFCore.Abstract;
using StokYonetim.DAL.EFCore.Contexts;
using StokYonetim.Entities;

namespace StokYonetim.DAL.EFCore.Concrete
{
    public class KategoriDal : RepositoryBase<Kategori>, IKategoriDal
    {


        public KategoriDal(StokYonetimDbContext dbContext) : base(dbContext)
        {

        }
    }
}
