using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StokYonetim.Entities;

namespace StokYonetim.DAL.EFCore.EntityConfigurations
{
    public class KategoriConfiguration : IEntityTypeConfiguration<Kategori>   // implement interface de configure methodu gelsin
    {
        public void Configure(EntityTypeBuilder<Kategori> builder)
        {
            builder.Property(p => p.KategoriAdi).HasMaxLength(50);
            builder.Property(p => p.Aciklama).HasMaxLength(200);

            // Kategoride ICollection var yani çok ilişkili o yüzden HasMany kullanıyoruz.(Bir kategori ama birden fazla stok)
            builder.HasMany(p => p.Stoklar).WithOne(s => s.Kategori)
                                           .HasForeignKey(p => p.KategoriId)
                                           .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
