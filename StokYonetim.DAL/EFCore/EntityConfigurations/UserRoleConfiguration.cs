using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StokYonetim.Entities;

namespace StokYonetim.DAL.EFCore.EntityConfigurations
{
    public class UserRoleConfiguration : IEntityTypeConfiguration<UserRole>
    {
        public void Configure(EntityTypeBuilder<UserRole> builder)
        {

            builder.Property(p => p.Id).UseIdentityColumn(); //UseIdentityColumn ıd'nin tek tek artmasını sağlar
            builder.HasKey(x => new { x.UserId, x.RoleId });

            builder.ToTable("UserRoles");  // Tablo ismi verdik 

            builder.HasOne(p => p.User)
                .WithMany(p => p.UserRoles)
                .HasForeignKey(p => p.UserId);

            builder.HasOne(p => p.Role)
                .WithMany(p => p.UserRoles)
                .HasForeignKey(p => p.RoleId);

        }
    }
}
