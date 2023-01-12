namespace StokYonetim.Entities
{
    public class Kategori : BaseEntity
    {

        public string KategoriAdi { get; set; }
        public string Aciklama { get; set; }

        public ICollection<Stok>? Stoklar { get; set; }

    }
}
