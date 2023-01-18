using System.Text.Json.Serialization;

namespace StokYonetim.Entities
{
    public class Kategori : BaseEntity
    {
        [JsonPropertyName("kategoriAdi")]
        public string KategoriAdi { get; set; }
        [JsonPropertyName("aciklama")]
        public string Aciklama { get; set; }

        [JsonPropertyName("stoklar")]
        public ICollection<Stok>? Stoklar { get; set; }

    }
}
