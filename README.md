# StokYonetim
- Class Library 
- Proje Konusu : Hem clientWebService + kendi WebServiceimizi yazacağız - Token olacak - Authentication 
- Web APİ tarafına bağlanılacakları ayrı bir yerde tutmayı tercih edebiliriz. Ayrı bir DB olabilir. (APi tüketecek olan username password verilerini)
- Postgresql kullanıldı. Karşı PC'deki DB yere bağlanıldı. PC kendi localinde çalıştırılmadı.
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
  - **Concrete**
    - RepositoryBase
  - **Contexts**
    - StokYonetimDbContext
  - **EntityConfigurations** (StokYonetimDbContext de yazdığımız OnModelCreating methodunu şişirmemek için bu kısımda classlar açarak configure ediyoruz. Navigation prop. lar)
    - KategoriConfiguration  
    - StokConfiguration
    
        
    
    
 # NOT: Bir Projede ilk aşamalar nasıl olmalıdır. Bu projede akış nasıl ilerlerdi
- Entity
- Dbset
- Configurations (StokYonetimDbContext de yazdığımız OnModelCreating methodunu şişirmemek için bu kısımda classlar açarak configure ediyoruz. Navigation prop. lar)
- Daha sonrasında migrations olusturabilirsiniz . Repositorylerden önce yapabilirsiniz.


- Tred ?? Araştır Async ile bağlantılı 
- Task verdiğinizde başınada async eklemen aşağıdada await ile beklemen lazım
