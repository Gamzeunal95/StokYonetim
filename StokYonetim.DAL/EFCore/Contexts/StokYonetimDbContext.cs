using Microsoft.EntityFrameworkCore;
using StokYonetim.Entities;
using System.Reflection;

namespace StokYonetim.DAL.EFCore.Contexts
{
    public class StokYonetimDbContext : DbContext
    {
        public DbSet<Kategori> Kategoriler { get; set; }
        public DbSet<Stok> Stoklar { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }


        public StokYonetimDbContext()
        {

        }
        public StokYonetimDbContext(DbContextOptions<StokYonetimDbContext> options) : base(options)
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseNpgsql("Server=11.0.17.100;Port=5432;Database=StokYonetim;User Id=postgres;Password=123;");
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());  // Tüm classlara bakacak IEntityTypeConfiguration dan kalıtım alan classlardaki prpertyleri alacak ve uygulayacak.
        }
    }
}
