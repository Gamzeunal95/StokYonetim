namespace StokYonetim.Entities
{
    public class BaseEntity            // Bu classı açma sebebi GetByIdAsync methodunu yazarken ıd isterken T tipinden ne geleceğini bilemediği için BaseEntity açtık ve diğer classlara kalıtım verdik yani Base entityden kalıtım alanlar için rahatca kullanabilmek içn
    {
        public int Id { get; set; }
    }
}
