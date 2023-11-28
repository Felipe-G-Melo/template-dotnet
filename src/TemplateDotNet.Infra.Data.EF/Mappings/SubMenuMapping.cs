using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TemplateDotNet.Domain.Entities;

namespace TemplateDotNet.Infra.Data.EF.Mappings;
public class SubMenuMapping : IEntityTypeConfiguration<SubMenu>
{
    public void Configure(EntityTypeBuilder<SubMenu> builder)
    {
        builder.ToTable("sub_menus");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).HasColumnName("id").HasColumnType("uuid").IsRequired();
        builder.Property(x => x.Name).HasColumnName("name").IsRequired();
        builder.Property(x => x.Icon).HasColumnName("icon").IsRequired();
        builder.Property(x => x.MenuId).HasColumnName("id_menu").IsRequired();
        builder.Property(x => x.Path).HasColumnName("path").IsRequired();
        builder.Property(x => x.CreatedAt).HasColumnName("created_at").HasColumnType("timestamp").IsRequired();
        builder.Property(x => x.UpdatedAt).HasColumnName("updated_at").HasColumnType("timestamp").IsRequired();
        builder.HasOne(x => x.Menu).WithMany(x => x.SubMenus);
        builder.HasMany(x => x.ProfilesSubMenus).WithOne(x => x.SubMenu).HasForeignKey(x => x.SubMenuId);
    }
}
