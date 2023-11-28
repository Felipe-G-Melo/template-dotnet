using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TemplateDotNet.Domain.Entities;

namespace TemplateDotNet.Infra.Data.EF.Mappings;
public class ProfileMapping : IEntityTypeConfiguration<Profile>
{
    public void Configure(EntityTypeBuilder<Profile> builder)
    {
        builder.ToTable("profiles");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).HasColumnName("id").HasColumnType("uuid").IsRequired();
        builder.Property(x => x.Name).HasColumnName("name").IsRequired();
        builder.Property(x => x.CreatedAt).HasColumnName("created_at").HasColumnType("timestamp").IsRequired();
        builder.Property(x => x.UpdatedAt).HasColumnName("updated_at").HasColumnType("timestamp").IsRequired();
        builder.HasMany(x => x.ProfilesSubMenus).WithOne(x => x.Profile).HasForeignKey(x => x.ProfileId).OnDelete(DeleteBehavior.Cascade);
    }
}

