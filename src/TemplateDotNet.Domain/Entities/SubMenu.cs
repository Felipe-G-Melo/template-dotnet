using TemplateDotNet.Domain.SeedWork;

namespace TemplateDotNet.Domain.Entities;
public class SubMenu : BaseEntity
{
    public Guid MenuId { get; private set; }
    public Menu Menu { get; private set; }
    public string Icon { get; private set; }
    public string Name { get; private set; }
    public string Path { get; private set; }
    public List<ProfilesSubMenus>? ProfilesSubMenus { get; private set; }
}
