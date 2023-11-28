using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TemplateDotNet.Domain.Entities;

namespace TemplateDotNet.Infra.Data.EF.Mappings;
public class UserMapping : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("users");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).HasColumnName("id").HasColumnType("uuid").IsRequired();
        builder.Property(x => x.Username).HasColumnName("username").IsRequired();
        builder.Property(x => x.Password).HasColumnName("password").IsRequired();
        builder.Property(x => x.Email).HasColumnName("email").IsRequired();
        builder.Property(x => x.CreatedAt).HasColumnName("created_at").HasColumnType("timestamp").IsRequired();
        builder.Property(x => x.UpdatedAt).HasColumnName("updated_at").HasColumnType("timestamp").IsRequired();
        builder.Property(x => x.ProfileId).HasColumnName("id_profile").HasColumnType("uuid").IsRequired();
        builder.HasOne(x => x.Profile).WithMany(x => x.Users).HasForeignKey(x => x.ProfileId);
    }
}
