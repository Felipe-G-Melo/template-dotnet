using TemplateDotNet.Domain.SeedWork;

namespace TemplateDotNet.Domain.Entities;
public class Menu : BaseEntity
{
    public string Icon { get; private set; }
    public string Name { get; private set; }
    public List<SubMenu> SubMenus { get; private set; }
}
