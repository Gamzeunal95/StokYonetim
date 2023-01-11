using StokYonetim.DAL.EFCore.Abstract;
using StokYonetim.DAL.EFCore.Contexts;
using StokYonetim.Entities;

namespace StokYonetim.DAL.EFCore.Concrete
{
    public class StokDal : RepositoryBase<Stok>, IStokDal
    {
        private readonly StokYonetimDbContext dbContext;

        public StokDal(StokYonetimDbContext dbContext) : base(dbContext)
        {
            this.dbContext = dbContext;
        }
    }
}
