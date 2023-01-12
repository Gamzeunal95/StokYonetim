using FluentValidation;
using StokYonetim.Entities;

namespace StokYonetim.BL.Validations
{
    public class StokValidation : AbstractValidator<Stok>
    {
        public StokValidation()
        {
            RuleFor(x => x.Id).NotNull();
            RuleFor(x => x.StokAdi).Length(0, 50).NotEmpty().NotNull();
            RuleFor(x => x.Fiyat).ExclusiveBetween(0, int.MaxValue);  //Fiyat sıfırdan küçük olmasın
            RuleFor(x => x.Adet).ExclusiveBetween(0, int.MaxValue); ;
            RuleFor(x => x.Birim).NotEmpty(); // boş olamaz

        }
    }
}
