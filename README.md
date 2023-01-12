# StokYonetim
- Class Library 
- Proje Konusu : Hem clientWebService + kendi WebServiceimizi yazacağız - Token olacak - Authentication 
- Web APİ tarafına bağlanılacakları ayrı bir yerde tutmayı tercih edebiliriz. Ayrı bir DB olabilir. (APi tüketecek olan username password verilerini)
- Postgresql kullanıldı.Dberaver üzerinden DB'ye erişildi. Karşı PC'deki DB yere bağlanıldı. PC kendi localinde çalıştırılmadı.
- NOT: ORM - > entitiy framework core (birde mirco ORM var bu da Dapper)

# Project 1 - StokYonetim.Entities
- Clas silindi yeni classlar eklendi.
  - Kategori.cs
  - Stok.cs
  
# Project 2 - StokYonetim.DAL
- Aşağıdaki paketler install edildi.
  - Npgsql.EntityFrameworkCore.PostgreSQL
  - Microsoft.EntityFrameworkCore.Design

- Bir ORM kullanmamız gerekir. Bunun içinde entity Framework kullanıldı.
- Projeye Dependencies kısmından Referans verildi (StokYonetim.Entities projesi)

- **EfCore Folder**
  - **Abstact**
    - IRepositoryBase (Interface)
    - IKategoriDal
    - IStokDal
  - **Concrete**
    - RepositoryBase
    - KategoriDal
    - StokDal
  - **Contexts**
    - StokYonetimDbContext
  - **EntityConfigurations** (StokYonetimDbContext de yazdığımız OnModelCreating methodunu şişirmemek için bu kısımda classlar açarak configure ediyoruz. Navigation prop. lar)
    - KategoriConfiguration  
    - StokConfiguration
    
# Project 3 - StokYonetim.WebApi (Bu kendi API'miz olacak)
- Asp.Net Core Web API projesi
- Aşağıdaki paketler install edildi.
  - Npgsql.EntityFrameworkCore.PostgreSQL
  - Microsoft.EntityFrameworkCore.Design
- Projeye Dependencies kısmından Referans verildi (StokYonetim.Entities & StokYonetim.DAL )
- **Controller**
  - KategoriController 




### API yada clietn olurken aşağıdaki gibi crud işlemlerinin adı aynı şekilde thunder Client ya da Postman de test ederken de
- Get -> Select
- Put -> Update
- Post -> Create
- Delete -> Delete
    
 # NOT: Bir Projede ilk aşamalar nasıl olmalıdır. Bu projede akış nasıl ilerlerdi
- Entity
- Dbset
- Configurations (StokYonetimDbContext de yazdığımız OnModelCreating methodunu şişirmemek için bu kısımda classlar açarak configure ediyoruz. Navigation prop. lar)
- Daha sonrasında migrations olusturabilirsiniz . Repositorylerden önce yapabilirsiniz.
- Kategori içinde Stok içinde API controller yazıldı. Swagger üzerinden test edildi.
- Sonra Entities'e Role - User-UserROle ekledik ve sonrasında EntityConfigurations klasörüne de ekleme yaptık

- Kendi API mizi yazdığımız zaman Asp.Net Core Web API projesi ama client olduğumuz zaman API açmıyoruz crud işlemlerini yapıyoruz Client olarak başka bir API ye işlem yapıyoruz.

- Abstract klasörüne ınterface class ekleme yapıldı sonrasında açılan classın Concrete işine DAL classını açıldı. Örneğin; IKategoriDAL -> KategoriDAL
- Tred ?? Araştır Async ile bağlantılı 
- Task verdiğinizde başınada async eklemen aşağıdada await ile beklemen lazım
