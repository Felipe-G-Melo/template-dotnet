using Microsoft.EntityFrameworkCore;
using TemplateDotNet.Infra.Data.EF.Mappings;

namespace TemplateDotNet.Infra.Data.EF;
public class TemplateDotNetDbContext : DbContext
{
    public TemplateDotNetDbContext(DbContextOptions<TemplateDotNetDbContext> options)
        : base(options) 
    { }

    override protected void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new UserMapping());
        modelBuilder.ApplyConfiguration(new ProfileMapping());
        modelBuilder.ApplyConfiguration(new MenuMapping());
        modelBuilder.ApplyConfiguration(new SubMenuMapping());
        modelBuilder.ApplyConfiguration(new ProfilesSubMenusMapping());
    }
}
