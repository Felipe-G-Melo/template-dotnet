using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TemplateDotNet.Domain.Entities;

namespace TemplateDotNet.Infra.Data.EF.Mappings;
public class ProfilesSubMenusMapping : IEntityTypeConfiguration<ProfilesSubMenus>
{
    public void Configure(EntityTypeBuilder<ProfilesSubMenus> builder)
    {
        builder.ToTable("profiles_sub_menus");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).HasColumnName("id").HasColumnType("uuid").IsRequired();
        builder.Property(x => x.SubMenuId).HasColumnName("id_sub_menu").IsRequired();
        builder.Property(x => x.ProfileId).HasColumnName("id_profile").IsRequired();
        builder.HasOne(x => x.SubMenu).WithMany(x => x.ProfilesSubMenus).HasForeignKey(x => x.SubMenuId);
        builder.HasOne(x => x.Profile).WithMany(x => x.ProfilesSubMenus).HasForeignKey(x => x.ProfileId);
        builder.Ignore(x => x.CreatedAt);
        builder.Ignore(x => x.UpdatedAt);
    }
}
