# StokYonetim 
- Class Library 
- Proje Konusu : Hem clientWebService + kendi WebServiceimizi yazacağız - Token olacak - Authentication 
- Web APİ tarafına bağlanılacakları ayrı bir yerde tutmayı tercih edebiliriz. Ayrı bir DB olabilir. (APi tüketecek olan username password verilerini)
- Postgresql kullanıldı.Dberaver üzerinden DB'ye erişildi. Daha reel bir senaryo olması için karşı PC'deki DBye bağlanıldı.PC kendi localinde çalıştırılmadı. İsternirse Connection bilgileri değiştirilerek çalıştırılabilir.
- NOT: ORM - > entitiy framework core (birde mirco ORM var bu da Dapper)

# Project 1 - StokYonetim.Entities
- Class silindi yeni classlar eklendi.
  - Kategori.cs
  - Stok.cs
  - BaseEntity
  - Role
  - User
  - UserRole
---------------------------------------------------  
# Project 2 - StokYonetim.DAL
- Class Library 
- Aşağıdaki paketler install edildi.
  - Npgsql.EntityFrameworkCore.PostgreSQL
  - Microsoft.EntityFrameworkCore.Design  
- Bir ORM kullanmamız gerekir. Bunun içinde Entity Framework kullanıldı.
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
  - **EntityConfigurations** (StokYonetimDbContext de yazılan OnModelCreating methodunu şişirmemek için bu kısımda classlar açarak configure ediyoruz. Navigation prop. lar)
    - KategoriConfiguration  
    - StokConfiguration
    - RoleConfiguration
    - UserConfiguration
    - UserRoleConfiguration
    
--------------------------------------------------- 

# Project 3 - StokYonetim.WebApi (Bu kendi API'miz olacak)
- Asp.Net Core Web API projesi
- Aşağıdaki paketler install edildi.
    - Npgsql.EntityFrameworkCore.PostgreSQL
    - Microsoft.EntityFrameworkCore.Design
    - Microsoft.AspNetCore.Authentication.JwtBearer  -> (Token ile alakalı classları olusturduktan sonra)
- Projeye Dependencies kısmından Referans verildi (StokYonetim.Entities & StokYonetim.DAL & StokYonetim.BL )

- **Controller**
  - KategoriController 
  - Stokcontroller
  - LoginController
- **Extensions**
  - StokYonetimExtensions (program.cs dosyasında şişme olmaması için böyle bir class açıldı ve program cs de belirtildi)
- **Model**
  - Token
  - TokenHandler
  - LoginModel
- NOT : JWT ayarlamalarını program.cs de yaptıktan sonra appsetting kısmında tanımlanması yapıldı.
--------------------------------------------------- 

# Project 4 - StokYonetim.BL  
- (Manager kısmında ne varsa bu kısımda yani iş katmanı -  iş kuralları ile alakalı her özellik interface classlarında belirtildi)
- Class Library 
- Projeye Dependencies kısmından Referans verildi (StokYonetim.Entities & StokYonetim.DAL )
- Aşağıdaki paketler install edildi.
  - FluentValidation.AspNetCore
- **Abstract*
  - IManagerBase(Interface)
  - IKategoriManager
  - IStokManager
- **Concrete**
  - ManagerBase
  - IKategoriManager
  - IStokManager
- **Validations**
  - StokValidation
--------------------------------------------------- 

# Project 5 - StokYonetim.WebUI
- MVC Projesi açıldı.
- Projeye Dependencies kısmından Referans verildi (StokYonetim.Entities )
-**Controller**
  - KategoriController
-**Models**
  - WebApiService (class açıldı. bu kısımı yazdıldı ki tüm kontrollerlarda tekrar tekrar yazmak zorunda kalınmasın)
  



- NOT: StokYonetim.WebApi ve StokYonetim.WebUI projeleri brilikte çalıştırıldı.
--------------------------------------------------- 
# Project 6 - OdataWebApi (OpenData)
- Bu projede O Data için çalışma yapıldı.
- Aşağıdaki paketler install edildi.
  - Microsoft.AspNetCore.OData
- Projeye Dependencies kısmından Referans verildi (StokYonetim.Entities & StokYonetim.DAL & StokYonetim.BL ) (OData denemesi StokYonetim projesi üzerinden yapıdı.)
- **Controller**
  - KategoriController


- NOT: `?$` kullanman gerektiğini unutma Postman GET kısmında 
  - https://localhost:7252/odata/?$metadata
  - https://localhost:7252/odata/?$metadata#Kategori
  - https://localhost:7252/odata/Kategori?$select=aciklama  // kayıtların açıklamaları
  - https://localhost:7252/odata/Kategori?$filter=id eq 4 //4 numaralı ıd
  - https://localhost:7252/odata/Kategori?$filter=id ge 4  //4 numaralı ıd ve üstü
  - https://localhost:7252/odata/Kategori?$filter=startswith(kategoriadi ,'l') //Kategoriadi l ile başlayanlar (aciklama da diyebilirdin ne filtre istiyorsak)
--------------------------------------------------- 

- Stok yonetim UI APi ile ilk muhattap olacağı için ilk önce API deki controller sonra UI daki controllerlar yazılacak UI kısmındaki kontroller için Base olusturup kalıtım alarak controllerları yazıp çağırmak yeterli olacaktır. BaseWebApiService bu projedeki basemodels concrete içinde ve generic yapılacak ki diğer controllerlar için kullanabilelim

### API yada client olurken aşağıdaki gibi crud işlemlerinin adı aynı şekilde Thunder Client ya da Postman de test ederken de
- Get -> Select
- Put -> Update
- Post -> Create
- Delete -> Delete
- Token alırken post olarak
    
 # NOT: Bir Projede ilk aşamalar nasıl olmalıdır. Bu projede akış nasıl ilerlerdi
- Entity
- Dbset
- Configurations (StokYonetimDbContext de yazdığımız OnModelCreating methodunu şişirmemek için bu kısımda classlar açarak configure ediyoruz. Navigation prop. lar)
- Daha sonrasında migrations olusturabilirsiniz . Repositorylerden önce yapabilirsiniz.
- Kategori içinde Stok içinde API controller yazıldı. Swagger üzerinden test edildi.
- Sonra Entities'e Role - User-UserROle ekledik ve sonrasında EntityConfigurations klasörüne de ekleme yaptık
- Validation 
- LoginController - Token işlemleri için sınıflar olusturuldu.

 # NOT:
- Kendi API mizi yazdığımız zaman Asp.Net Core Web API projesi ama client olduğumuz zaman API açmıyoruz crud işlemlerini yapıyoruz Client olarak başka bir API ye işlem yapıyoruz.
- Clasın içinde ICollection var ise has many ile başşlayabiliriz. başlıyoruz
- Abstract klasörüne ınterface class ekleme yapıldı sonrasında açılan classın Concrete işine DAL classını açıldı. Örneğin; IKategoriDAL -> KategoriDAL
- Tred ?? Araştır Async ile bağlantılı 
- Task verdiğinizde başınada async eklemen aşağıdada await ile beklemen lazım


### Proje Dokuman 
![StokYonetim](https://user-images.githubusercontent.com/101207897/212961739-27c86ca4-3371-473e-ae4c-950b9df9b5d4.png)

